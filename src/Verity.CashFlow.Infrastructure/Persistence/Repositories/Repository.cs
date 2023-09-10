using AutoMapper;

namespace Verity.CashFlow.Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    public Repository(CashFlowContext context, IMapper mapper)
    {
        Context = context;
        CurrentSet = Context.Set<TEntity>();
        MapperConfigProvider = mapper.ConfigurationProvider;
    }


    protected CashFlowContext Context { get; }
    protected DbSet<TEntity> CurrentSet { get; }
    protected AutoMapper.IConfigurationProvider MapperConfigProvider { get; }

    public TEntity? GetById(Guid id)
        => CurrentSet.FirstOrDefault(x => x.Id == id);

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
        Context.SaveChanges();
    }
}
