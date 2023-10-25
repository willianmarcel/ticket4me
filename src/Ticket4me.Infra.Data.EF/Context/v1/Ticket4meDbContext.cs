using Microsoft.EntityFrameworkCore;
using Ticket4me.Domain.Entities;
using Ticket4me.Infra.Data.EF.Configurations.v1;

namespace Ticket4me.Infra.Data.EF.Context.v1;
public class Ticket4meDbContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();

    public Ticket4meDbContext(DbContextOptions<Ticket4meDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryConfiguration());
    }
}
