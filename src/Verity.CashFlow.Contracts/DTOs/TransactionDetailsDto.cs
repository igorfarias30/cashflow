using Verity.CashFlow.Domain.Enums;

namespace Verity.CashFlow.Contracts.DTOs;

public record TransactionDetailsDto
{
    public string Id { get; init; }
    public DateOnly DateOfTransaction { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public long AmountInCents { get; init; }
    public string Description { get; init; } = null!;
    public string? Comment { get; init; }
    public TransactionType Type { get; init; }
    public TransactionStatus Status { get; init; }
}
