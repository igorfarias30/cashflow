using Mapster;
using Verity.CashFlow.Contracts.ViewModels;

namespace Verity.CashFlow.Infrastructure.Mappers;

internal class BalanceDetailsMapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        Expression<Func<Transaction, long>> _evaluateIncome = src => src.AmountInCents;
        Expression<Func<Transaction, long>> _evaluateOutcome = src => src.AmountInCents;
        Expression<Func<Transaction, long>> _evaluateBalance = src => src.AmountInCents;
            //.Where(transaction => transaction.Type == TransactionType.Income)
            //.Select(x => x.AmountInCents);
            //.Sum();
        
        config.NewConfig<Transaction, BalanceDetailsViewModel>()
            .Map(dest => dest.IncomeInCents, _evaluateIncome)
            .Map(dest => dest.OutcomeInCents, _evaluateOutcome)
            .Map(dest => dest.BalanceInCents, _evaluateBalance)
            .Map(dest => dest.Transactions, src => src.Adapt<TransactionViewModel>());
    }
}
