namespace Verity.CashFlow.Application.RequestHandlers.CommandHandlers;

internal class DeleteTransactionCommandHandler : BaseCommandHandlers<DeleteTransactionCommand, Result>
{
    private ITransactionRepository _transactionRepository;

    public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public override Task<Result> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = _transactionRepository.GetById(request.Id, true);

        if (transaction is null)
            return Result.Error(new Exception($"transaction {request.Id} not found"));

        _transactionRepository.Remove(transaction);

        return Result.Success();
    }
}
