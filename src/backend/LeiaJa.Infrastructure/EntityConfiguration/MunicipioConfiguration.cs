namespace LeiaJa.Infrastructure.EntityConfiguration;
public class MunicipioConfiguration : IEntityTypeConfiguration<MunicipioEntity>
{
    public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
    {
        builder.ToTable("TBL_MUNICIPIO");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Municipio).
                IsRequired(true).
                HasColumnType("NVACHAR").
                HasMaxLength(30);
        builder.Property(x => x.ProvinciaId).
                IsRequired(true);
        builder.HasData(
            new MunicipioEntity(1, "Viana", 3),
            new MunicipioEntity(2, "Lobito", 2)
        );
        
        builder.HasOne(x => x.Provincia).WithMany(x => x.Municipios).HasForeignKey(x => x.ProvinciaId).HasConstraintName("FKProvinciaMunicipio").OnDelete(DeleteBehavior.Cascade);
    }
}
