namespace Verity.CashFlow.Api.Controllers;

[Route("api/[controller]")]
public class TransactionController : CashFlowBaseController
{
    private readonly ICashFlowService _cashFlowService;
    public TransactionController(ISender mediator, ILogger logger, ICashFlowService cashFlowService) : base(mediator, logger)
    {
        _cashFlowService = cashFlowService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TransactionViewModel), 201)]
    public async Task<IActionResult> Create(CreateTransactionCommand command)
        => await SendRequest(command, 201);

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TransactionViewModel>), 200)]
    public async Task<IActionResult> GetAll([FromQuery] DateTime date)
        => await SendRequest(new GetTransactionQuery(DateOnly.FromDateTime(date)));

    [HttpPut]
    [ProducesResponseType(typeof(TransactionViewModel), 200)]
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
