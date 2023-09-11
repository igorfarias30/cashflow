using MediatR;
using Microsoft.AspNetCore.Mvc;
using Verity.CashFlow.Contracts.Requests.Commands;
using Verity.CashFlow.Contracts.Requests.Queries;

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

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] DateTime date)
        => await SendRequest(new GetTransactionQuery(DateOnly.FromDateTime(date)));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTransactionCommand command)
        => await SendRequest(command);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
        => await SendRequest(new DeleteTransactionCommand(Guid.Parse(id)));
}
