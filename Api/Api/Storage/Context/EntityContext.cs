using Microsoft.EntityFrameworkCore;

namespace Api.Storage.Context;

public abstract class EntityContext<TContext> : DbContext where TContext : EntityContext<TContext>
{
    public EntityContext(DbContextOptions<TContext> options) : base(options) { }
    
    public void Migrate() => Database.Migrate();
}