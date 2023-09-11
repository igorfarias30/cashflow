namespace Verity.CashFlow.Application.RequestHandlers.QueryHandlers;

public class GetBalanceDetailsInCsvQueryHandler : BaseQueryHandler<GetBalanceDetailsInCsvQuery, Result<FileViewModel>>
{
    private readonly IDataExporterStrategyService _strategyService;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetBalanceDetailsInCsvQueryHandler(IDataExporterStrategyService strategyService, ITransactionRepository transactionRepository, IMapper mapper)
    {
        _strategyService = strategyService;
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public override async Task<Result<FileViewModel>> Handle(GetBalanceDetailsInCsvQuery request, CancellationToken cancellationToken)
    {
        var (isSuccess, strategy, exception) = _strategyService.Get(FileKind.Csv);
        if (!isSuccess)
            return exception!;

        var transactions = _mapper
            .Map<IEnumerable<TransactionViewModel>>(_transactionRepository.GetAllTransactionsByDate(request.Date));

        var fileName = $"cash-flow-transactions_{request.Date}.csv";
        var fileStream = strategy!.Export(transactions);

        return Result.Success(new FileViewModel(fileName, "application/csv", fileStream.ToArray()));
    }
}
