namespace LeiaJa.Infrastructure.EntityConfiguration;
public class EmprestimoConfiguration : IEntityTypeConfiguration<EmprestimoEntity>
{
    public void Configure(EntityTypeBuilder<EmprestimoEntity> builder)
    {
        builder.ToTable("TBL_EMPRESTIMO");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UsuarioId).
                IsRequired(true);
        builder.Property(x => x.LivroId).
                IsRequired(true);
        
        builder.HasOne(x => x.Usuario).WithMany(x => x.Emprestimos).HasForeignKey(x => x.UsuarioId).HasConstraintName("FKUsuarioEmprestimo").OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Livro).WithMany(x => x.Emprestimos).HasForeignKey(x => x.LivroId).HasConstraintName("FKLivroEmprestimo").OnDelete(DeleteBehavior.Cascade);
    }
}
