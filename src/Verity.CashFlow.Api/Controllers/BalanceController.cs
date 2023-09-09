using MediatR;
using Microsoft.AspNetCore.Mvc;
using Verity.CashFlow.Contracts.Requests.Queries;

namespace Verity.CashFlow.Api.Controllers;

[Route("api/[controller]")]
public class BalanceController : CashFlowBaseController
{
    public BalanceController(ISender mediator) : base(mediator)
    {
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] DateTime dateFilter)
    {
        var dateFilterAsDateOnly = DateOnly.FromDateTime(dateFilter);
        return await SendRequest(new GetBalanceDetailsQuery(dateFilterAsDateOnly));
    }
}
