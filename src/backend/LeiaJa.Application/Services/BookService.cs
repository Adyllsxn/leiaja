namespace LeiaJa.Application.Services;
public class BookService(GetBookUseCase _get, GetBookByIdUseCase _getId, CreateBookUseCase _create, DeleteBookUseCase _delete, SearchBookUseCase _search, UpdateBookUseCase _update) : IBookService
{
    public async Task<ResponseModel<List<BookDto>>> CreateBookAsync(BookPostDTO bookPostDTO, List<int> categoryId, List<int> athorId)
    {
        return await _create.CreateBookAsync(bookPostDTO, categoryId, athorId);
    }

    public async Task<ResponseModel<BookDto>> DeleteBookAsync(int bookId)
    {
        return await _delete.DeleteBookAsync(bookId);
    }

    public async Task<ResponseModel<BookDto>> GetBookByIdAsync(int bookId)
    {
        return await _getId.GetBookByIdAsync(bookId);
    }

    public async Task<ResponseModel<List<BookDto>>> GetBooksAsync()
    {
        return await _get.GetBooksAsync();
    }

    public async Task<ResponseModel<List<BookDto>>> SearchBooksAsync(string predicate)
    {
        return await _search.SearchBooksAsync(predicate);
    }

    public async Task<ResponseModel<BookDto>> UpdateAthorAsync(BookDto bookDto, List<int> categoryId, List<int> athorId)
    {
        return await _update.UpdateAthorAsync(bookDto, categoryId, athorId);
    }
}
