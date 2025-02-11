namespace LeiaJa.Infrastructure.EntityConfiguration;
public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("TBL_USER");
    }
}
