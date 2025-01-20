namespace LeiaJa.Domain.Interfaces;
public interface IGeneroRepository
{
    Task<List<GeneroEntity>> GetGenerosAsync();
    Task<GeneroEntity> GetGeneroByIdAsync(int generoId);
}
