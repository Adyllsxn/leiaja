namespace LeiaJa.Infrastructure.EntityConfiguration
{
    public class AutorConfiguration : IEntityTypeConfiguration<AutorEntity>
    {
        public void Configure(EntityTypeBuilder<AutorEntity> builder)
        {
            builder.ToTable("TBL_AUTOR");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).
                    IsRequired(true).
                    HasMaxLength(50).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.SobreNome).
                    IsRequired(true).
                    HasMaxLength(50).
                    HasColumnType("VARCHAR");
            builder.HasData(
                new AutorEntity(1, "Jordan", "Peterson")
            );

        }
    }
}