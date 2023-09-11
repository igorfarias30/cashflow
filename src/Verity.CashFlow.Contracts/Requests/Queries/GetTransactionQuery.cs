using OperationResult;
using Verity.CashFlow.Contracts.ViewModels;

namespace Verity.CashFlow.Contracts.Requests.Queries;

public record struct GetTransactionQuery(DateOnly date) : IQuery<Result<IQueryable<TransactionViewModel>>>;
