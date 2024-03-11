using Api.Storage.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Storage;

public class UnitOfWork<TContext> : IUnitOfWork where TContext : EntityContext<TContext>
{
    private DbContext Context { get; set; }

    public UnitOfWork(IDbContextFactory<TContext> factory)
    {
        Context = factory.CreateDbContext();
    }

    public bool Connect() => Context.Database.CanConnect();
    public void Migrate() => Context.Database.Migrate();
    public void Dispose() => Context.Dispose();
    
}
