namespace LeiaJa.Domain.Interfaces;
public interface IAutorRepository
{    
    Task<List<AutorEntity>> CreateAutorAsync(AutorEntity autor);
    Task<AutorEntity?> DeleteAutorAsync(int autorId);
    Task<PagedList<AutorEntity>> GetAllAutoresAsync(int pageNumber, int pageSize);
    Task<AutorEntity?> GetAutorByIdAsync(int autorId);
    Task<AutorEntity> UpdateAutorAsync(AutorEntity autor);
}
