﻿using OperationResult;
using Verity.CashFlow.Domain.Enums;

namespace Verity.CashFlow.Contracts.Requests.Commands;

public record struct CreateTransactionCommand(
    DateOnly TransactionDate,
    long AmountInCents,
    string Description,
    TransactionType Type,
    string? Comment
) : ICommand<Result>;
