namespace LeiaJa.Application.UseCase.Livro;
public class UpdateLivroUseCase(ILivroRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<LivroDTO>> UpdateLivroAsync(LivroDTO livroDTO)
        {
            ResponseModel<LivroDTO> response = new();
            try
            {
                if(livroDTO == null)
                {
                    response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                    return response;
                }
                var livro = _mapper.Map<LivroEntity>(livroDTO);
                var updateLivro = await _repository.UpdateLivroAsync(livro);

                if(updateLivro == null)
                {
                    response.Message = "Não Exite.";
                    response.StatusCode = 404;
                    return response;
                }
                
                response.Data = _mapper.Map<LivroDTO>(updateLivro);
                response.Message = "Livro Editado Com Sucesso!";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Editar O Livro. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
