namespace LeiaJa.Infrastructure.EntityConfiguration;
public class TipoUsuarioConfiguration : IEntityTypeConfiguration<TipoUsuarioEntity>
{
    public void Configure(EntityTypeBuilder<TipoUsuarioEntity> builder)
    {
        builder.ToTable("TBL_TIPOUSUARIO");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TipoUsuario).
                IsRequired(true).
                HasColumnType("NVACHAR").
                HasMaxLength(30);
        builder.HasData(
            new TipoUsuarioEntity(1, "Adm"),
            new TipoUsuarioEntity(2, "Cliente"),
            new TipoUsuarioEntity(3, "Funcionário")
        );
    }
}
