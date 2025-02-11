namespace LeiaJa.Application.Interfaces;
public interface IUserService
{
    Task<ResponseModel<List<UserDto>>> CreateUserAsync(UserPostDto userPostDto);
    Task<ResponseModel<UserDto>> DeleteUserAsync(int userId);
    Task<bool> ExistUserAsync();
    Task<ResponseModel<UserDto>> GetUserByIdAsync(int userId);
    Task<ResponseModel<List<UserDto>>> GetUsersAsync();
    Task<ResponseModel<List<UserDto>>> SearchUsersAsync(string predicate);
    Task<ResponseModel<UserDto>> UpdateUserAsync(UserDto userDto);
}
