using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Relationships;

public class OneToManyRelationshipsTests : IClassFixture<TestDbFixture>
{
    private readonly TestDbFixture _fixture;

    public OneToManyRelationshipsTests(TestDbFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    void CreateGraph()
    {
        var context = _fixture.CreateContext();

        OneToManyPrincipal p = new() { P = 2 };

        OneToManyDependant d1 = new() { P = 3 };
        OneToManyDependant d2 = new() { P = 4 };
        p.Dependants.Add(d1);
        p.Dependants.Add(d2);

        context.Add(p);

        context.Database.BeginTransaction();
        context.SaveChanges();
    }

    [Fact]
    void AddChild()
    {
        using var context = _fixture.CreateContext();

        OneToManyPrincipal p = new() 
        { 
            P = 2,
            Dependants = new() { new() { P = 3 } }
        };

        context.Add(p);

        var transaction = context.Database.BeginTransaction();
        context.SaveChanges();

        using var context2 = _fixture.CreateContext(context.Database.GetDbConnection());
        context2.Database.UseTransaction(transaction.GetDbTransaction());

        var p2 = context2.Find<OneToManyPrincipal>(1);

        p2?.AddDependant(new OneToManyDependant { P = 4 });
        context2.SaveChanges();
    }

    [Fact]
    void RemoveChild_ByLoadAll()
    {
        using var context = _fixture.CreateContext();

        OneToManyPrincipal p = new() 
        { 
            P = 2,
            Dependants = new() 
            { 
                new() { P = 3 }, 
                new() { P = 4 }, 
                new() { P = 5 }
            }
        };

        context.Add(p);

        var transaction = context.Database.BeginTransaction();
        context.SaveChanges();

        using var context2 = _fixture.CreateContext(context.Database.GetDbConnection());
        context2.Database.UseTransaction(transaction.GetDbTransaction());

        var p2 = context2.Find<OneToManyPrincipal>(1);

        // Required to load all child entities to delete a child entity.
        context2.Entry(p2!).Collection(p => p.Dependants).Load();

        p2!.RemoveDependant(1);

        context2.SaveChanges();
    }

    [Fact]
    void RemoveChild_ByRemovingFromContext()
    {
        using var context = _fixture.CreateContext();

        OneToManyPrincipal p = new()
        {
            P = 2,
            Dependants = new()
            {
                new() { P = 3 },
                new() { P = 4 },
                new() { P = 5 }
            }
        };

        context.Add(p);

        var transaction = context.Database.BeginTransaction();
        context.SaveChanges();

        using var context2 = _fixture.CreateContext(context.Database.GetDbConnection());
        context2.Database.UseTransaction(transaction.GetDbTransaction());

        var p2 = context2.Find<OneToManyPrincipal>(1);

        // Load entity to context
        context2.Find<OneToManyDependant>(1);

        var d = p2!.RemoveDependant(1);

        if (d != null)
        { 
            context2.Remove(d);
        }

        context2.SaveChanges();
    }
}