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

    // Setup recurring job to close the cash in each day
    // The job will run each day at 23:59:00
    var cashFlowService = serviceScope.ServiceProvider.GetRequiredService<ICashFlowService>();
    var recurringJob = serviceScope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    recurringJob.AddOrUpdate("close-cash-job", () => cashFlowService.CloseCash(), "00 59 23 * * *");
}
catch (Exception ex)
{
    Log.Error(ex.Message);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "Cash Flow Process",
});

app.Run();
