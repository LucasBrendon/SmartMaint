using FluentValidation;
using MediatR;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar;

namespace SmartMaint.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CriarEnderecoCommandValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
