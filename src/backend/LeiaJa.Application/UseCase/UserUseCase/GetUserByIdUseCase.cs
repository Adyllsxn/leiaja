namespace LeiaJa.Application.UseCase.UserUseCase;
public class GetUserByIdUseCase(IUserRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<UserDto>> GetUserByIdAsync(int userId)
    {   
        ResponseModel<UserDto> response = new();
        try
        { 
            if(userId <= 0)
            {
                response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                return response;
            }
            var user = await _repository.GetUserByIdAsync(userId);
            var userDTO = _mapper.Map<UserDto>(user);
            if(userDTO == null)
            {
                response.Message = $"Não Existe Usuário Com ID {userId}!";
                response.StatusCode = 404;
                return response;
            }
            response.Data = userDTO;
            response.Message = $"Foi Encontrado Usuário Com ID = {userId}!";
            response.StatusCode = 200;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Obter O Usuário. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
}
