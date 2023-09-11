namespace Verity.CashFlow.Application.Tests.RequestHandlers.Queries;

public class GetBalanceDetailsInCsvQueryHandlerTests
{
    private readonly IDataExporterStrategyService _strategyService;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;
    private readonly GetBalanceDetailsInCsvQueryHandler _sut;

    public GetBalanceDetailsInCsvQueryHandlerTests()
    {
        _strategyService = Substitute.For<IDataExporterStrategyService>();
        _transactionRepository = Substitute.For<ITransactionRepository>();
        _mapper = Substitute.For<IMapper>();
        _sut = new(_strategyService, _transactionRepository, _mapper);
    }

    [Fact]
    public async Task GivenGetBalanceDetailsInCsvQuery_WhenCallHandle_ThenMemoryStreamShouldBeReturned()
    {
        // Arrange
        var dateOfCash = DateOnly.Parse("2023-09-11");
        var query = new GetBalanceDetailsInCsvQuery(dateOfCash);

        var csvStrategy = Substitute.For<IDataExporterByKindStrategy>();
        _strategyService
            .Get(FileKind.Csv)
            .Returns(Result.Success(csvStrategy));

        var transactions = new TransactionViewModel[] 
        {
            new TransactionViewModel(1L, "100 pepeers", 1000L, TransactionType.Income, TransactionStatus.Payed),
            new TransactionViewModel(2L, "200 pepeers", 2000L, TransactionType.Income, TransactionStatus.Payed),
            new TransactionViewModel(3L, "1 kg picanha", 8000L, TransactionType.Income, TransactionStatus.Payed),
        };

        _mapper
            .Map<IEnumerable<TransactionViewModel>>(Arg.Any<IQueryable<Transaction>>())
            .Returns(transactions);            
        
        var fileCsvStream = new MemoryStream(Encoding.UTF8.GetBytes("id, product, amount, income, payed"));
        csvStrategy
            .Export(transactions)
            .Returns(fileCsvStream);

        // Act
        var result = await _sut.Handle(query, CancellationToken.None);

        // Assert
        result
            .IsSuccess
            .Should()
            .BeTrue();
    }
}
