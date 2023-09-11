namespace Verity.CashFlow.Application.Services;

public interface ICashFlowService
{
    Task<Result> CloseCash();
}
