namespace Verity.CashFlow.Infrastructure.Mappers;

internal class BalanceDetailsMapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        Expression<Func<Cash, long>> _incomeRetrieve = balance => balance
            .Transactions
            .Where(x => x.Type == TransactionType.Income)
            .Select(x => x.AmountInCents)
            .Sum();

        Expression<Func<Cash, long>> _outcomeRetrieve = balance => balance
            .Transactions
            .Where(x => x.Type == TransactionType.Outcome)
            .Select(x => x.AmountInCents)
            .Sum();

        config.NewConfig<Cash, BalanceDetailsViewModel>()
            .Map(dest => dest.IncomeInCents, _incomeRetrieve)
            .Map(dest => dest.OutcomeInCents, _outcomeRetrieve)
            .Map(dest => dest.Transactions, src => src.Transactions);

        config.NewConfig<BalanceDetailsDto, BalanceDetailsViewModel>()
            .Map(dest => dest.IncomeInCents, src => src.IncomeInCents)
            .Map(dest => dest.OutcomeInCents, src => src.OutcomeInCents)
            .Map(dest => dest.BalanceInCents, src => src.BalanceInCents)
            .Map(dest => dest.Transactions, src => src.Transactions);
    }
}
