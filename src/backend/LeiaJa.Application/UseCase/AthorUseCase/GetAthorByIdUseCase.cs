namespace LeiaJa.Application.UseCase.AthorUseCase;
public class GetAthorByIdUseCase(IAthorRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<AthorDTO>> GetAthorByIdAsync(int athorId)
        {   
            ResponseModel<AthorDTO> response = new();
            try
            { 
                if(athorId <= 0)
                {
                    response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                    return response;
                }
                var athor = await _repository.GetAthorByIdAsync(athorId);
                var athorDTO = _mapper.Map<AthorDTO>(athor);
                if(athorDTO == null)
                {
                    response.Message = $"Não Existe Autor Com ID {athorId}!";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = athorDTO;
                response.Message = $"Foi Encontrado Autor Com ID = {athorId}!";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Obter O Autor. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
