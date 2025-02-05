namespace LeiaJa.Application.UseCase.BookUseCase;
public class GetBookUseCase(IBookRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<BookDto>>> GetBooksAsync()
    {
        ResponseModel<List<BookDto>> response = new();
        try
        {       
            var books = await _repository.GetBooksAsync();
            var bookDTOs = _mapper.Map<List<BookDto>>(books); // Converte entidades para DTOs

            if (!bookDTOs.Any())
            {
                response.Message = "Nenhum livro encontrado.";
                response.StatusCode = 404;
                return response;
            }

            response.Data = bookDTOs;
            response.Message = "Livros encontrados";
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
