namespace LeiaJa.Application.UseCase.UserUseCase;
public class CreateUserUseCase(IUserRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<UserDto>>> CreateUserAsync(UserPostDto userPostDto)
    {
        ResponseModel<List<UserDto>> response = new();
        try
        {
            if(userPostDto == null)
            {
                response.Message = "Os parâmetros não devem ser nulos ou vazios.";
                return response;
            }
            var user = _mapper.Map<UserEntity>(userPostDto);
            var createUser = await _repository.CreateUserAsync(user);
            if(createUser == null)
            {
                response.Message = "Falha Ao salvar o usuário. Os Parâmetros Podem Estar Inválidos.";
                response.StatusCode = 400;
                return response;
            }

            response.Data = _mapper.Map<List<UserDto>>(await _repository.GetUsersAsync());
            response.Message = "O Autor Foi Salvo Com Sucesso";
            response.StatusCode = 201;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Salvar o usuário. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
}