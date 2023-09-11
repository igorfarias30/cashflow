using Verity.CashFlow.Application.Services;

namespace Verity.CashFlow.Api.Controllers;

[Route("api/[controller]")]
public class TransactionController : CashFlowBaseController
{
    private readonly ICashFlowService _cashFlowService;
    public TransactionController(ISender mediator, ILogger logger, ICashFlowService cashFlowService) : base(mediator, logger)
    {
        _cashFlowService = cashFlowService;
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
    public async Task<IActionResult> Delete(long id)
        => await SendRequest(new DeleteTransactionCommand(id));

    [HttpDelete("test")]
    public async Task<IActionResult> Test()
    {
        await _cashFlowService.CloseCash();
        return Ok();
    }
}
