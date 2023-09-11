using Verity.CashFlow.Domain.Enums;
using Verity.CashFlow.Domain.Primitives;

namespace Verity.CashFlow.Domain.Entities;

public class Transaction : Entity
{
    private Transaction() { }

    public Transaction(DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, TransactionStatus status, string? comment)
    {
        DateOfTransaction = dateOfTransaction;
        AmountInCents = amountInCents;
        Description = description;
        Type = type;
        Status = status;
        Comment = comment;
    }

    public Transaction(long id, long cashId, DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, TransactionStatus status, string? comment)
        : this(dateOfTransaction, amountInCents, description, type, status, comment)
    {
        Id = id;
        CashId = cashId;
    }


    public long CashId { get; set; }
    public Cash Cash { get; set; }

    public DateOnly DateOfTransaction { get; private set; }
    public long AmountInCents { get; private set; }
    public string Description { get; private set; } = null!;
    public string? Comment { get; private set; }
    public TransactionType Type { get; private set; }
    public TransactionStatus Status { get; private set; }

    public static Transaction Create(DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, TransactionStatus status, string? comment)
       => new(dateOfTransaction, amountInCents, description, type, status, comment);

    public static Transaction Create(long id, long cashId, DateOnly dateOfTransaction, long amountInCents, string description, TransactionType type, TransactionStatus status, string? comment)
       => new(id, cashId, dateOfTransaction, amountInCents, description, type, status, comment);
}