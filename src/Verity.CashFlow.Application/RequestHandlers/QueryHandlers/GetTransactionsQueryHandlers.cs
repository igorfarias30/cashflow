using Verity.CashFlow.Contracts.ViewModels;

namespace Verity.CashFlow.Application.RequestHandlers.QueryHandlers;

public class GetTransactionsQueryHandler : BaseQueryHandler<GetTransactionQuery, Result<TransactionViewModel>>
{
    public override async Task<Result<TransactionViewModel>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        return Result.Success(new TransactionViewModel { Id = "test"});
    }
}
