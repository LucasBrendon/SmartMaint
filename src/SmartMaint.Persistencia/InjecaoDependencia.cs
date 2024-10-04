using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartMaint.Aplicacao.Interfaces.Persistencia;
using SmartMaint.Persistencia.Contexto;

namespace SmartMaint.Persistencia
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ResolverDependenciasPersistencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EscritaDbContexto>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("ConnectionDbEscrita")));

            services.AddDbContext<LeituraDbContexto>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("ConnectionDbLeitura")));

            services.AddScoped<DbContextoInicializador>();
            services.AddScoped<IEscritaDbContexto, EscritaDbContexto>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILeituraDbContexto, LeituraDbContexto>();

            return services;
        }
    }
}
