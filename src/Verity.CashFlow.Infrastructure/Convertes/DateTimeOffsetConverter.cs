using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Verity.CashFlow.Infrastructure.Convertes;

public class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffsetConverter()
        : base(
            d => d.ToUniversalTime(),
            d => d.ToUniversalTime()
        ) { }
}
