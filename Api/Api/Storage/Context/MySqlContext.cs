using Microsoft.EntityFrameworkCore;

namespace Api.Storage.Context;

public class MySqlContext : EntityContext<MySqlContext>
{  
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
}