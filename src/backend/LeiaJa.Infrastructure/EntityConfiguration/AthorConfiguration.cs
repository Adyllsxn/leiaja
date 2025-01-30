namespace LeiaJa.Infrastructure.EntityConfiguration;
public class AthorConfiguration : IEntityTypeConfiguration<AthorEntity>
{
        public void Configure(EntityTypeBuilder<AthorEntity> builder)
        {
                builder.ToTable("TBL_ATHOR");
                builder.Property(x => x.Id);
                builder.Property(x => x.FirstName).
                        IsRequired(true).
                        HasColumnType("NVARCHAR").
                        HasMaxLength(50).
                        HasColumnName("Nome");
                builder.Property(x => x.LastName).
                        IsRequired(true).
                        HasColumnType("NVARCHAR").
                        HasMaxLength(50).
                        HasColumnName("UltimoNome");
                builder.Property(x => x.Photo).
                        IsRequired(true).
                        HasColumnName("Foto");

                
        }
}
