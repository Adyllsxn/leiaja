namespace LeiaJa.Infrastructure.Repositories;
public class CategoriaRepository : ICategoriaRepository
{
    #region <Configuration>
        private readonly AppDbContext _context;
        private readonly ILogger<CategoriaEntity> _logger;
        public CategoriaRepository(AppDbContext context, ILogger<CategoriaEntity> logger)
        {
            _context = context;
            _logger = logger;
        }
    #endregion </Configuration>
    
    #region <Create>
        public async Task<List<CategoriaEntity>> CreateCategoriaAsync(CategoriaEntity categoria)
        {
            try
            {
                if (categoria == null)
                {
                    throw new ArgumentNullException(nameof(categoria), "Os Campos Não Devem Ser Vazios.");
                }

                await _context.Categorias.AddAsync(categoria);
                await _context.SaveChangesAsync();
                return await _context.Categorias.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Salvar A Categoria. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Create>
    
    #region <Delete> 
        public async Task<CategoriaEntity?> DeleteCategoriaAsync(int categoriaId)
        {
            try
            {
                if (categoriaId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(categoriaId), "O ID Da Categoria Não Deve Ser Negativo Ou Zero.");
                }
                
                var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == categoriaId);
                if (categoria == null)
                {
                    throw new KeyNotFoundException($"Nenhuma Categoria Encontrada com o ID {categoriaId}.");
                }
                
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Deletar A Categoria. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Delete>

    #region <Get>
        public async Task<PagedList<CategoriaEntity>> GetAllCategoriasAsync(int pageNumber, int pageSize)
        {
            try
            {
                var categorias = await _context.Categorias.AsNoTracking().ToListAsync();
                if(categorias == null)
                {
                    throw new KeyNotFoundException($"Categorias Não Foram Encontradas.");
                }
                var query = _context.Categorias.AsQueryable();
                return await PaginationHelper.CreateAsync(query,pageNumber, pageSize);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Ao Obter As Categorias. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Get>

    #region <GetId>
        public async Task<CategoriaEntity?> GetCategoriaByIdAsync(int categoriaId)
        {
            try
            {
                if (categoriaId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(categoriaId), "O ID Da Categoria Não Deve Ser Negativo Ou Zero.");
                }
                var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == categoriaId);
                if (categoria == null)
                {
                    throw new KeyNotFoundException("Categoria Não Foi Encontrado.");
                }
                return categoria;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Buscar A Categoria Com ID {categoriaId}. Erro: {ex.Message}");
                return null;
            }
        }
    #endregion </GetId>

    #region <Update>
        public async Task<CategoriaEntity> UpdateCategoriaAsync(CategoriaEntity categoria)
        {
            try
            {
                if(categoria == null)
                {
                    throw new ArgumentNullException(nameof(categoria),"A Entidade Categoria Não Deve Ser Vazia Ou Nula.");
                }
                _context.Categorias.Update(categoria);
                var result = await _context.SaveChangesAsync();

                if (result == 0)
                {
                    throw new WarningException($"Nenhuma Modificação Foi Realizada Ao Editar A Categoria Com ID {categoria.Id}.");
                }
                return categoria;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Editar A Categoria. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Update>
    
}
