using Verity.CashFlow.Contracts.DTOs;

namespace Verity.CashFlow.Infrastructure.Persistence.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CashFlowContext context) : base(context)
    {
    }

    public IQueryable<Transaction> GetAllByDate(DateOnly date)
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
            DateOfCashFlow = date
        };
    }

    public IQueryable<Cash> GetCashByDate(DateOnly date)
    {
        return Context
                .Cashes
                .Include(cash => cash.Transactions)
                .AsNoTracking()
                .Where(cash => cash.DateOfCash == date);
    }
}
