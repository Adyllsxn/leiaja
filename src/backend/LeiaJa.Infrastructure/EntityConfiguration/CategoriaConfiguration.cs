namespace LeiaJa.Infrastructure.EntityConfiguration;
public class CategoriaConfiguration : IEntityTypeConfiguration<CategoriaEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
    {
        builder.ToTable("TBL_CATEGORIA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Categoria).
                    IsRequired(true).
                    HasMaxLength(50).
                    HasColumnType("VARCHAR");
            builder.HasData(
                new CategoriaEntity(1, "Comédia")
            );
    }
}
