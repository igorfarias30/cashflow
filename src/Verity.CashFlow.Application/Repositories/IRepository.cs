using System.Linq.Expressions;
using Verity.CashFlow.Domain.Primitives;
namespace Verity.CashFlow.Application.Repositories;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    TEntity? Get(Expression<Func<TEntity, bool>> expression);
    TEntity? GetById(Guid id);
    Guid Insert(TEntity entity);
    void Update(TEntity entity);
    Task SaveChangesAsync();
}
