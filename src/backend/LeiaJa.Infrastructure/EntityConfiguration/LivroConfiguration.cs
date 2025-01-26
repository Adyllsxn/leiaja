namespace LeiaJa.Infrastructure.EntityConfiguration;
public class LivroConfiguration : IEntityTypeConfiguration<LivroEntity>
{
        public void Configure(EntityTypeBuilder<LivroEntity> builder)
        {
                builder.ToTable("TBL_LIVRO");
                builder.ToTable("TBL_LIVROS");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Nome).
                        IsRequired(true).
                        HasMaxLength(50).
                        HasColumnType("VARCHAR");

                builder.Property(x => x.Autor).
                        IsRequired(true).
                        HasMaxLength(50).
                        HasColumnType("VARCHAR");
                        
                builder.Property(x => x.Editora).
                        IsRequired(true).
                        HasColumnType("VARCHAR")
                        .HasMaxLength(50);
                builder.Property(x => x.AnoPublicacao).
                        IsRequired(true);
                builder.Property(x => x.Edicao).
                        IsRequired(true).
                        HasColumnType("VARCHAR")
                        .HasMaxLength(50);
                builder.HasData(
                        new LivroEntity(1, "Pai Pobre, PaiRico", "Roberto Kiyosaki", "RPO", new DateTime(), "02")
                );
        }
}
