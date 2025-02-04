namespace LeiaJa.Infrastructure.Repositories;
public class BookRepository(AppDbContext _context, ILogger<BookEntity> _logger) : IBookRepository
{
    public async Task<List<BookEntity>> CreateBookAsync(BookEntity book, List<int> categoryId, List<int> athorId)
    {
        try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Os campos não devem ser vazios.");
                }
                else if (categoryId == null)
                {
                    throw new ArgumentNullException(nameof(categoryId), "Os campos não devem ser vazios.");
                }
                else if (athorId == null)
                {
                    throw new ArgumentNullException(nameof(athorId), "Os campos não devem ser vazios.");
                }
                

                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return await _context.Books.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao salvar o livro. Erro: {ex.Message}");
                return null!;
            }
    }

    public Task<BookEntity?> DeleteBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public Task<BookEntity?> GetBookByIdAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public Task<List<BookEntity>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<BookEntity>> SearchBookAsync(Expression<Func<BookEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<BookEntity> UpdateBookAsync(BookEntity book, List<int> categoryId, List<int> athorId)
    {
        throw new NotImplementedException();
    }
}