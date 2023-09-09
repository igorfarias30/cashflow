namespace Verity.CashFlow.Application.RequestHandlers.QueryHandlers;

public class GetTransactionsQueryHandler : BaseQueryHandler<GetTransactionQuery, Result>
{
    public override Task<Result> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
