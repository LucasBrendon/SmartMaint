using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartMaint.Aplicacao.Interfaces.Repositorios;
using SmartMaint.Persistencia.Contexto;
using SmartMaint.Persistencia.Interfaces;
using SmartMaint.Persistencia.Repositorios;

namespace SmartMaint.Persistencia
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddPersistencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EscritaDbContexto>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("ConnectionDbEscrita")));

            services.AddDbContext<LeituraDbContexto>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("ConnectionDbLeitura")));

            services.AddScoped<DbContextoInicializador>();
            services.AddScoped<IEscritaDbContexto, EscritaDbContexto>();
            services.AddScoped<ILeituraDbContexto, LeituraDbContexto>();

            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();

            return services;
        }
    }
}
