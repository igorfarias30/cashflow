using Verity.CashFlow.Infrastructure;
using Verity.CashFlow.Application;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder
    .Services
    .AddApplication()
    .AddInfra(configuration)
    .AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "Verity.CashFlow Api"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
