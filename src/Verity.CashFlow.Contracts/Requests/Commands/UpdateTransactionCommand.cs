using OperationResult;
using Verity.CashFlow.Contracts.ViewModels;

namespace Verity.CashFlow.Contracts.Requests.Commands;

public record struct UpdateTransactionCommand : ICommand<Result<TransactionViewModel>>
{
}
