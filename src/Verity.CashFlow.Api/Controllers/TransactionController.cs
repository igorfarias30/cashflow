using MediatR;
using Microsoft.AspNetCore.Mvc;
using Verity.CashFlow.Contracts.Requests.Commands;

namespace Verity.CashFlow.Api.Controllers;

[Route("api/[controller]")]
public class TransactionController : CashFlowBaseController
{
    public TransactionController(ISender mediator) : base(mediator)
    {
    }

    [HttpPost("new")]
    public async Task<IActionResult> Create(CreateTransactionCommand command)
        => await SendRequest(command);
}
