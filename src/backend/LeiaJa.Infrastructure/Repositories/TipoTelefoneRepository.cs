
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
        public Task<TipoTelefoneEntity> GetTipoTelefoneByIdAsync(int tipoTelefoneId)
        {
            throw new NotImplementedException();
        }
    #endregion </GetId>
    
    #region <Get>
        public Task<List<TipoTelefoneEntity>> GetTipoTelefonesAsync()
        {
            throw new NotImplementedException();
        }
    #endregion </Get>
}
