using OperationResult;

namespace Verity.CashFlow.Infrastructure.Services;

public class CashFlowService : ICashFlowService
{
    private ITransactionRepository _transactionRepository;
    private IRepository<Cash> _cashRepository;
    private IMapper _mapper;

    public CashFlowService(ITransactionRepository transactionRepository, IMapper mapper, IRepository<Cash> cashRepository)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
        _cashRepository = cashRepository;
    }

    public async Task<Result> CloseCash()
    {
        var cashOfTheDay = await _transactionRepository
            //.GetCashByDate(DateOnly.FromDateTime(DateTime.Now));
            .GetCashByDate(DateOnly.Parse("2023-09-09"));

        var cashDetails = _mapper.Map<BalanceDetailsDto>(cashOfTheDay);

        var closedCashOfTheDay = cashOfTheDay.StartBalanceInCents + (cashDetails.IncomeInCents - cashDetails.OutcomeInCents);

        cashOfTheDay.SetClosedBalanceInCents(closedCashOfTheDay);
        cashOfTheDay.CloseCash();

        _cashRepository.Update(cashOfTheDay);

        var cashOfNextDay = Cash.Create(cashOfTheDay.DateOfCash.AddDays(1), closedCashOfTheDay, null);

        _cashRepository.Insert(cashOfNextDay);

        await _transactionRepository.SaveChangesAsync();

        return Result.Success();
    }
}
