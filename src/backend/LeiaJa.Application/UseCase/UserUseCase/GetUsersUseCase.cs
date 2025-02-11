namespace LeiaJa.Application.UseCase.UserUseCase;
public class GetUsersUseCase(IUserRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<UserDto>>> GetUsersAsync()
    {
        ResponseModel<List<UserDto>> response = new ();
        try
        {       
                var users = await _repository.GetUsersAsync();
                var userDTO = _mapper.Map<List<UserDto>>(users);
                if(!userDTO.Any())
                {
                    response.Message = "Nenhuma usuário encontrado.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data =  userDTO.ToList();
                response.Message = "usuários encontrados";
                response.StatusCode = 200;
                return response;
        }
        catch (Exception ex)
        {
                response.Message = $"Falha ao listar os usuários. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
        }
    } 
}
