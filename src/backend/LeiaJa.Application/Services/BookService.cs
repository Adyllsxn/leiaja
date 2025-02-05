namespace LeiaJa.Application.Services;
public class BookService(GetBookUseCase _get, GetBookByIdUseCase _getId, CreateBookUseCase _create) : IBookService
{
    public async Task<ResponseModel<List<BookDto>>> CreateBookAsync(BookPostDTO bookPostDTO, List<int> categoryId, List<int> athorId)
    {
        return await _create.CreateBookAsync(bookPostDTO, categoryId, athorId);
    }

    public async Task<ResponseModel<BookDto>> GetBookByIdAsync(int bookId)
    {
        return await _getId.GetBookByIdAsync(bookId);
    }

    public async Task<ResponseModel<List<BookDto>>> GetBooksAsync()
    {
        return await _get.GetBooksAsync();
    }
}
