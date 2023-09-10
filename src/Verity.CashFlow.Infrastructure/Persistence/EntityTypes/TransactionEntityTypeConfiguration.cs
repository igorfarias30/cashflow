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

        builder
          .HasOne(transaction => transaction.Cash)
          .WithMany(cash => cash.Transactions)
          .HasForeignKey(transaction => transaction.CashId)
          .OnDelete(DeleteBehavior.Cascade);

        builder
            .Metadata
            .FindNavigation(nameof(Transaction.Cash))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    CashId = InitialData.CashId,
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 1500L,
                    Description = "2 milks",
                    Type = TransactionType.Income,
                    Status = TransactionStatus.Payed
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CashId = InitialData.CashId,
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 5000L,
                    Description = "10 rice",
                    Type = TransactionType.Income,
                    Status = TransactionStatus.Payed
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CashId = InitialData.CashId,
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 3000L,
                    Description = "20 salt",
                    Type = TransactionType.Income,
                    Status = TransactionStatus.Payed
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CashId = InitialData.CashId,
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 2515L,
                    Description = "1 Kg argentine apple",
                    Type = TransactionType.Income,
                    Status = TransactionStatus.Payed
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CashId = InitialData.CashId,
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 65750L,
                    Description = "15 Kg picanha",
                    Type = TransactionType.Income,
                    Status = TransactionStatus.Payed
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CashId = InitialData.CashId,
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 20000L,
                    Description = "Energy Bill",
                    Type = TransactionType.Outcome,
                    Status = TransactionStatus.Payed
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CashId = InitialData.CashId,
                    CreatedAt = new DateTimeOffset(2023, 9, 9, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                    DateOfTransaction = new DateOnly(2023, 9, 9),
                    AmountInCents = 10000L,
                    Description = "Water Bill",
                    Type = TransactionType.Outcome,
                    Status = TransactionStatus.Payed
                }
            );
    }
}