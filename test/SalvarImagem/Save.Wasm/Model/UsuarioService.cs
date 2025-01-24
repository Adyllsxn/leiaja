using System.Net.Http.Json;

namespace Save.Wasm.Model;
public class UsuarioService
{
    private readonly HttpClient _httpClient;

    public UsuarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("usuario");
    }

    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Usuario>($"usuario/{id}");
    }

    public async Task CreateUsuarioAsync(Usuario usuario)
    {
        await _httpClient.PostAsJsonAsync("usuario", usuario);
    }

    public async Task UpdateUsuarioAsync(Usuario usuario)
    {
        await _httpClient.PutAsJsonAsync($"usuario/{usuario.Id}", usuario);
    }

    public async Task DeleteUsuarioAsync(int id)
    {
        await _httpClient.DeleteAsync($"usuario/{id}");
    }
}
