using OperationResult;
using Verity.CashFlow.Contracts.ViewModels;
using Verity.CashFlow.Domain.Enums;

namespace Verity.CashFlow.Contracts.Requests.Commands;

public record struct UpdateTransactionCommand(
    long Id,
    DateOnly TransactionDate,
    long AmountInCents,
    string Description,
    TransactionType Type,
    TransactionStatus Status,
    string? Comment
) : ICommand<Result<TransactionViewModel>>;