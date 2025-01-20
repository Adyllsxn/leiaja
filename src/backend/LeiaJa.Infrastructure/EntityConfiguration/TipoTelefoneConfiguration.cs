namespace LeiaJa.Infrastructure.EntityConfiguration;
public class TipoTelefoneConfiguration : IEntityTypeConfiguration<TipoTelefoneEntity>
{
    public void Configure(EntityTypeBuilder<TipoTelefoneEntity> builder)
    {
        builder.ToTable("TBL_TIPOTELEFONE");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TipoTelefone).
                IsRequired(true).
                HasColumnType("NVACHAR").
                HasMaxLength(8);
        builder.HasData(
            new TipoTelefoneEntity(1, "Pessoal"),
            new TipoTelefoneEntity(2, "Trabalho")
        );
    }
}
