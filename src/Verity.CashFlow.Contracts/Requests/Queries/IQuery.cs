using MediatR;

namespace Verity.CashFlow.Contracts.Requests.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

