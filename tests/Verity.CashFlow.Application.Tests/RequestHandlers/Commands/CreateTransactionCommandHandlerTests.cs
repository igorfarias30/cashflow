namespace Verity.CashFlow.Application.Tests.RequestHandlers.Commands;

public class CreateTransactionCommandHandlerTests
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IRepository<Cash> _cashRepository;
    private readonly IMapper _mapper;
    private readonly CreateTransactionCommandHandler _sut;

    public CreateTransactionCommandHandlerTests()
    {
        _transactionRepository = Substitute.For<ITransactionRepository>();
        _cashRepository = Substitute.For<IRepository<Cash>>();
        _mapper = Substitute.For<IMapper>();
        _sut = new(_transactionRepository, _mapper, _cashRepository);
    }

    [Fact]
    public async Task GivenCreateTransactionCommand_WhenCallHandle_ThenTransactionShouldBeCreated()
    {
        // Arrange
        var dateOfCash = DateOnly.Parse("2023-09-11");
        var cash = Cash.Create(1L, dateOfCash, 10000, null);
        var transaction = Transaction.Create(1L, dateOfCash, 5000, "Test", TransactionType.Income, TransactionStatus.Payed, null);
        
        cash.AddTransaction(transaction);

        var command = new CreateTransactionCommand(
            dateOfCash,
            1000,
            "Selling 100 pepeers",
            TransactionType.Income,
            TransactionStatus.Payed,
            null
        );

        _cashRepository
            .Get(Arg.Any<Expression<Func<Cash, bool>>>(), true)
            .Returns(cash);

        _mapper
            .Map<TransactionViewModel>(Arg.Any<Transaction>())
            .Returns(new TransactionViewModel(1L, "Selling 100 pepeers", 1000L, TransactionType.Income, TransactionStatus.Payed));

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        result
            .IsSuccess
            .Should()
            .BeTrue();

        result
            .Value
            .Should()
            .BeOfType<TransactionViewModel>();
    }
}