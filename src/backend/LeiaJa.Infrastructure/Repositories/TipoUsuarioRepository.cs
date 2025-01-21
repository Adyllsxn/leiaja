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
        public async Task<TipoUsuarioEntity> GetTipoUsuarioByIdAsync(int tipoUsuarioId)
        {
            try
            {
                if(tipoUsuarioId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(tipoUsuarioId));
                }
                var tipoUsuario = await _context.TipoUsuarios.FirstOrDefaultAsync(x => x.Id == tipoUsuarioId);
                if(tipoUsuario == null)
                {
                    throw new KeyNotFoundException(nameof(tipoUsuario));
                }
                return tipoUsuario;
            }
            catch(Exception ex)
            {
                _looger.LogError($"Ocorreu um erro ao obter o tipo de usuário com ID {tipoUsuarioId}. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </GetId>

    #region <Git>
        public async Task<List<TipoUsuarioEntity>> GetTipoUsuariosAsync()
        {
            try
            {
                return await _context.TipoUsuarios.ToListAsync();
            }
            catch(Exception ex)
            {
                _looger.LogError($"Ocorreu um erro ao obter os tipos de usuários. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Git>
}
