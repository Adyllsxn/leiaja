
namespace LeiaJa.Infrastructure.Repositories;
public class TipoTelefoneRepository : ITipoTelefoneRepository
{   
    #region <Configuration>
        private readonly AppDbContext _context;
        private readonly ILogger<TipoTelefoneEntity> _logger;
        public TipoTelefoneRepository(AppDbContext context, ILogger<TipoTelefoneEntity> logger)
        {
            _context = context;
            _logger = logger;
        }
    #endregion </Configuration>

    #region <GetId>
        public async Task<TipoTelefoneEntity> GetTipoTelefoneByIdAsync(int tipoTelefoneId)
        {
            try
            {
                if(tipoTelefoneId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(tipoTelefoneId));
                }
                var tipoTelefone = await _context.TipoTelefones.FirstOrDefaultAsync(x => x.Id == tipoTelefoneId);
                if(tipoTelefone == null)
                {
                    throw new KeyNotFoundException(nameof(tipoTelefone));
                }
                return tipoTelefone;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter o tipo de telefone com o ID {tipoTelefoneId}. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </GetId>
    
    #region <Get>
        public async Task<List<TipoTelefoneEntity>> GetTipoTelefonesAsync()
        {
            try
            {
                return await _context.TipoTelefones.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter os tipos de telefones");
                return null!;
            }
        }
    #endregion </Get>
}
