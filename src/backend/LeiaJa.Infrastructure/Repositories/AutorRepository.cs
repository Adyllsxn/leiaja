using System.Linq.Expressions;

namespace LeiaJa.Infrastructure.Repositories;
public class AutorRepository : IAutorRepository
{
    #region </Configuration>
        private readonly AppDbContext _context;
        private readonly ILogger<AutorRepository> _logger;
        public AutorRepository(AppDbContext context, ILogger<AutorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
    #endregion </Configuration>
    
    #region <Create>
        public async Task<List<AutorEntity>> CreateAutorAsync(AutorEntity autor)
        {
            try
            {
                if (autor == null)
                {
                    throw new ArgumentNullException(nameof(autor), "Os Campos Não Devem Ser Vazios.");
                }
                await _context.Autores.AddAsync(autor);
                await _context.SaveChangesAsync();
                return await _context.Autores.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Salvar O Autor. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Create>
    
    #region <Delete>
        public async Task<AutorEntity?> DeleteAutorAsync(int autorId)
        {
            try
            {
                if (autorId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(autorId), "O Id Do Autor Não Pode Ser Negativo Ou Igual A Zero.");
                }
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == autorId);
                if (autor == null)
                {
                    throw new KeyNotFoundException($"Nenhum Autor Encontrada com o ID {autorId}.");
                }
                
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                return autor;

            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Deletar O Autor. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Delete>
    
    #region <Get>
        public async Task<PagedList<AutorEntity>> GetAllAutoresAsync(int pageNumber, int pageSize)
        {
            try
            {
                var autores = await _context.Autores.AsNoTracking().ToListAsync();
                if(autores == null)
                {
                    throw new KeyNotFoundException($"Autores Não Foram Encontrados.");
                }
                var query = _context.Autores.AsQueryable();
                return await PaginationHelper.CreateAsync(query,pageNumber, pageSize);
                
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Obter Os Autores. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Get>

    #region <GetId>
        public async Task<AutorEntity?> GetAutorByIdAsync(int autorId)
        {
            try
            {
                if (autorId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(autorId), "O ID Do Autor Não Deve Ser Negativo Ou Zero.");
                }
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == autorId);
                if (autor == null)
                {
                    throw new KeyNotFoundException("Autor Não Foi Encontrado.");
                }
                return autor;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro ao buscar o autor com ID {autorId}. Erro: {ex.Message}");
                return null;
            }
        }
    #endregion </GetId>

    #region </Search>
        public async Task<List<AutorEntity>> SearchAutorAsync(Expression<Func<AutorEntity, bool>> predicate)
        {
            try
            {
                if(predicate == null)
                {
                    throw new ArgumentNullException(nameof(predicate), "Insira uma palavra.");
                }
                return await _context.Autores.AsNoTracking().Where(predicate).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($" . Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Search>

    #region <Update>
    public async Task<AutorEntity> UpdateAutorAsync(AutorEntity autor)
        {
            try
            {
                if(autor == null)
                {
                    throw new ArgumentNullException(nameof(autor),"A Entidade Autor Não Deve Ser Vazia Ou Nula.");
                }
                _context.Autores.Update(autor);
                var result = await _context.SaveChangesAsync();

                if (result == 0)
                {
                    _logger.LogWarning($"Nenhuma Modificação Foi Realizada Ao Editar O Autor Com ID {autor.Id}.");
                    return null!;
                }
                
                return autor;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Editar O Autor. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Update>
}
