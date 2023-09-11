namespace Verity.CashFlow.Infrastructure.Persistence.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CashFlowContext context) : base(context)
    {
    }

    public async Task<Cash> GetCashByDate(DateOnly date)
    {
        var transactions = await Context
            .Cashes
            .Include(x => x.Transactions)
            .FirstOrDefaultAsync(cash => cash.DateOfCash == date);

        return transactions;
    }

    public IQueryable<Transaction> GetAllTransactionsByDate(DateOnly date)
    {
        var transactions = CurrentSet
            .AsNoTracking()
            .Where(transaction => transaction.DateOfTransaction == date);
        
        return transactions;
    }

    public async Task<BalanceDetailsDto?> GetBalanceDetailsByDate(DateOnly date)
    {
        var currentDateCash = await Context
                .Cashes
                .Include(cash => cash.Transactions)
                .AsNoTracking()
                .FirstOrDefaultAsync(cash => cash.DateOfCash == date);

        var incomeInCents = currentDateCash!
            .Transactions
            .Where(x => x.Type == TransactionType.Income)
            .Select(x => x.AmountInCents)
            .Sum();

        var outcomeInCents = currentDateCash!
            .Transactions
            .Where(x => x.Type == TransactionType.Outcome)
            .Select(x => x.AmountInCents)
            .Sum();

        var balance = currentDateCash.StartBalanceInCents + (incomeInCents - outcomeInCents);

        return new BalanceDetailsDto
        {
            IncomeInCents = incomeInCents,
            OutcomeInCents = outcomeInCents,
            BalanceInCents = balance,
            DateOfCashFlow = date,
        };
    }
}
