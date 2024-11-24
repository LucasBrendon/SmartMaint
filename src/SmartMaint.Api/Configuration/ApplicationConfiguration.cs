using Microsoft.EntityFrameworkCore;
using SmartMaint.Persistencia.Contexto;

namespace SmartMaint.Api.Configuration
{
    public static class ApplicationConfiguration
    {
        public static void InicializarBaseDeDados(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var contexto = scope.ServiceProvider.GetService<EscritaDbContexto>();
            contexto?.Database?.Migrate();

            var inicializador = scope.ServiceProvider.GetService<DbContextoInicializador>();
            inicializador?.GerarConfiguracaoInicial();
        }
    }
}
