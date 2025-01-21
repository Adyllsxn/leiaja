
namespace LeiaJa.Infrastructure.Repositories;
public class GeneroRepository : IGeneroRepository
{
    #region <Configuration>
        private readonly AppDbContext _context;
        private readonly ILogger<GeneroEntity> _logger;
        public GeneroRepository(AppDbContext context, ILogger<GeneroEntity> logger)
        {
            _context = context;
            _logger = logger;
        }
    #endregion </Configuration>
    
    #region <GetId>
        public async Task<GeneroEntity> GetGeneroByIdAsync(int generoId)
        {
            try
            {
                if(generoId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(generoId));
                }
                var genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == generoId);
                if(genero == null)
                {
                    throw new KeyNotFoundException(nameof(genero));
                }
                return genero;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro ao buscar o genero com ID {generoId}. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </GetId>

    #region <Get>
        public async Task<List<GeneroEntity>> GetGenerosAsync()
        {
            try
            {
                return await _context.Generos.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro ao buscar os autor generos. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Get>
}
