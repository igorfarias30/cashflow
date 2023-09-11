using Verity.CashFlow.Contracts.DTOs;

namespace Verity.CashFlow.Application.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    Task<BalanceDetailsDto?> GetBalanceDetailsByDate(DateOnly date);
    IQueryable<Cash> GetCashByDate(DateOnly date);
    IQueryable<Transaction> GetAllByDate(DateOnly date);
}
