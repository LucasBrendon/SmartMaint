using Microsoft.Extensions.DependencyInjection;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar;

namespace SmartMaint.Aplicacao
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddAplicacao(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarEnderecoCommand).Assembly));

            return services;
        }
    }
}
