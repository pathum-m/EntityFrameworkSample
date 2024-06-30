public class ValueGenerationTests : IClassFixture<TestDbFixture>
{
    private readonly TestDbFixture _fixture;

    public ValueGenerationTests(TestDbFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    void IgnoreExplicitlySettedValueAndUseDatabaseGeneratedValue()
    {
        var context = _fixture.CreateContext();

        context.Database.BeginTransaction();

        context.Set<ValueGeneration>().Add(new ValueGeneration() { ValueGenerationOnAddOrUpdateProperty = 2 });

        context.SaveChanges();

        context.ChangeTracker.Clear();

        var added = context.Set<ValueGeneration>().First();

        Assert.Equal(5, added.ValueGenerationOnAddOrUpdateProperty); // 2 is ignored
    }

    [Fact]
    void DefaultValue()
    {
        var context = _fixture.CreateContext();

        context.Database.BeginTransaction();

        context.Set<ValueGenerationDefaultValue>().Add(new ValueGenerationDefaultValue());

        context.SaveChanges();

        context.ChangeTracker.Clear();

        var added = context.Set<ValueGenerationDefaultValue>().First();

        Assert.Equal(2, added.DefaultValueProperty);
    }
}