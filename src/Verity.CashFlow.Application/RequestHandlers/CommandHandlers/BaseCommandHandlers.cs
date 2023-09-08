namespace Verity.CashFlow.Application.RequestHandlers.CommandHandlers;

internal abstract class BaseCommandHandlers<TRequest, TResponse> : BaseRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected BaseCommandHandlers()
    {
    }
}
