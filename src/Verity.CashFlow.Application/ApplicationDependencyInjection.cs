using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Verity.CashFlow.Application.RequestHandlers.QueryHandlers;

namespace Verity.CashFlow.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(config => config
            .RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                typeof(GetTransactionsQueryHandler).GetTypeInfo().Assembly
            )
        );
        
        return serviceCollection;
    }
}
