using Mapster;
using MapsterMapper;

namespace Verity.CashFlow.Application.RequestHandlers.QueryHandlers;

public class GetTransactionsQueryHandler : BaseQueryHandler<GetTransactionQuery, Result<IQueryable<TransactionViewModel>>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public override Task<Result<IQueryable<TransactionViewModel>>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        var transactions = _transactionRepository.GetAllByDate(request.date);
        return Result.Success(_mapper.From(transactions).ProjectToType<TransactionViewModel>());
    }
}
