namespace Relationships;

internal class OneToManyPrincipal : Entity
{
    public int P { get; set; }

    public List<OneToManyDependant> Dependants { get; set; } = new();

    public OneToManyDependant AddDependant(OneToManyDependant dependant)
    {
        Dependants.Add(dependant);

        return dependant;
    }

    public OneToManyDependant? RemoveDependant(int id)
    {
        var d = Dependants.Find(d => d.Id == id);
        if (d != null)
        { 
            Dependants.Remove(d);
        }

        return d;
    }
}

internal class OneToManyPrincipalEntityTypeConfiguration : IEntityTypeConfiguration<OneToManyPrincipal>
{
    public void Configure(EntityTypeBuilder<OneToManyPrincipal> builder)
    {
        builder.ToTable("Relationships.OneToMany.Principals");

        builder.HasMany(p => p.Dependants)
            .WithOne()
            .HasForeignKey("PrincipalId")
            .HasPrincipalKey(p => p.Id)
            .IsRequired();
    }
}