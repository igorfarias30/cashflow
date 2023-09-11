using Verity.CashFlow.Domain.Primitives;

namespace Verity.CashFlow.Domain.Entities;

public class Cash : Entity
{
    private readonly List<Transaction> _transactions = new();

    private Cash() { }

    private Cash(DateOnly dateOfCash, long startBalanceInCents, long? closedBalanceInCents)
    {
        DateOfCash = dateOfCash;
        StartBalanceInCents = startBalanceInCents;
        ClosedBalanceInCents = closedBalanceInCents;
    }

    private Cash(long id, DateOnly dateOfCash, long startBalanceInCents, long? closedBalanceInCents)
        : this(dateOfCash, startBalanceInCents, closedBalanceInCents)
    {
        Id = id;
    }

    public List<Transaction> Transactions => _transactions;
    public DateOnly DateOfCash { get; private set; }
    public bool IsClosed { get; private set; } = false;

    /**
     * Refers to the closed balance in cents on previous day
     */
    public long StartBalanceInCents { get; private set; }

    /**
     * Refers to the closed balance in cents on the current day when the day ends
     */
    public long? ClosedBalanceInCents { get; private set; }

    public static Cash Create(DateOnly dateOfCash, long startBalanceInCents, long? closedBalanceInCents)
        => new(dateOfCash, startBalanceInCents, closedBalanceInCents);

    public static Cash Create(long id, DateOnly dateOfCash, long startBalanceInCents, long? closedBalanceInCents)
        => new(id, dateOfCash, startBalanceInCents, closedBalanceInCents);

    public void CloseCash()
        => IsClosed = true;

    public void SetClosedBalanceInCents(long closedBalance)
        => ClosedBalanceInCents = closedBalance;

    public void AddTransaction(Transaction transaction)
       => Transactions.Add(transaction);
}
