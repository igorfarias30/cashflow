using Verity.CashFlow.Application.Services.Strategies;

namespace Verity.CashFlow.Application.Services;

public interface IDataExporterStrategyService
{
    Result<IDataExporterByKindStrategy> Get(FileKind kind);
}
