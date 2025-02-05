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
                AthorId = a.Id,  
                BookId = book.Id   
            }).ToList();

            book.BookCategories = categories.Select(a => new BookCategoryEntity 
            {
                CategoryId = a.Id,  
                BookId = book.Id   
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
    
    #region <Delete>
        public async Task<BookEntity?> DeleteBookAsync(int bookId)
        {
            try
            {
                if (bookId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(bookId), "O ID Do Livro Não Deve Ser Negativo Ou Zero.");
                }
                
                var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookId);
                if (book == null)
                {
                    throw new KeyNotFoundException($"Nenhum livro Encontrada com o ID {bookId}.");
                }
                
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return book;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Deletar O livro. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Delete>
    
    #region <GetId>
        public async Task<BookEntity?> GetBookByIdAsync(int bookId)
        {
            try
            {
                if (bookId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(bookId), "O ID Do livro Não Deve Ser Negativo Ou Zero.");
                }
                var book = await _context.Books.AsNoTracking().Include(b => b.BookAthors).ThenInclude(ba => ba.Athor).Include(b => b.BookCategories).ThenInclude(bc => bc.Category).FirstOrDefaultAsync(x => x.Id == bookId);
                if (book == null)
                {
                    throw new KeyNotFoundException("Categoria Não Foi Encontrado.");
                }
                return book;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Buscar o livro Com ID {bookId}. Erro: {ex.Message}");
                return null;
            }
        }
    #endregion </GetId>

    #region <Get>
        public async Task<List<BookEntity>> GetBooksAsync()
        {
            try
            {
                return await _context.Books.AsNoTracking().Include(b => b.BookAthors).ThenInclude(ba => ba.Athor).Include(b => b.BookCategories).ThenInclude(bc => bc.Category).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um ao obter os livros. Erro: {ex.Message}");
                return null!; 
            }
        }
    #endregion </Get>
    
    #region <Search>
        public async Task<List<BookEntity>> SearchBookAsync(Expression<Func<BookEntity, bool>> predicate)
        {
            try
            {
                return await _context.Books.AsNoTracking().Include(x => x.BookAthors).Include(x => x.BookCategories).Where(predicate).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um ao pesquisar os livros. Erro: {ex.Message}");
                return null!; 
            }
        }
    #endregion </Search>

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