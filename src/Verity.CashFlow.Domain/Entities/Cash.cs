using Verity.CashFlow.Domain.Primitives;

namespace Verity.CashFlow.Domain.Entities;

public class Cash : Entity
{
    //private readonly List<Transaction> _transactions = new();

    private Cash() { }

    private Cash(Guid id, DateOnly dateOfCash, long startBalanceInCents, long? closedBalanceInCents)
        : base(id)
    {
        DateOfCash = dateOfCash;
        StartBalanceInCents = startBalanceInCents;
        ClosedBalanceInCents = closedBalanceInCents;
    }

    public List<Transaction> Transactions { get; private set; } = new();
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
        => new(Guid.NewGuid(), dateOfCash, startBalanceInCents, closedBalanceInCents);

    public void CloseCash()
        => IsClosed = true;

    public void AddTransaction(Transaction transaction)
       => Transactions.Add(transaction);
}
