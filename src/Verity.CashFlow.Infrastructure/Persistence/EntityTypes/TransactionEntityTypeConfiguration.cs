using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Verity.CashFlow.Domain.Entities;

namespace Verity.CashFlow.Infrastructure.Persistence.EntityTypes;

internal class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(transaction => transaction.Id);
        builder.Property(transaction => transaction.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id,
                value => Guid.NewGuid()
            );
    }
}
