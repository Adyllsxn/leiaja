namespace LeiaJa.Application.UseCase.Livro;
public class GetLivrosUseCase(ILivroRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<PagedList<LivroDTO>>> GetAllLivrosAsync(int pageNumber, int pageSize)
        {
            ResponseModel<PagedList<LivroDTO>> response = new();
            try
            {
                var livros = await _repository.GetAllLivrosAsync(pageNumber, pageSize);
                var livroDTOs = _mapper.Map<List<LivroDTO>>(livros);
                if(!livroDTOs.Any())
                {
                    response.Message = "Nenhum Livro Encontrado.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data =  new PagedList<LivroDTO>(livroDTOs, pageNumber, pageSize, livros.TotalCount);
                response.Message = "Livros Encontrados";
                response.StatusCode = 200;
                return response;
            }
            catch (Exception ex)    
            {
                response.Message = $"Falha Ao Listar Os Livros. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
