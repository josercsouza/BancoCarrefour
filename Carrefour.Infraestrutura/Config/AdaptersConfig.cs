using Carrefour.Dominio.Interfaces;
using Carrefour.Dominio.Repositorios;
using Carrefour.Dominio.Servicos.Implementacao;
using Carrefour.Infraestrutura.Dados.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Carrefour.Infraestrutura.Config
{
    public static class AdaptersConfig
    {
        public static void AddAdapters(this IServiceCollection services)
        {
            services.AddScoped<IServicoDeLancamento, ServicoDeLancamento>();
            services.AddScoped<IServicoDeRelatorio, ServicoDeRelatorio>();

            services.AddScoped<IRepositorioDeContaCorrente, RepositorioDeContaCorrente>();
        }
    }
}
