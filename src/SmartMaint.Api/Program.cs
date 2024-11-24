using SmartMaint.Api.Configuration;
using SmartMaint.Aplicacao;
using SmartMaint.Persistencia;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApi();
builder.Services.AddAplicacao();
builder.Services.AddPersistencia(builder.Configuration);

var app = builder.Build();

ApplicationConfiguration.InicializarBaseDeDados(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
