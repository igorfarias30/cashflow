using OperationResult;

namespace Verity.CashFlow.Contracts.Requests.Commands;

public record struct DeleteTransactionCommand(long Id) : ICommand<Result>;
