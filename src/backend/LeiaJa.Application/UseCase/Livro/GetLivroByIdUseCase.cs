namespace LeiaJa.Application.UseCase.Livro;
public class GetLivroByIdUseCase(ILivroRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<LivroDTO>> GetLivroByIdAsync(int livroId)
        {
            ResponseModel<LivroDTO> response = new();
            try
            {
                if(livroId <= 0)
                {
                    response.Message = "O ID Não Deve Ser Menor Ou Igual A Zero.";
                    return response;
                }
                var livro = await _repository.GetLivroByIdAsync(livroId);
                var livroDTO = _mapper.Map<LivroDTO>(livro);
                if(livroDTO == null)
                {
                    response.Message = $"Não Existe O Livro Com ID {livroId}!";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = livroDTO;
                response.Message = $"Foi Encontrado Livro Com ID = {livroId}!";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Obter O Livro. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
