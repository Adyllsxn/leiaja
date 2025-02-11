namespace LeiaJa.Application.UseCase.UserUseCase;
public class ExistUserUseCase(IUserRepository _repository)
{
    public async Task<bool> ExistUserAsync()
    {
        return await _repository.ExistUserRegisterAsync();
    }
}
