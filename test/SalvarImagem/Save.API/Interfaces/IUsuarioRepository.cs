using Save.API.Model;

namespace Save.API.Interfaces;
public interface IUsuarioRepository
{
        Task<Usuario> AddAsync(Usuario usuario);
        Task<Usuario> GetByIdAsync(int id);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> UpdateAsync(int id, Usuario usuario);
        Task<bool> DeleteAsync(int id);
}