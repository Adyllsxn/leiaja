namespace LeiaJa.Infrastructure.Repositories;
public class LivroRepository(AppDbContext _context, ILogger<LivroRepository> _logger) : ILivroRepository
{    
    #region <Create>
        public async Task<List<LivroEntity>> CreateAutorAsync(LivroEntity livro)
        {
            try
            {
                if (livro == null)
                {
                    throw new ArgumentNullException(nameof(livro), "Os Campos Não Devem Ser Vazios.");
                }
                await _context.Livros.AddAsync(livro);
                await _context.SaveChangesAsync();
                return await _context.Livros.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Salvar O Livro. Erro: {ex.Message}");
                return null!;
            }
        }

    public Task<List<LivroEntity>> CreateLivroAsync(LivroEntity livro)
    {
        throw new NotImplementedException();
    }
    #endregion </Create>

    #region <Delete>
    public async Task<LivroEntity?> DeleteAutorAsync(int livroId)
        {
            try
            {
                if (livroId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(livroId), "O Id Do Livro Não Pode Ser Negativo Ou Igual A Zero.");
                }
                var autor = await _context.Livros.FirstOrDefaultAsync(x => x.Id == livroId);
                if (autor == null)
                {
                    throw new KeyNotFoundException($"Nenhum Livro Encontrada com o ID {livroId}.");
                }
                
                _context.Livros.Remove(autor);
                await _context.SaveChangesAsync();
                return autor;

            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Deletar O Livro. Erro: {ex.Message}");
                return null!;
            }
        }

    public Task<LivroEntity?> DeleteLivroAsync(int livroId)
    {
        throw new NotImplementedException();
    }
    #endregion </Delete>

    #region <Get>
    public async Task<PagedList<LivroEntity>> GetAllAutoresAsync(int pageNumber, int pageSize)
        {
            try
            {
                var autores = await _context.Livros.AsNoTracking().ToListAsync();
                if(autores == null)
                {
                    throw new KeyNotFoundException($"Livros Não Foram Encontrados.");
                }
                var query = _context.Livros.AsQueryable();
                return await PaginationHelper.CreateAsync(query,pageNumber, pageSize);
                
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Obter Os Livros. Erro: {ex.Message}");
                return null!;
            }
        }

    public Task<PagedList<LivroEntity>> GetAllLivrosAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }
    #endregion </Get>

    #region <GetId>
        public async Task<LivroEntity?> GetLivroByIdAsync(int livroId)
        {
            try
            {
                if (livroId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(livroId), "O ID Do Livro Não Deve Ser Negativo Ou Zero.");
                }
                var autor = await _context.Livros.FirstOrDefaultAsync(x => x.Id == livroId);
                if (autor == null)
                {
                    throw new KeyNotFoundException("Livro Não Foi Encontrado.");
                }
                return autor;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro ao buscar o livro com ID {livroId}. Erro: {ex.Message}");
                return null;
            }
        }
    #endregion </GetId>

    #region </Search>
    public async Task<List<LivroEntity>> SearchAutorAsync(Expression<Func<LivroEntity, bool>> predicate)
        {
            try
            {
                if(predicate == null)
                {
                    throw new ArgumentNullException(nameof(predicate), "Insira uma palavra.");
                }
                return await _context.Livros.AsNoTracking().Where(predicate).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($" . Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Search>

    #region <Update>
        public async Task<LivroEntity> UpdateLivroAsync(LivroEntity livro)
        {
            try
            {
                if(livro == null)
                {
                    throw new ArgumentNullException(nameof(livro),"A Entidade Livro Não Deve Ser Vazia Ou Nula.");
                }
                _context.Livros.Update(livro);
                var result = await _context.SaveChangesAsync();

                if (result == 0)
                {
                    _logger.LogWarning($"Nenhuma Modificação Foi Realizada Ao Editar O Livro Com ID {livro.Id}.");
                    return null!;
                }
                
                return livro;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Editar O Livro. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Update>
}