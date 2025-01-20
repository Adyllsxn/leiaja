namespace LeiaJa.Domain.Interfaces;
public interface ITipoUsuarioRepository
{
    Task<List<TipoUsuarioEntity>> GetTipoUsuariosAsync();
    Task<TipoUsuarioEntity> GetTipoUsuarioByIdAsync(int tipoUsuarioId);
}
