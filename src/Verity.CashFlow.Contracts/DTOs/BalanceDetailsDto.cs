namespace Verity.CashFlow.Contracts.DTOs;

public record BalanceDetailsDto
{
    public long IncomeInCents { get; init; }
    public long OutcomeInCents { get; init; }
    public DateOnly DateOfCashFlow { get; init; }
    public IEnumerable<TransactionDetailsDto> Transactions { get; init; }
}
