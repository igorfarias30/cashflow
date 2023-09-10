using Verity.CashFlow.Infrastructure.Mappers;

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

        return serviceCollection;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
        return serviceCollection;
    }

    public static IServiceCollection AddMappings(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(BalanceDetailsMapperProfile));
        return serviceCollection;
    }

    public static IServiceCollection AddInfra(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDatabase(configuration)
            .AddRepositories()
            .AddMappings();

        return serviceCollection;
    }
}
