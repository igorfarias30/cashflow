using Verity.CashFlow.Domain.Enums;
using Verity.CashFlow.Domain.Primitives;

namespace Verity.CashFlow.Domain.Entities;

public class Transaction : Entity
{
    private Transaction() { }

    public Transaction(Guid id, DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, string? comment)
        : base(id)
    {
        DateOfTransaction = dateOfTransaction;
        AmountInCents = amountInCents;
        Description = description;
        Type = type;
        Comment = comment;
    }

    public DateOnly DateOfTransaction { get; private set; }
    public long AmountInCents { get; private set; }
    public string Description { get; private set; } = null!;
    public string? Comment { get; private set; }
    public TransactionType Type { get; private set; }

    public static Transaction Create(DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, string? comment)
       => new(Guid.NewGuid(), dateOfTransaction, amountInCents, description, type, comment);
}
