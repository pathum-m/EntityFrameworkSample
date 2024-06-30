namespace Relationships;

internal class ManyToManyPrincipal2 : Entity
{
    public int P { get; set; }

    public List<ManyToManyPrincipal1> Principal1s { get; set; } = new();
}

internal class ManyToManyPrincipal2EntityTypeConfiguration : IEntityTypeConfiguration<ManyToManyPrincipal2>
{
    public void Configure(EntityTypeBuilder<ManyToManyPrincipal2> builder)
    {
        builder.ToTable("Relationships.ManyToMany.Principal2s");
    }
}