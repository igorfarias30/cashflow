using MediatR;

namespace Verity.CashFlow.Contracts.Requests.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
