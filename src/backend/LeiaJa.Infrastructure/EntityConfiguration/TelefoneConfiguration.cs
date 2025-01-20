
namespace LeiaJa.Infrastructure.EntityConfiguration;
public class TelefoneConfiguration : IEntityTypeConfiguration<TelefoneEntity>
{
    public void Configure(EntityTypeBuilder<TelefoneEntity> builder)
    {
        builder.ToTable("TBL_TELEFONE");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Telefone).
                IsRequired(true).
                HasColumnType("NVACHAR").
                HasMaxLength(9);
        builder.Property(x => x.TipoTelefoneId).
                IsRequired(true);
        builder.Property(x => x.UsuarioId).
                IsRequired(true);
        
        builder.HasOne(x => x.TipoTelefone).WithMany(x => x.Telefones).HasForeignKey(x => x.TipoTelefoneId).HasConstraintName("FKTipoTelefoneTelefone").OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Usuario).WithMany(x => x.Telefones).HasForeignKey(x => x.UsuarioId).HasConstraintName("FKUsuarioTelefone").OnDelete(DeleteBehavior.Cascade);
    }
}
