namespace LeiaJa.Infrastructure.EntityConfiguration;
public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategoryEntity>
{
    public void Configure(EntityTypeBuilder<BookCategoryEntity> builder)
    {
        builder.ToTable("TBL_BOOK_CATEGORY");
        builder.Property(x => x.Id);
        builder.Property(x => x.BookId).
                IsRequired(true).
                HasColumnName("Book");
        builder.Property(x => x.CategoryId).
                IsRequired(true).
                HasColumnName("Category");

        builder.HasOne(x => x.Category).WithMany(x => x.BookCategories).HasForeignKey(x => x.CategoryId).HasConstraintName("FK_BookCategory_Category").OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Book).WithMany(x => x.BookCategories).HasForeignKey(x => x.BookId).HasConstraintName("FK_BookCategory_Book").OnDelete(DeleteBehavior.Cascade);
    }
}
