using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using ProdutorRuralAutenticacao.Api.Extensions.Auth;
using ProdutorRuralAutenticacao.Api.Extensions.Auth.Middleware;
using ProdutorRuralAutenticacao.Api.Extensions.Logs;
using ProdutorRuralAutenticacao.Api.Extensions.Logs.ELK;
using ProdutorRuralAutenticacao.Api.Extensions.Logs.Extension;
using ProdutorRuralAutenticacao.Api.Extensions.Mappers;
using ProdutorRuralAutenticacao.Api.Extensions.Migration;
using ProdutorRuralAutenticacao.Api.Extensions.Swagger;
using ProdutorRuralAutenticacao.Api.Extensions.Swagger.Middleware;
using ProdutorRuralAutenticacao.Api.Extensions.Tracing;
using ProdutorRuralAutenticacao.Api.Extensions.Versioning;
using ProdutorRuralAutenticacao.Application;
using ProdutorRuralAutenticacao.Infrastructure;
using ProdutorRuralAutenticacao.Infrastructure.DataBase.EntityFramework.Context;
using ProdutorRuralAutenticacao.Infrastructure.Monitoring;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfiguration();
builder.WebHost.UseUrls("http://*:80");

builder.Services.AddMvcCore(options => options.AddLogRequestFilter());
builder.Services.AddVersioning();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthorizationExtension(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


#region [DI]

ApplicationBootstrapper.Register(builder.Services);
InfraBootstrapper.Register(builder.Services, builder.Configuration);

// Prometheus monitoring
builder.Services.AddPrometheusMonitoring();

// ELK Stack integration  
builder.Services.AddELKIntegration(builder.Configuration);

// Distributed Tracing with OpenTelemetry + Jaeger
builder.Services.AddDistributedTracing(builder.Configuration);

#endregion

#region [Consumers]
//builder.Services.AddSingleton<RabbitMqSetup>();
//builder.Services.AddHostedService<UserCreatedConsumer>();

#endregion

var app = builder.Build();

app.ExecuteMigrations();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseAuthentication();                        // 1°: popula HttpContext.User
app.UseMiddleware<RoleAuthorizationMiddleware>();
app.UseCorrelationId();
app.UseELKIntegration();

app.UseCors("AllowAll");

// Prometheus middleware
app.UsePrometheusMonitoring();

app.UseVersionedSwagger(apiVersionDescriptionProvider);
app.UseAuthorization();                         // 3°: aplica [Authorize]
//app.UseHttpsRedirection();
app.MapControllers();

// Health Check endpoints
app.MapHealthChecks("/health");
app.MapHealthChecks("/health/ready", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready")
});
app.MapHealthChecks("/health/live", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("live")
});

app.Run();
