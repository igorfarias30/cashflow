using Verity.CashFlow.Domain.Enums;

namespace Verity.CashFlow.Contracts.ViewModels;

public record struct TransactionViewModel(
    long Id,
    string Description,
    long AmountInCents,
    TransactionType Type,
    TransactionStatus Status
);