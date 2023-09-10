namespace Verity.CashFlow.Infrastructure.Persistence.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CashFlowContext context) : base(context)
    {
    }

    public async Task<Cash?> GetBalanceDetailsByDate(DateOnly date)
    {
        var cash = await Context
                .Cashes
                .Include(transaction => transaction.Transactions)
                .AsNoTracking()
                .FirstOrDefaultAsync(cash => cash.DateOfCash == date);

        //cash;
        //return cash.Include(transaction => transaction.Transactions).FirstOrDefault();

        var incomeInCents = cash!
            .Transactions
            .Where(x => x.Type == TransactionType.Income)
            .Select(x => x.AmountInCents)
            .Sum();

        var outcomeInCents = cash!
            .Transactions
            .Where(x => x.Type == TransactionType.Outcome)
            .Select(x => x.AmountInCents)
            .Sum();

        var balance = incomeInCents - outcomeInCents;

        return cash;
        //return new BalanceDetailsDto
        //{
        //    IncomeInCents = incomeInCents,
        //    OutcomeInCents = outcomeInCents,
        //    BalanceInCents = balance,
        //    DateOfCashFlow = date
        //};
    }
}
