namespace LeiaJa.Application.UseCase.BookUseCase;
public class CreateBookUseCase(IBookRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<BookDto>>> CreateBookAsync(BookPostDTO bookPostDTO,List<int> categoryId, List<int> athorId)
    {
        ResponseModel<List<BookDto>> response = new();
        try
        {
            if(bookPostDTO == null)
            {
                response.Message = "Os parâmetros não devem ser nulos ou vazios.";
                return response;
            }
            var book = _mapper.Map<BookEntity>(bookPostDTO);
            var createBook = await _repository.CreateBookAsync(book, categoryId, athorId);
            if(createBook == null)
            {
                response.Message = "Falha Ao salvar o livro. Os Parâmetros Podem Estar Inválidos.";
                response.StatusCode = 400;
                return response;
            }

            response.Data = _mapper.Map<List<BookDto>>(await _repository.GetBooksAsync());
            response.Message = "Livro Foi Salvo Com Sucesso";
            response.StatusCode = 201;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Salvar o autor. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
}
