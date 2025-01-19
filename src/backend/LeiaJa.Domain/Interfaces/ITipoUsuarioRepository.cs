namespace LeiaJa.Domain.Interfaces;
public interface ITipoUsuarioRepository
{
    Task<List<TipoUsuarioEntity>> CreateTipoUsuarioAsync(TipoUsuarioEntity tipoUsuario);
    Task<TipoUsuarioEntity?> DeleteTipoUsuarioAsync(int tipoUsuarioId);
    Task<PagedList<TipoUsuarioEntity>> GetAllTipoUsuariosAsync(int pageNumber, int pageSize);
    Task<TipoUsuarioEntity?> GetTipoUsuarioByIdAsync(int tipoUsuarioId);
    Task<TipoUsuarioEntity> UpdateTipoUsuarioAsync(TipoUsuarioEntity tipoUsuario);
}
