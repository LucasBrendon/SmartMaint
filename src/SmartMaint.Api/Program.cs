using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SmartMaint.Aplicacao;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar;
using SmartMaint.Persistencia;
using SmartMaint.Persistencia.Contexto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplicacao();
builder.Services.AddPersistencia(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<CriarEnderecoCommandValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();

var contexto = scope.ServiceProvider.GetService<EscritaDbContexto>();
contexto.Database?.Migrate();

var inicializador = scope.ServiceProvider.GetService<DbContextoInicializador>();
inicializador?.GerarConfiguracaoInicial();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
