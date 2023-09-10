using Microsoft.EntityFrameworkCore;
using Verity.CashFlow.Contracts.DTOs;

namespace Verity.CashFlow.Infrastructure.Persistence.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CashFlowContext context) : base(context)
    {
    }

    public async Task<BalanceDetailsDto?> GetBalanceDetailsByDate(DateOnly date)
    {
        var cash = (
            from cashes in Context.Cashes
            join transactions in Context.Transactions on cashes.Id equals transactions.CashId
            where cashes.DateOfCash == date
            select cashes).First();


        //var cash = await Context
        //        .Cashes
        //        .Include(cash => cash.Transactions)
        //        .AsNoTracking()
        //        .Where(cash => cash.DateOfCash == date)
        //        .FirstAsync();
                
                //.Include(transaction => transaction.Transactions)
                //.AsNoTracking()
                //.Where(cash => cash.DateOfCash == date)
                //.ToListAsync();

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

        return new BalanceDetailsDto
        {
            IncomeInCents = incomeInCents,
            OutcomeInCents = outcomeInCents,
            BalanceInCents = balance,
            DateOfCashFlow = date
        };
    }
}
