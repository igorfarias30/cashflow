namespace Verity.CashFlow.Application.RequestHandlers.CommandHandlers;

public class CreateTransactionCommandHandlers : BaseCommandHandlers<CreateTransactionCommand, Result>
{
    private readonly ITransactionRepository _transactionRepository;

    public CreateTransactionCommandHandlers(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public override async Task<Result> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = Transaction
            .Create(
                request.TransactionDate,
                request.AmountInCents,
                request.Description,
                request.Type,
                request.Comment
            );

        var id = _transactionRepository.Insert(transaction);

        await _transactionRepository.SaveChangesAsync();

        return Result.Success();
    }
}
