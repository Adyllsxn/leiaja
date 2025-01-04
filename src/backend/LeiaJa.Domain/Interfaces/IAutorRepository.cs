namespace LeiaJa.Domain.Interfaces;
public interface IAutorRepository
{
    Task<PagedList<AutorEntity>> GetAllAutoresAsync(int pageNumber, int pageSize);
    Task<List<AutorEntity>> CreateAutorAsync(AutorEntity autor);
    Task<AutorEntity> UpdateAutorAsync(AutorEntity autor);
    Task<AutorEntity?> DeleteAutorAsync(int autorId);
    Task<AutorEntity?> GetAutorByIdAsync(int autorId);
}
