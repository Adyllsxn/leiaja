namespace LeiaJa.Infrastructure.EntityConfiguration;
public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.ToTable("TBL_BOOK");
        builder.Property(x => x.Id);
        builder.Property(x => x.Title).
                IsRequired(true).
                HasColumnType("NVARCHAR").
                HasMaxLength(200).
                HasColumnName("Titulo");
        builder.Property(x => x.Image).
                IsRequired(true).
                HasColumnName("Foto");
        builder.Property(x => x.Document).
                IsRequired(true).
                HasColumnName("Documento");
        builder.Property(x => x.Edition).
                IsRequired(true).
                HasColumnType("NVARCHAR").
                HasMaxLength(50).
                HasColumnName("Edicao");
        builder.Property(x => x.DataCreateBook).
                IsRequired(true).
                HasColumnName("AnoPublicacao");
    }
}
