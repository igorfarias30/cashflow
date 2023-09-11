using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Verity.CashFlow.Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    public Repository(CashFlowContext context)
    {
        Context = context;
        CurrentSet = Context.Set<TEntity>();
    }

    protected CashFlowContext Context { get; }
    protected DbSet<TEntity> CurrentSet { get; }

    public delegate void BeforeChangeDelegate(ref EntityEntry<TEntity> entity);

    protected event BeforeChangeDelegate BeforeUpdate;

    public TEntity? GetById(Guid id, bool asNoTracking = false)
    {
        if (asNoTracking)
            return CurrentSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

        return CurrentSet.FirstOrDefault(x => x.Id == id);
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        => CurrentSet.FirstOrDefault(filter);

    public Guid Insert(TEntity entity)
    {
        CurrentSet.Add(entity);
        Context.SaveChanges();
        return entity.Id;
    }

    public async Task SaveChangesAsync()
        => await Context.SaveChangesAsync();

    public void Update(TEntity entity)
    {
        var entityEntry = Context.Entry(entity);
        entityEntry.State = EntityState.Modified;
        Context.SaveChanges();
    }

    public void Remove(TEntity entity)
    {
        Context.Remove(entity);
        Context.SaveChanges();
    }
}
