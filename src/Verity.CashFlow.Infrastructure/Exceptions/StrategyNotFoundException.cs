namespace Verity.CashFlow.Infrastructure.Exceptions;

public class StrategyNotFoundException : Exception
{
    public StrategyNotFoundException(string kind)
        : base($"strategy to {kind} not found")
    {
    }
}
