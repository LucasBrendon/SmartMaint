using Microsoft.Extensions.DependencyInjection;
using SmartMaint.Aplicacao.Interfaces.Persistencia;
using SmartMaint.Persistencia.Contexto;

namespace SmartMaint.Persistencia
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ResolverDependenciasPersistencia(this IServiceCollection services)
        {
            services.AddScoped<IEscritaDbContexto, EscritaDbContexto>();
            services.AddScoped<ILeituraDbContexto, ILeituraDbContexto>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
