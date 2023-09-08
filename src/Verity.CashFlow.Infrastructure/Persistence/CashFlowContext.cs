using System.Transactions;

namespace Verity.CashFlow.Infrastructure.Persistence;

public class CashFlowContext : DbContext
{
    public CashFlowContext(DbContextOptions<CashFlowContext> options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CashFlowContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
