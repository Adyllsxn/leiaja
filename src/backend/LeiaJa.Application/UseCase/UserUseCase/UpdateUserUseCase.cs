namespace LeiaJa.Application.UseCase.UserUseCase;
public class UpdateUserUseCase(IUserRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<UserDto>> UpdateUserAsync(UserDto userDto)
    {
        ResponseModel<UserDto> response = new();
        try
        {   
            if(userDto == null)
            {
                response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                response.StatusCode = 400;
                return response;
            }
            var user = _mapper.Map<UserEntity>(userDto);
            var updateUser = await _repository.UpdateUserAsync(user);
            if(updateUser == null)
            {
                response.Message = $"Não Exite Esse Usuário Com ID {user.Id}";
                response.StatusCode = 404;
                return response;
            }
            response.Data = _mapper.Map<UserDto>(updateUser);
            response.Message = "Usuário Editada Com Sucesso!";
            response.StatusCode = 200;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Editar O Usuário. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
}
