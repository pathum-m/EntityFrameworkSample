namespace Relationships;

internal class OneToManyPrincipal : Entity
{
    public int P { get; set; }

    public List<OneToManyDependant> Dependants { get; set; }
}

internal class OneToManyPrincipalEntityTypeConfiguration : IEntityTypeConfiguration<OneToManyPrincipal>
{
    public void Configure(EntityTypeBuilder<OneToManyPrincipal> builder)
    {
        builder.ToTable("Relationships.OneToMany.Principals");

        builder.HasMany(p => p.Dependants)
            .WithOne(d => d.Principal)
            .HasForeignKey(d => d.PrincipalId)
            .HasPrincipalKey(p => p.Id);
    }
}