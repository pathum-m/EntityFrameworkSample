public class SavingDbContext : DbContext
{
    public SavingDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(SavingDbContext).Assembly);
    }
}
