namespace LeiaJa.Domain.Interfaces;
public interface IBookRepository : Interface<BookEntity>
{
    Task<List<BookEntity>> GetBooksAsync();
    Task<List<BookEntity>> CreateBookAsync(BookEntity book, List<int> categoryId, List<int> athorId);
    Task<BookEntity?> DeleteBookAsync(int bookId);
    Task<BookEntity?> GetBookByIdAsync(int bookId);
    Task<BookEntity> UpdateBookAsync(BookEntity book, List<int> categoryId, List<int> athorId);
    Task<List<BookEntity>>SearchBookAsync(Expression<Func<BookEntity, bool>> predicate);
}
