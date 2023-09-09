namespace Verity.CashFlow.Application.RequestHandlers.CommandHandlers;

public abstract class BaseCommandHandlers<TRequest, TResponse> : BaseRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected BaseCommandHandlers()
    {
    }
}
