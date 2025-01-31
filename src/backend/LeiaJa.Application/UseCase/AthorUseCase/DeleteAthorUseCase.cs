namespace LeiaJa.Application.UseCase.AthorUseCase;
public class DeleteAthorUseCase(IAthorRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<AthorDTO>> DeleteAthorAsync(int athorId)
        {
            ResponseModel<AthorDTO> response = new();
            try
            {
                if(athorId <= 0)
                {
                    response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                    return response;
                }
                var deleteAthor = await _repository.DeleteAthorAsync(athorId);
                if(deleteAthor == null)
                {
                    response.Message = $"Nenhum Autor Encontrado Com O ID {athorId}.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = _mapper.Map<AthorDTO>(deleteAthor);
                response.Message = "Autor Foi Deletado Com Sucesso.";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Deletar O Autor. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
