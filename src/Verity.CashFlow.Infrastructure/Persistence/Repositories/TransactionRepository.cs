using Verity.CashFlow.Contracts.DTOs;

namespace Verity.CashFlow.Infrastructure.Persistence.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CashFlowContext context) : base(context)
    {
    }

    public BalanceDetailsDto GetBalanceDetailsByDate(DateOnly date)
    {
        var transactions = CurrentSet
                .AsNoTracking()
                .Where(transaction => transaction.DateOfTransaction == date);

        var incomeInCents = transactions
            .Where(x => x.Type == TransactionType.Income)
            .Select(x => x.AmountInCents)
            .Sum();

        var outcomeInCents = transactions
            .Where(x => x.Type == TransactionType.Outcome)
            .Select(x => x.AmountInCents)
            .Sum();

        var balance = incomeInCents - outcomeInCents;

        return new BalanceDetailsDto
        {
            IncomeInCents = incomeInCents,
            OutcomeInCents = outcomeInCents,
            BalanceInCents = balance,
            DateOfCashFlow = date
        };
    }
}
