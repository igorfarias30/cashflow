using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Verity.CashFlow.Contracts.DTOs;

namespace Verity.CashFlow.Infrastructure.Persistence.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CashFlowContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public IQueryable<BalanceDetailsDto> GetBalanceDetailsByDate(DateOnly date)
    {
        var cashOfDay = Context
                .Cashes
                .AsNoTracking()
                .Where(cash => cash.DateOfCash == date)
                .Include(transaction => transaction.Transactions)
                .UseAsDataSource(MapperConfigProvider).For<BalanceDetailsDto>();

        //var transactions = CurrentSet
        //        .AsNoTracking()
        //        .Where(transaction => transaction.DateOfTransaction == date);

        //var incomeInCents = transactions
        //    .Where(x => x.Type == TransactionType.Income)
        //    .Select(x => x.AmountInCents)
        //    .Sum();

        //var outcomeInCents = transactions
        //    .Where(x => x.Type == TransactionType.Outcome)
        //    .Select(x => x.AmountInCents)
        //    .Sum();

        //return new BalanceDetailsDto
        //{
        //    IncomeInCents = incomeInCents,
        //    OutcomeInCents = outcomeInCents,
        //    DateOfCashFlow = date,
        //    Transactions = transactions
        //};

        return cashOfDay;
    }
}
