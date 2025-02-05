namespace LeiaJa.Application.Interfaces;
public interface IBookService
{
    Task<ResponseModel<List<BookDto>>> GetBooksAsync();
    Task<ResponseModel<BookDto>> GetBookByIdAsync(int bookId);
    Task<ResponseModel<List<BookDto>>> CreateBookAsync(BookPostDTO bookPostDTO,List<int> categoryId, List<int> athorId);
}
