namespace LeiaJa.Domain.Interfaces;
public interface IUserRepository : Interface<UserEntity>
{
    Task<List<UserEntity>> GetUsersAsync();
    Task<List<UserEntity>> CreateUserAsync(UserEntity user);
    Task<UserEntity?> DeleteUserAsync(int userId);
    Task<UserEntity?> GetUserByIdAsync(int userId);
    Task<UserEntity> UpdateUserAsync(UserEntity user);
    Task<bool> ExistUserRegisterAsync();
    Task<List<UserEntity>>SearchUserAsync(Expression<Func<UserEntity, bool>> predicate);
}
