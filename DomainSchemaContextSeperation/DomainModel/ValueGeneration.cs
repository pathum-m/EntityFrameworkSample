using Microsoft.EntityFrameworkCore.Metadata;

internal class ValueGeneration : Entity
{
    public int ValueGenerationOnAddOrUpdateProperty { get; set; }
}

internal class ValueGenerationEntitiyTypeConfiguration : IEntityTypeConfiguration<ValueGeneration>
{
    public void Configure(EntityTypeBuilder<ValueGeneration> builder)
    {
        builder.ToTable("ValueGenerationEntities");

        builder.Property(e => e.ValueGenerationOnAddOrUpdateProperty)
            .ValueGeneratedOnAddOrUpdate();
    }
}

internal class ValueGenerationDefaultValue : Entity
{
    public int DefaultValueProperty { get; set; }
}

internal class ValueGenerationDefaultValueEntitiyTypeConfiguration : IEntityTypeConfiguration<ValueGenerationDefaultValue>
{
    public void Configure(EntityTypeBuilder<ValueGenerationDefaultValue> builder)
    {
        builder.ToTable("ValueGenerationDefaultValueEntities");

        builder.Property(e => e.DefaultValueProperty)
            .HasDefaultValue();
    }
}