namespace Verity.CashFlow.Application.Repositories;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    TEntity? GetById(Guid id, bool asNoTracking = false);
    TEntity? Get(Expression<Func<TEntity, bool>> expression);
    Guid Insert(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task SaveChangesAsync();
}
