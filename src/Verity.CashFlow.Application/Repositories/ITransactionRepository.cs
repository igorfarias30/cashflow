using Verity.CashFlow.Contracts.DTOs;

namespace Verity.CashFlow.Application.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    Task<BalanceDetailsDto?> GetBalanceDetailsByDate(DateOnly date);
    Task<Cash> GetCashByDate(DateOnly date);
    IQueryable<Transaction> GetAllTransactionsByDate(DateOnly date);
}
