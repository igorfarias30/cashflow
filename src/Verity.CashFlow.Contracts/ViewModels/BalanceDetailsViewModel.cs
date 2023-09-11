namespace Verity.CashFlow.Contracts.ViewModels;

public record struct BalanceDetailsViewModel
{
    public long IncomeInCents { get; init; }
    public long OutcomeInCents { get; init; }
    public long BalanceInCents { get; init; }
    public DateOnly DateOfCashFlow { get; init; }
    public IEnumerable<TransactionViewModel> Transactions { get; init; }
}
