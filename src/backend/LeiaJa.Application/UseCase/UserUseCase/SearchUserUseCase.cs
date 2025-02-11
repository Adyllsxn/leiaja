namespace LeiaJa.Application.UseCase.UserUseCase;
public class SearchUserUseCase(IUserRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<UserDto>>> SearchUsersAsync(string predicate)
    {
        ResponseModel<List<UserDto>> response = new ();
        try
        {       
                var users = await _repository.SearchUserAsync(x => x.FirstName.Contains(predicate));
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
                response.Message = $"Falha ao listar os usuário. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
        }
    }
}
