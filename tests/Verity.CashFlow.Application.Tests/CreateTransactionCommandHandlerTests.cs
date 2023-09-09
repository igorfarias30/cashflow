namespace Verity.CashFlow.Application.Tests;

public class CreateTransactionCommandHandlerTests
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly CreateTransactionCommandHandlers _sut;

    public CreateTransactionCommandHandlerTests()
    {
        _transactionRepository = Substitute.For<ITransactionRepository>();
        _sut = new(_transactionRepository);
    }

    [Fact]
    public async Task GivenCreateTransactionCommand_WhenCallHandle_ThenTransactionShouldBeCreated()
    {
        // Arrange
        var command = new CreateTransactionCommand(
            new DateOnly(),
            1000,
            "Selling 100 pepeers",
            TransactionType.Income,
            TransactionStatus.Payed,
            null
        );

        // Act

        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        result
            .IsSuccess
            .Should()
            .BeTrue();
    }
}