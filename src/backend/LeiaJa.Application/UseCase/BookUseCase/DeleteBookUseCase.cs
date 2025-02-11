namespace LeiaJa.Application.UseCase.BookUseCase;
public class DeleteBookUseCase(IBookRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<BookDto>> DeleteBookAsync(int bookId)
    {
        ResponseModel<BookDto> response = new();
        try
        {
            if(bookId <= 0)
            {
                response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                return response;
            }
            var deleteBook = await _repository.DeleteBookAsync(bookId);
            if(deleteBook == null)
            {
                response.Message = $"Nenhum Livro Encontrado Com O ID {bookId}.";
                response.StatusCode = 404;
                return response;
            }
            response.Data = _mapper.Map<BookDto>(deleteBook);
            response.Message = "livro Deletado Com Sucesso.";
            response.StatusCode = 200;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Deletar O livro. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
}
