using Verity.CashFlow.Contracts.DTOs;
using Verity.CashFlow.Domain.Entities;

namespace Verity.CashFlow.Infrastructure.Persistence.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CashFlowContext context) : base(context)
    {
    }

    public async Task<BalanceDetailsDto?> GetBalanceDetailsByDate(DateOnly date)
    {
        //var cash = (
        //    from cashes in Context.Cashes
        //    join transactions in Context.Transactions on cashes.Id.ToString() equals transactions.CashId.ToString()
        //    where cashes.DateOfCash == date
        //    select cashes
        //    );

        //var cash = Context
        //        .Cashes.ToList();

        var cash = Context
                .Cashes
                .Include(cash => cash.Transactions)
                .AsNoTracking()
                .Where(cash => cash.DateOfCash == date);

        //.Include(transaction => transaction.Transactions)
        //.AsNoTracking()
        //.Where(cash => cash.DateOfCash == date)
        //.ToListAsync();

        var incomeInCents = cash!.First()
            .Transactions
            .Where(x => x.Type == TransactionType.Income)
            .Select(x => x.AmountInCents)
            .Sum();

        var outcomeInCents = cash!.First()
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
