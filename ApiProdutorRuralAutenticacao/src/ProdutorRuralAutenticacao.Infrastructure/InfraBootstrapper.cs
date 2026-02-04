using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProdutorRuralAutenticacao.Application.Repository;
using ProdutorRuralAutenticacao.Infrastructure.DataBase.Repository;

namespace ProdutorRuralAutenticacao.Infrastructure
{
    public static class InfraBootstrapper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProdutorRuralAutenticacaoRepository, ProdutorRuralAutenticacaoRepository>();         
        }
    }
}
