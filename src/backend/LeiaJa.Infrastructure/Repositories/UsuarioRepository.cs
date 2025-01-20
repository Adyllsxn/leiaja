
namespace LeiaJa.Infrastructure.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    public Task<List<UsuarioEntity>> CreateUsuarioAsync(UsuarioEntity usuario)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioEntity?> DeleteUsuarioAsync(int usuarioId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<UsuarioEntity>> GetAllUsuariosAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioEntity?> GetUsuarioByIdAsync(int usuarioId)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioEntity> UpdateUsuarioAsync(UsuarioEntity usuario)
    {
        throw new NotImplementedException();
    }
}
