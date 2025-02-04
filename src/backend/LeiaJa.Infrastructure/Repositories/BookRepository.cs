namespace LeiaJa.Infrastructure.Repositories;
public class BookRepository(AppDbContext _context, ILogger<BookEntity> _logger) : IBookRepository
{

    #region <Create>
        public async Task<List<BookEntity>> CreateBookAsync(BookEntity book, List<int> categoryId, List<int> athorId)
        {
            try
            {
                if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "O livro não pode ser nulo.");
            }
            if (categoryId == null || !categoryId.Any())
            {
                throw new ArgumentNullException(nameof(categoryId), "A lista de categorias não pode estar vazia.");
            }
            if (athorId == null || !athorId.Any())
            {
                throw new ArgumentNullException(nameof(athorId), "A lista de autores não pode estar vazia.");
            }

            // Buscar categorias e autores pelo ID antes de associar ao livro
            var categories = await _context.Categories.AsNoTracking().Where(c => categoryId.Contains(c.Id)).ToListAsync();
            var athors = await _context.Athors.AsNoTracking().Where(a => athorId.Contains(a.Id)).ToListAsync();

            if (categories.Count != categoryId.Count)
            {
                throw new KeyNotFoundException("Uma ou mais categorias fornecidas não foram encontradas.");
            }

            if (athors.Count != athorId.Count)
            {
                throw new KeyNotFoundException("Um ou mais autores fornecidos não foram encontrados.");
            }
            book.BookAthors = athors.Select(a => new BookAthorEntity 
            {
                AthorId = a.Id,  // ou outro campo apropriado
                BookId = book.Id   // dependendo da estrutura da tua entidade
            }).ToList();

            book.BookCategories = categories.Select(a => new BookCategoryEntity 
            {
                CategoryId = a.Id,  // ou outro campo apropriado
                BookId = book.Id   // dependendo da estrutura da tua entidade
            }).ToList();

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
    #endregion </Create>
    public Task<BookEntity?> DeleteBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public Task<BookEntity?> GetBookByIdAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    #region <Get>
        public async Task<List<BookEntity>> GetBooksAsync()
        {
            try
            {
                var books = await _context.Books.AsNoTracking().Include(x => x.BookAthors).Include(x => x.BookCategories).ToListAsync();
                if(books == null)
                {
                    throw new KeyNotFoundException($"Livros não foram encontradas.");
                }
                return books;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um ao obter os livros. Erro: {ex.Message}");
                return null!; 
            }
        }
    #endregion </Get>
    public Task<List<BookEntity>> SearchBookAsync(Expression<Func<BookEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    #region <Update>
        public async Task<BookEntity> UpdateBookAsync(BookEntity book, List<int> categoryId, List<int> athorId)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "O livro não pode ser nulo.");
                }
                if (categoryId == null || !categoryId.Any())
                {
                    throw new ArgumentNullException(nameof(categoryId), "A lista de categorias não pode estar vazia.");
                }
                if (athorId == null || !athorId.Any())
                {
                    throw new ArgumentNullException(nameof(athorId), "A lista de autores não pode estar vazia.");
                }

                // Buscar o livro existente no banco de dados
                var existingBook = await _context.Books
                    .Include(b => b.BookCategories)
                    .Include(b => b.BookAthors)
                    .FirstOrDefaultAsync(b => b.Id == book.Id);

                if (existingBook == null)
                {
                    throw new KeyNotFoundException("O livro não foi encontrado.");
                }

                // Buscar categorias e autores pelo ID
                var categories = await _context.Categories.Where(c => categoryId.Contains(c.Id)).ToListAsync();
                var athors = await _context.Athors.Where(a => athorId.Contains(a.Id)).ToListAsync();

                if (categories.Count != categoryId.Count)
                {
                    throw new KeyNotFoundException("Uma ou mais categorias fornecidas não foram encontradas.");
                }

                if (athors.Count != athorId.Count)
                {
                    throw new KeyNotFoundException("Um ou mais autores fornecidos não foram encontrados.");
                }

                // Atualizar categorias
                existingBook.BookCategories.Clear();
                existingBook.BookCategories = categories.Select(c => new BookCategoryEntity
                {
                    BookId = existingBook.Id,
                    CategoryId = c.Id
                }).ToList();

                // Atualizar autores
                existingBook.BookAthors.Clear();
                existingBook.BookAthors = athors.Select(a => new BookAthorEntity
                {
                    BookId = existingBook.Id,
                    AthorId = a.Id
                }).ToList();

                _context.Books.Update(existingBook);
                await _context.SaveChangesAsync();

                return existingBook;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao atualizar o livro. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Update>
}