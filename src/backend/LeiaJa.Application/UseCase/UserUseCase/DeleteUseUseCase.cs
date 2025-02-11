namespace LeiaJa.Application.UseCase.UserUseCase;
public class DeleteUseUseCase(IUserRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<UserDto>> DeleteUserAsync(int userId)
    {
        ResponseModel<UserDto> response = new();
        try
        {
            if(userId <= 0)
            {
                response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                return response;
            }
            var deleteUser = await _repository.DeleteUserAsync(userId);
            if(deleteUser == null)
            {
                response.Message = $"Nenhum Usuário Encontrado Com O ID {userId}.";
                response.StatusCode = 404;
                return response;
            }
            response.Data = _mapper.Map<UserDto>(deleteUser);
            response.Message = "Usuário Foi Deletado Com Sucesso.";
            response.StatusCode = 200;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Deletar O Usuário. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
}
