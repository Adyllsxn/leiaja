namespace LeiaJa.Infrastructure.EntityConfiguration;
public class BookAthorConfiguration : IEntityTypeConfiguration<BookAthorEntity>
{
    public void Configure(EntityTypeBuilder<BookAthorEntity> builder)
    {
        builder.ToTable("TBL_BOOK_ATHOR");
        builder.HasKey(x => new { x.BookId, x.AthorId });
        builder.Property(x => x.BookId).
                IsRequired(true).
                HasColumnName("Book");
        builder.Property(x => x.AthorId).
                IsRequired(true).
                HasColumnName("Athor");

        builder.HasOne(x => x.Athor).WithMany(x => x.BookAthors).HasForeignKey(x => x.AthorId).HasConstraintName("FK_BookAthor_Athor").OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Book).WithMany(x => x.BookAthors).HasForeignKey(x => x.BookId).HasConstraintName("FK_BookAthor_Book").OnDelete(DeleteBehavior.Cascade);
    }
}
