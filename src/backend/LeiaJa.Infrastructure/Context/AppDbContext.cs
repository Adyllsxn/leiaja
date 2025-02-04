namespace LeiaJa.Infrastructure.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CategoryEntity> Categories { get; set; } = null!;
    public DbSet<AthorEntity> Athors { get; set;} = null!;
    public DbSet<BookEntity> Books { get; set; } = null!;
    public DbSet<BookAthorEntity> BookAthors { get; set; } = null!;
    public DbSet<BookCategoryEntity> BookCategories { get; set;} = null!;
    public DbSet<UserEntity> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
