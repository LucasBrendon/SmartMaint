using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar;

namespace SmartMaint.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CriarEnderecoCommandValidator>();
            services.AddFluentValidationAutoValidation();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            ConfigureResponseValidations(services);

            return services;
        }

        public static void ConfigureResponseValidations(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(m => m.Value.Errors.Count > 0)
                        .SelectMany(m => m.Value.Errors.Select(e => $"{e.ErrorMessage}"))
                        .ToList();

                    var result = ApiResponse.ErrorResponse("Validation Error", errors);

                    return new BadRequestObjectResult(result);
                };
            });
        }
    }
}
