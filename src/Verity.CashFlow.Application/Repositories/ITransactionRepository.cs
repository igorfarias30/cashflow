using Verity.CashFlow.Contracts.DTOs;

namespace Verity.CashFlow.Application.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    BalanceDetailsDto GetBalanceDetailsByDate(DateOnly date);
}
