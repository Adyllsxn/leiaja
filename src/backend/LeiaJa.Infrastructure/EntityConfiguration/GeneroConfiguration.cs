namespace LeiaJa.Infrastructure.EntityConfiguration;
public class GeneroConfiguration : IEntityTypeConfiguration<GeneroEntity>
{
    public void Configure(EntityTypeBuilder<GeneroEntity> builder)
    {
        builder.ToTable("TBL_GENERO");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Genero).
                IsRequired(true).
                HasColumnType("NVACHAR").
                HasMaxLength(25);
        builder.HasData(
            new GeneroEntity(1, "Masculino"),
            new GeneroEntity(2, "Femenino")
        );
    }
}
