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

        builder.HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 1500L,
                    Description = "2 milks",
                    Type = TransactionType.Income,
                    Status = TransactionStatus.Received
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 5000L,
                    Description = "10 rice",
                    Type = TransactionType.Income,
                    Status = TransactionStatus.Received
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 3000L,
                    Description = "20 salt",
                    Type = TransactionType.Income,
                    Status = TransactionStatus.Received
                }
            );
    }
}
