namespace Verity.CashFlow.Api.Controllers;

[Route("api/[controller]")]
public class BalanceController : CashFlowBaseController
{
    public BalanceController(ISender mediator, ILogger logger) : base(mediator, logger)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(BalanceDetailsViewModel), 200)]
    public async Task<IActionResult> GetAll([FromQuery] DateTime dateFilter)
    {
        var dateFilterAsDateOnly = DateOnly.FromDateTime(dateFilter);
        return await SendRequest(new GetBalanceDetailsQuery(dateFilterAsDateOnly));
    }

    [HttpGet("export-csv")]
    public async Task<IActionResult> GetBalanceDetails(DateTime dateFilter)
        => await SendQueryAndReturnFile(new GetBalanceDetailsInCsvQuery(DateOnly.FromDateTime(dateFilter)));
}
