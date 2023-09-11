namespace Verity.CashFlow.Application.RequestHandlers.CommandHandlers;

public class CreateTransactionCommandHandlers : BaseCommandHandlers<CreateTransactionCommand, Result<TransactionViewModel>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IRepository<Cash> _cashRepository;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandlers(ITransactionRepository transactionRepository, IMapper mapper, IRepository<Cash> cashRepository)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
        _cashRepository = cashRepository;
    }

    public override async Task<Result<TransactionViewModel>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var cash = _cashRepository.Get(cash => cash.DateOfCash == request.TransactionDate, asNoTracking: true);

        if (cash is null)
            return Result.Error<TransactionViewModel>(new Exception("Cash of the date of transaction is not created yet"));

        var transaction = Transaction
            .Create(
                cash.Id,
                request.TransactionDate,
                request.AmountInCents,
                request.Description,
                request.Type,
                request.Status,
                request.Comment
            );

        _ = _transactionRepository.Insert(transaction);

        await _transactionRepository.SaveChangesAsync();

        return Result.Success(_mapper.Map<TransactionViewModel>(transaction));
    }
}
