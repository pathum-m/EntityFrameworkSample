using System.Data.Common;

public class TestDbFixture
{
    private const string connectionString = @"Data Source=.;Initial Catalog=EF.KB.Saving;Integrated Security=True;TrustServerCertificate=True;";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDbFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                var context = CreateContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                _databaseInitialized = true;
            }
        }
    }

    public SavingDbContext CreateContext()
        => new SavingDbContext(
            new DbContextOptionsBuilder<SavingDbContext>()
                .UseSqlServer(connectionString)
                .Options);

    public SavingDbContext CreateContext(DbConnection connection)
        => new SavingDbContext(
            new DbContextOptionsBuilder<SavingDbContext>()
                .UseSqlServer(connection)
                .Options);
}
