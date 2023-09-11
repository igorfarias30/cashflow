using MapsterMapper;

namespace Verity.CashFlow.Application.RequestHandlers.CommandHandlers;

internal class UpdateTransactionCommandHandler : BaseCommandHandlers<UpdateTransactionCommand, Result<TransactionViewModel>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public override Task<Result<TransactionViewModel>> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var oldTransaction = _transactionRepository.GetById(Guid.Parse(request.Id), asNoTracking: true);

        if (oldTransaction is null)
            return Result.Error<TransactionViewModel>(new Exception($"transaction {request.Id} not found"));

        var updatedTransaction = Transaction.Create(
            oldTransaction.Id,
            oldTransaction.CashId,
            request.TransactionDate,
            request.AmountInCents,
            request.Description,
            request.Type,
            request.Status,
            request.Comment
        );

        _transactionRepository.Update(updatedTransaction);

        return Result.Success(_mapper.Map<TransactionViewModel>(updatedTransaction));
    }
}
