namespace LeiaJa.Infrastructure.EntityConfiguration;
public class LivroConfiguration : IEntityTypeConfiguration<LivroEntity>
{
        public void Configure(EntityTypeBuilder<LivroEntity> builder)
        {
                builder.ToTable("TBL_LIVRO");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Livro).
                        IsRequired(true).
                        HasColumnType("NVACHAR").
                        HasMaxLength(200);
                builder.Property(x => x.AutorId).
                        IsRequired(true);
                builder.Property(x => x.CategoriaId).
                        IsRequired(true);
                builder.Property(x => x.Editora).
                        IsRequired(true).
                        HasColumnType("NVACHAR").
                        HasMaxLength(100);
                builder.Property(x => x.AnoPublicacao).
                        IsRequired(true);
                builder.Property(x => x.Edicao).
                        IsRequired(true).
                        HasColumnType("NVACHAR").
                        HasMaxLength(100);
                builder.Property(x => x.Imagem).
                        IsRequired(true);
                builder.Property(x => x.Documento).
                        IsRequired(true);

                builder.HasOne(x => x.Autor).WithMany(x => x.Livros).HasForeignKey(x => x.AutorId).HasConstraintName("FKAutorLivros").OnDelete(DeleteBehavior.Cascade);
                
                builder.HasOne(x => x.Categoria).WithMany(x => x.Livros).HasForeignKey(x => x.CategoriaId).HasConstraintName("FKCategoriaLivros").OnDelete(DeleteBehavior.Cascade);

        }
}
