namespace LeiaJa.Domain.Interfaces;
public interface IUsuarioRepository
{
    Task<List<UsuarioEntity>> CreateUsuarioAsync(UsuarioEntity usuario);
    Task<UsuarioEntity?> DeleteUsuarioAsync(int usuarioId);
    Task<PagedList<UsuarioEntity>> GetAllUsuariosAsync(int pageNumber, int pageSize);
    Task<UsuarioEntity?> GetUsuarioByIdAsync(int usuarioId);
    Task<UsuarioEntity> UpdateUsuarioAsync(UsuarioEntity usuario);
}
