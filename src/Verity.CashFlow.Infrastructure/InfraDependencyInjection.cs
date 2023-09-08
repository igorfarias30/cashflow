namespace Verity.CashFlow.Infrastructure;

public static class InfraDependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Default");

        serviceCollection.AddDbContext<CashFlowContext>((serviceProvider, builder) =>
        {
            builder
                .UseNpgsql(connection!);
        });

        //serviceCollection.AddScoped<IApplicationDbContext, CondManagerContext>();

        return serviceCollection;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        return serviceCollection;
    }

    public static IServiceCollection AddInfra(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDatabase(configuration)
            .AddRepositories();

        return serviceCollection;
    }
}
