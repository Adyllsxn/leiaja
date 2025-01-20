
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
        public Task<GeneroEntity> GetGeneroByIdAsync(int generoId)
        {
            throw new NotImplementedException();
        }
    #endregion </GetId>

    #region <Get>
        public Task<List<GeneroEntity>> GetGenerosAsync()
        {
            throw new NotImplementedException();
        }
    #endregion </Get>
}
