namespace LeiaJa.Application.UseCase.Livro;
public class CreateLivroUseCase(ILivroRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<LivroDTO>>> CreateAutorAsync(LivroPostDTO livroDTO)
        {
            ResponseModel<List<LivroDTO>> response = new();
            try
            {
                if(livroDTO == null)
                {
                    response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                    return response;
                }
                var livro = _mapper.Map<LivroEntity>(livroDTO);
                var createLivro = await _repository.CreateLivroAsync(livro);

                response.Data = _mapper.Map<List<LivroDTO>>(createLivro);
                response.Message = "O Livro Foi Salvo Com Sucesso";
                response.StatusCode = 201;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Salvar O Livro. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
