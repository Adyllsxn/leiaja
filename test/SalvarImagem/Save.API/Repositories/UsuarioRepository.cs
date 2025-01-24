using Microsoft.EntityFrameworkCore;
using Save.API.Context;
using Save.API.Interfaces;
using Save.API.Model;

namespace Save.API.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> UpdateAsync(int id, Usuario usuario)
        {
            var existingUser = await _context.Usuarios.FindAsync(id);
            if (existingUser == null)
                return null;

            existingUser.Nome = usuario.Nome;
            existingUser.Email = usuario.Email;
            existingUser.Telefone = usuario.Telefone;
            existingUser.Foto = usuario.Foto; // Atualiza a foto se for fornecida

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
}
