using Verity.CashFlow.Infrastructure;
using Verity.CashFlow.Application;
using Verity.CashFlow.Infrastructure.Persistence;
using Serilog;
using Verity.CashFlow.Infrastructure.Convertes;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration.WriteTo.Console();
});

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

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "Verity.CashFlow Api"));
}

try
{
    await using var serviceScope = app.Services.CreateAsyncScope();
    await using var dbContext = serviceScope.ServiceProvider.GetRequiredService<CashFlowContext>();
    await dbContext.Database.EnsureDeletedAsync();
    await dbContext.Database.EnsureCreatedAsync();
}
catch (Exception ex)
{
    Log.Error(ex.Message);
}

var recurringJob = app.Services.GetRequiredService<IRecurringJobManager>();
recurringJob.AddOrUpdate("Close cash", () => Console.WriteLine("Rodando"), "* * * * * *");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "Cash Flow Process",
});

app.Run();
