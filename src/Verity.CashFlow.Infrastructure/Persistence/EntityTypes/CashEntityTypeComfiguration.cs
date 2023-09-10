namespace Verity.CashFlow.Infrastructure.Persistence.EntityTypes;

internal class CashEntityTypeComfiguration : IEntityTypeConfiguration<Cash>
{
    public void Configure(EntityTypeBuilder<Cash> builder)
    {
        builder.ToTable("Cashes");

        builder.HasKey(cash => cash.Id);
        builder.Property(cash => cash.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id,
                value => Guid.NewGuid()
            );

        builder
           .HasMany(cash => cash.Transactions)
           .WithOne(transaction => transaction.Cash)
           .HasForeignKey(transaction => transaction.CashId)
           .OnDelete(DeleteBehavior.Cascade);

        builder
           .Metadata
           .FindNavigation(nameof(Cash.Transactions))!
           .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder
            .Navigation(cash => cash.Transactions)
            .Metadata
            .SetField("_transactions");

        builder
            .Navigation(s => s.Transactions)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasData(
            new {
                Id = InitialData.CashId,
                CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                DateOfCash = new DateOnly(2023, 9, 9),
                StartBalanceInCents = 1000000L,
                IsClosed = false,
            }
        );
    }
}
