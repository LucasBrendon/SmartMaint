using FluentValidation;
using SmartMaint.Compartilhado.ApiResponse;
using System.Text.Json;

namespace SmartMaint.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)//Erros de validação.
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var response = GenericResponse.ErrorResponse("Erro de validação", ex.Errors.Select(e => e.ErrorMessage).ToList());

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (Exception ex)//Captura outras exceções e cria uma resposta genérica
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var includeDetails = context.RequestServices.GetRequiredService<IWebHostEnvironment>()
                                                            .IsDevelopment();

                var erroDetails = new ErrorDetail
                {
                    Message = ex.Message,
                    StackTrace = includeDetails ? ex.StackTrace : null,
                    ExceptionType = ex.GetType().Name
                };

                var response = GenericResponse.ErrorResponse("Ocorreu um erro inesperado", null, erroDetails);

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
