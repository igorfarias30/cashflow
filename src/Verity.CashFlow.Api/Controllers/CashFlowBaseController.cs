using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationResult;

namespace Verity.CashFlow.Api.Controllers;

[ApiController]
public class CashFlowBaseController : ControllerBase
{
    protected ISender Mediator { get;}

    public CashFlowBaseController(ISender mediator)
    {
        Mediator = mediator;
    }

    protected async Task<IActionResult> SendRequest<T>(IRequest<Result<T>> request, int statusCode = StatusCodes.Status200OK)
    {
        return await Mediator.Send(request).ConfigureAwait(false) switch
        {
            (true, var result, _) => StatusCode(statusCode, result),
            var (_, _, error) => HandleError(request, error)
        };
    }

    protected async Task<IActionResult> SendRequest(IRequest<Result> request, int statusCode = StatusCodes.Status200OK)
    {
        return await Mediator.Send(request).ConfigureAwait(false) switch
        {
            (true, _) => StatusCode(statusCode),
            var (_, error) => HandleError(request, error)
        };
    }

    protected async Task<IActionResult> SendRequest<T>(IRequest<Result<T>> request, Func<T?, IActionResult> onSuccess)
    {
        return await Mediator.Send(request).ConfigureAwait(false) switch
        {
            (true, var result, _) => onSuccess(result),
            var (_, _, error) => HandleError(request, error)
        };
    }

    protected ActionResult HandleError(object? request, Exception? error)
    {
        var actionResult = error switch
        {
            _ => StatusCode(500)
        };

        return actionResult;
    }
}
