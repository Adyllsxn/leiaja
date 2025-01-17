namespace LeiaJa.Infrastructure.EntityConfiguration;
public class ProviciaConfiguration : IEntityTypeConfiguration<ProvinciaEntity>
{
    public void Configure(EntityTypeBuilder<ProvinciaEntity> builder)
    {
        builder.ToTable("TBL_PROVINCIA");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Provincia).
                IsRequired(true).
                HasColumnType("NVACHAR").
                HasMaxLength(30);
        builder.HasData(
            new ProvinciaEntity(1, "Bengo"),
            new ProvinciaEntity(2, "Benguela"),
            new ProvinciaEntity(3, "Luanda")
        );
    }
}
