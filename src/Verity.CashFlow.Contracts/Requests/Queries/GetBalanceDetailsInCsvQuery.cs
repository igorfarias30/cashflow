using OperationResult;
using Verity.CashFlow.Contracts.ViewModels;

namespace Verity.CashFlow.Contracts.Requests.Queries;

public record struct GetBalanceDetailsInCsvQuery(DateOnly Date) : IQuery<Result<FileViewModel>>;
