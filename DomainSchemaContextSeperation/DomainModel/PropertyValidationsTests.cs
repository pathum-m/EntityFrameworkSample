[Collection("Default")]
public class PropertyValidationsTests : IClassFixture<TestDbFixture>
{
    private readonly TestDbFixture _fixture;

    public PropertyValidationsTests(TestDbFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void NoIsRequiredValidation()
    {
        using var context = _fixture.CreateContext();

        context.Database.BeginTransaction();

        context.Set<PropertyValidation>().Add(new PropertyValidation(null, "", "A"));
        context.SaveChanges();

        var count = context.Set<PropertyValidation>().Count();

        Assert.Equal(1, count);
    }

    [Fact]
    public void NoMaxLengthValidation()
    {
        using var context = _fixture.CreateContext();

        context.Database.BeginTransaction();

        context.Set<PropertyValidation>().Add(new PropertyValidation(1, "ABCD", "A"));
        context.SaveChanges();

        var count = context.Set<PropertyValidation>().Count();

        Assert.Equal(1, count);
    }

    [Fact]
    public void NoUnicodeValidation()
    {
        using var context = _fixture.CreateContext();

        context.Database.BeginTransaction();

        context.Set<PropertyValidation>().Add(new PropertyValidation(1, "ABCD", "ひ"));
        context.SaveChanges();

        var count = context.Set<PropertyValidation>().Count();

        Assert.Equal(1, count);
    }
}