namespace Relationships;

internal class OneToManyDependant : Entity
{
    public int P { get; set; }

    public OneToManyPrincipal Principal { get; set; }
    public int PrincipalId { get; set; }
}

internal class OneToManyDependantEntityTypeConfiguration : IEntityTypeConfiguration<OneToManyDependant>
{
    public void Configure(EntityTypeBuilder<OneToManyDependant> builder)
    {
        builder.ToTable("Relationships.OneToMany.Dependants");
    }
}