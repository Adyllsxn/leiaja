namespace LeiaJa.Application.UseCase.BookUseCase;
public class GetBookByIdUseCase(IBookRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<BookDto>> GetBookByIdAsync(int bookId)
    {   
        ResponseModel<BookDto> response = new();
        try
        { 
            if(bookId <= 0)
            {
                response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                return response;
            }
            var book = await _repository.GetBookByIdAsync(bookId);
            var bookDTO = _mapper.Map<BookDto>(book);
            if(bookDTO == null)
            {
                response.Message = $"Não Existe Livro Com ID {bookId}!";
                response.StatusCode = 404;
                return response;
            }
            response.Data = bookDTO;
            response.Message = $"Foi Encontrado livro Com ID = {bookId}!";
            response.StatusCode = 200;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Obter O livro. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
}
