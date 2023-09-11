using Verity.CashFlow.Application.Services.Exporter;

namespace Verity.CashFlow.Application.Services.Strategies;

public interface IDataExporterByKindStrategy
{
    FileKind Kind { get; }
    MemoryStream Export<T>(IEnumerable<T> data);
}
