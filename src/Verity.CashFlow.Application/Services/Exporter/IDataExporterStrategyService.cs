using Verity.CashFlow.Application.Services.Strategies;

namespace Verity.CashFlow.Application.Services.Exporter;

public interface IDataExporterStrategyService
{
    Result<IDataExporterByKindStrategy> Get(FileKind kind);
}
