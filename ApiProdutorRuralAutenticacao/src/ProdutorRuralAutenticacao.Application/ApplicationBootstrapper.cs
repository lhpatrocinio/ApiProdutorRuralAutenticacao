using Microsoft.Extensions.DependencyInjection;
using ProdutorRuralAutenticacao.Application.Services;
using ProdutorRuralAutenticacao.Application.Services.Interfaces;

namespace ProdutorRuralAutenticacao.Application
{
    public static class ApplicationBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IProdutorRuralAutenticacaoService, ProdutorRuralAutenticacaoService>();
        }
    }
}
