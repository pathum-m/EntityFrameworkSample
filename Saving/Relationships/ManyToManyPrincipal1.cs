namespace Relationships;

internal class ManyToManyPrincipal1 : Entity
{
    public int P { get; set; }

    public List<ManyToManyPrincipal2> Principal2s { get; set; } = new();
}

internal class ManyToManyPrincipal1EntityTypeConfiguration : IEntityTypeConfiguration<ManyToManyPrincipal1>
{
    public void Configure(EntityTypeBuilder<ManyToManyPrincipal1> builder)
    {
        builder.ToTable("Relationships.ManyToMany.Principal1s");

        builder.HasMany(p1 => p1.Principal2s)
            .WithMany(p2 => p2.Principal1s)
            .UsingEntity("Relationships.ManyToMany.Principal1Principal2s");
    }
}