namespace LeiaJa.Infrastructure.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<AutorEntity> Autores { get; set; } = null!;
    public DbSet<CategoriaEntity> Categorias { get; set; } = null!;
    public DbSet<LivroEntity> Livros { get; set; } = null!;
    public DbSet<EmprestimoEntity> Emprestimos { get; set; } = null!;
    public DbSet<UsuarioEntity> Usuarios { get; set; } = null!;
    public DbSet<TipoUsuarioEntity> TipoUsuarios { get; set; } = null!;
    public DbSet<GeneroEntity> Generos { get; set; } = null!;
    public DbSet<MunicipioEntity> Municipios { get; set; } = null!;
    public DbSet<ProvinciaEntity> Provincias { get; set; } = null!;
    public DbSet<TipoTelefoneEntity> TipoTelefones { get; set; } = null!;
    public DbSet<TelefoneEntity> Telefones { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
