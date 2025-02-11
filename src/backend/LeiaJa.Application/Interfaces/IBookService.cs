namespace LeiaJa.Application.Interfaces;
public interface IBookService
{
    Task<ResponseModel<List<BookDto>>> GetBooksAsync();
    Task<ResponseModel<BookDto>> GetBookByIdAsync(int bookId);
    Task<ResponseModel<List<BookDto>>> CreateBookAsync(BookPostDTO bookPostDTO,List<int> categoryId, List<int> athorId);
    Task<ResponseModel<BookDto>> DeleteBookAsync(int bookId);
    Task<ResponseModel<List<BookDto>>> SearchBooksAsync(string predicate);
    Task<ResponseModel<BookDto>> UpdateAthorAsync(BookDto bookDto,List<int> categoryId, List<int> athorId);
}
