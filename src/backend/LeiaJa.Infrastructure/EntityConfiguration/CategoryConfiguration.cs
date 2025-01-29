namespace LeiaJa.Infrastructure.EntityConfiguration;
public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("TBL_CATEGORY");
        builder.Property(x => x.Id);
        builder.Property(x => x.Category).
                IsRequired(true).
                HasColumnType("NVARCHAR").
                HasMaxLength(50).
                HasColumnName("Categoria");
        builder.Property(x => x.Description).
                IsRequired(true).
                HasColumnType("NVARCHAR").
                HasMaxLength(200).
                HasColumnName("Descricao");
        builder.HasData(
            new CategoryEntity(1, "Romântico", "msnmansmnamnsman"),
            new CategoryEntity(2, "Desenvolvimento Pessoal", "jakdjakjsakjakljkjasj"),
            new CategoryEntity(3, "Finanças", "dhsjkdjskd")
        );
    }
}
