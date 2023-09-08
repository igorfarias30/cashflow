using OperationResult;
using Verity.CashFlow.Contracts.Requests.Queries;

namespace Verity.CashFlow.Application.RequestHandlers.QueryHandlers;

internal class GetTransactionsQueryHandler : BaseQueryHandler<GetTransactionQuery, Result>
{
    public override Task<Result> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
