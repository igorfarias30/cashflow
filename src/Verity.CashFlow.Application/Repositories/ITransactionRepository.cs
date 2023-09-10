using Verity.CashFlow.Contracts.DTOs;

namespace Verity.CashFlow.Application.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    IQueryable<BalanceDetailsDto> GetBalanceDetailsByDate(DateOnly date);
}
