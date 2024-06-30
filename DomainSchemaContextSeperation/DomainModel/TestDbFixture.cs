public class TestDbFixture
{
    private const string connectionString = @"Data Source=.;Initial Catalog=EF.KB.DomainSchemaContextSeperation;Integrated Security=True;TrustServerCertificate=True;";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDbFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                // Db creation and seeding
                _databaseInitialized = true;
            }
        }
    }

    public DomainContext CreateContext()
        => new DomainContext(
            new DbContextOptionsBuilder<DomainContext>()
                .UseSqlServer(connectionString)
                .Options);
}
