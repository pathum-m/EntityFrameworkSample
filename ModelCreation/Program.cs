public static class Program
{
    public static void Main(string[] args)
    {
        new ModelCreationDbContext().Database.EnsureDeleted();
        new ModelCreationDbContext().Database.EnsureCreated();
    }
}
