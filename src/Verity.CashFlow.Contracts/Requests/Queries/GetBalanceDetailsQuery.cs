using OperationResult;
using Verity.CashFlow.Contracts.ViewModels;

namespace Verity.CashFlow.Contracts.Requests.Queries;

public record struct GetBalanceDetailsQuery(DateOnly DateOfCash) : IQuery<Result<BalanceDetailsViewModel>>;
