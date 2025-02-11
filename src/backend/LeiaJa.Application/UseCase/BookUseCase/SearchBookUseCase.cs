namespace LeiaJa.Application.UseCase.BookUseCase;
public class SearchBookUseCase(IBookRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<BookDto>>> SearchBooksAsync(string predicate)
    {
        ResponseModel<List<BookDto>> response = new ();
        try
        {       
                var books = await _repository.SearchBookAsync(x => x.Title.Contains(predicate));
                var bookDTOs = _mapper.Map<List<BookDto>>(books);
                if(!bookDTOs.Any())
                {
                    response.Message = "Nenhuma livro encontrado.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data =  bookDTOs.ToList();
                response.Message = "livros encontrados";
                response.StatusCode = 200;
                return response;
        }
        catch (Exception ex)
        {
                response.Message = $"Falha ao listar os livros. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
        }
    }
}
