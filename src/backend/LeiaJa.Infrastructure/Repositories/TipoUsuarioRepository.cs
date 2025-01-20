namespace LeiaJa.Infrastructure.Repositories;
public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    #region <Configuration>
        private readonly AppDbContext _context;
        private readonly ILogger<TipoUsuarioEntity> _looger;
        public TipoUsuarioRepository(AppDbContext context, ILogger<TipoUsuarioEntity> logger)
        {
            _context = context;
            _looger = logger;
        }
    #endregion </Configuration>

    #region <GetId>
        public Task<TipoUsuarioEntity> GetTipoUsuarioByIdAsync(int tipoUsuarioId)
        {
            throw new NotImplementedException();
        }
    #endregion </GetId>

    #region <Git>
        public Task<List<TipoUsuarioEntity>> GetTipoUsuariosAsync()
        {
            throw new NotImplementedException();
        }
    #endregion </Git>
}
