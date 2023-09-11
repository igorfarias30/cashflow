using OperationResult;
using Verity.CashFlow.Application.Services;
using Verity.CashFlow.Application.Services.Strategies;
using Verity.CashFlow.Infrastructure.Exceptions;

namespace Verity.CashFlow.Infrastructure.Services;

internal class DataExporterStrategyService : IDataExporterStrategyService
{
    private readonly IEnumerable<IDataExporterByKindStrategy> _strategies;

    public DataExporterStrategyService(IEnumerable<IDataExporterByKindStrategy> strategies)
    {
        _strategies = strategies;
    }

    public Result<IDataExporterByKindStrategy> Get(FileKind kind)
    {
        var strategy = _strategies.SingleOrDefault(strategy => strategy.Kind == kind);

        if (strategy is null)
            return new StrategyNotFoundException(kind.ToString());

        return Result.Success(strategy);
    }
}
