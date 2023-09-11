using Verity.CashFlow.Application.Services.Exporter;

namespace Verity.CashFlow.Infrastructure.Services.Strategies;

public class DataExporterCsvStrategy : IDataExporterByKindStrategy
{
    public FileKind Kind => FileKind.Csv;

    public MemoryStream Export<T>(IEnumerable<T> data)
    {
        var stringBuilder = new StringBuilder();
        using var stringWriter = new StringWriter(stringBuilder);

        var configuration = new CsvConfiguration(CultureInfo.GetCultureInfo("pt-br"))
        {
            Delimiter = ","
        };
        using var writer = new CsvWriter(stringWriter, configuration);
        writer.WriteRecords(data);

        var bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
        return new MemoryStream(bytes);
    }
}
