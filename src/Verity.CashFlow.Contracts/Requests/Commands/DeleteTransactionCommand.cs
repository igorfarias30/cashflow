using OperationResult;

namespace Verity.CashFlow.Contracts.Requests.Commands;

public record struct DeleteTransactionCommand(Guid Id) : ICommand<Result>;
