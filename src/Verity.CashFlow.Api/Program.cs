using Verity.CashFlow.Infrastructure;
using Verity.CashFlow.Application;
using Microsoft.Extensions.DependencyInjection;
using Verity.CashFlow.Contracts.Convertes;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder
    .Services
    .AddApplication()
    .AddInfra(configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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
