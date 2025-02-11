namespace LeiaJa.Application.Services;
public class UserService(CreateUserUseCase _create, DeleteUseUseCase _delete, ExistUserUseCase _exist, GetUserByIdUseCase _getId, GetUsersUseCase _get, SearchUserUseCase _search, UpdateUserUseCase _update) : IUserService
{
    public async Task<ResponseModel<List<UserDto>>> CreateUserAsync(UserPostDto userPostDto)
    {
        return await _create.CreateUserAsync(userPostDto);
    }

    public async Task<ResponseModel<UserDto>> DeleteUserAsync(int userId)
    {
        return await _delete.DeleteUserAsync(userId);
    }

    public async Task<bool> ExistUserAsync()
    {
        return await _exist.ExistUserAsync();
    }

    public async Task<ResponseModel<UserDto>> GetUserByIdAsync(int userId)
    {
        return await _getId.GetUserByIdAsync(userId);
    }

    public async Task<ResponseModel<List<UserDto>>> GetUsersAsync()
    {
        return await _get.GetUsersAsync();
    }

    public async Task<ResponseModel<List<UserDto>>> SearchUsersAsync(string predicate)
    {
        return await _search.SearchUsersAsync(predicate);
    }

    public async Task<ResponseModel<UserDto>> UpdateUserAsync(UserDto userDto)
    {
        return await _update.UpdateUserAsync(userDto);
    }
}
