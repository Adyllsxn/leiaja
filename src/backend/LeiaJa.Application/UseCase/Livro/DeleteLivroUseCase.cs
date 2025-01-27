namespace LeiaJa.Application.UseCase.Livro;
public class DeleteLivroUseCase(ILivroRepository _repository, IMapper _mapper)
{
        public async Task<ResponseModel<LivroDTO>> DeleteLivroAsync(int livroId)
        {
            ResponseModel<LivroDTO> response = new();
            try
            {
                if(livroId <= 0)
                {
                    response.Message = "O ID Não Deve Ser Menor Ou Igual A Zero.";
                    return response;
                }
                var deleteLivro = await _repository.DeleteLivroAsync(livroId);
                if(deleteLivro == null)
                {
                    response.Message = $"Nenhum Livro Encontrado Com O ID {livroId}.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = _mapper.Map<LivroDTO>(deleteLivro);
                response.Message = "O Livro Foi Deletado Com Sucesso.";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Deletar O Livro. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
