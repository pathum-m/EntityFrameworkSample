internal class PropertyValidation : Entity
{
    public int? NotRequiredProperty { get; private set; }

    public string LongTextProperty { get; private set; }

    public string NonUnicodeTextProperty { get; set; }

    public PropertyValidation(int? notRequiredProperty, string longTextProperty, string nonUnicodeTextProperty)
        => (Id, NotRequiredProperty, LongTextProperty, NonUnicodeTextProperty) = (default, notRequiredProperty, longTextProperty, nonUnicodeTextProperty);
}

internal class PropertiesEntityTypeConfiguration : IEntityTypeConfiguration<PropertyValidation>
{
    public void Configure(EntityTypeBuilder<PropertyValidation> builder)
    {
        builder.ToTable("PropertyValidationEntities");

        builder.Property(e => e.NotRequiredProperty)
            .IsRequired(); // Has no effect

        builder.Property(e => e.LongTextProperty)
            .HasMaxLength(3); // Has no effect

        builder.Property(e => e.NonUnicodeTextProperty)
            .IsUnicode(); // Has no effect
    }
}
