using Verity.CashFlow.Domain.Enums;
using Verity.CashFlow.Domain.Primitives;

namespace Verity.CashFlow.Domain.Entities;

public class Transaction : Entity
{
    private Transaction() { }

    public Transaction(Guid id, DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, TransactionStatus status, string? comment)
        : base(id)
    {
        DateOfTransaction = dateOfTransaction;
        AmountInCents = amountInCents;
        Description = description;
        Type = type;
        Status = status;
        Comment = comment;
    }
    public Transaction(Guid id, Guid cashId, DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, TransactionStatus status, string? comment)
        : this(id, dateOfTransaction, amountInCents, description, type, status, comment)
    {
        CashId = cashId;
    }


    public Guid CashId { get; set; }
    public Cash Cash { get; set; }

    public DateOnly DateOfTransaction { get; private set; }
    public long AmountInCents { get; private set; }
    public string Description { get; private set; } = null!;
    public string? Comment { get; private set; }
    public TransactionType Type { get; private set; }
    public TransactionStatus Status { get; private set; }

    public static Transaction Create(DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, TransactionStatus status, string? comment)
       => new(Guid.NewGuid(), dateOfTransaction, amountInCents, description, type, status, comment);

    public static Transaction Create(Guid id, Guid cashId, DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, TransactionStatus status, string? comment)
       => new(id, cashId, dateOfTransaction, amountInCents, description, type, status, comment);
}