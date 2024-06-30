internal class PropertyValidation
{
    public int Id { get; set; }

    public int? NotRequiredProperty { get; set; }

    public string LongTextProperty { get; set; }

    public string NonUnicodeTextProperty { get; set; }
}

internal class PropertiesEntityTypeConfiguration : IEntityTypeConfiguration<PropertyValidation>
{
    public void Configure(EntityTypeBuilder<PropertyValidation> builder)
    {
        builder.ToTable("PropertyValidationEntities");

        builder.Property(e => e.NonUnicodeTextProperty)
            .IsUnicode(false);
    }
}
