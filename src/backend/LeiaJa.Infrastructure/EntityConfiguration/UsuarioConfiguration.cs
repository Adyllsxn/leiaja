namespace LeiaJa.Infrastructure.EntityConfiguration;
public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
    {
        builder.ToTable("TBL_USUARIO");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).
                IsRequired(true).
                HasColumnType("NVACHAR").
                HasMaxLength(50);
        builder.Property(x => x.SobreNome).
                IsRequired(true).
                HasColumnType("NVACHAR").
                HasMaxLength(50);
        builder.Property(x => x.Email).
                IsRequired(true).
                HasColumnType("NVACHAR").
                HasMaxLength(200);
        builder.Property(x => x.GeneroId).
                IsRequired(true);
        builder.Property(x => x.TipoUsuarioId).
                IsRequired(true);
        builder.Property(x => x.MunicipioId).
                IsRequired(true);
                
        builder.HasOne(x => x.Genero).WithMany(x => x.Usuarios).HasForeignKey(x => x.GeneroId).HasConstraintName("FKGeneroUsuario").OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.TipoUsuario).WithMany(x => x.Usuarios).HasForeignKey(x => x.TipoUsuarioId).HasConstraintName("FKTipoUsuarioUsuario").OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Municipio).WithMany(x => x.Usuarios).HasForeignKey(x => x.MunicipioId).HasConstraintName("FKMunicipioUsuario").OnDelete(DeleteBehavior.Cascade);
    }
}
