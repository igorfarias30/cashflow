using System.Reflection;
using Mapster;
using MapsterMapper;

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
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        serviceCollection.AddSingleton(config);
        serviceCollection.AddScoped<IMapper, ServiceMapper>();
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
