namespace LeiaJa.Domain.Interfaces;
public interface ICategoriaRepository
{
    Task<PagedList<CategoriaEntity>> GetAllCategoriasAsync(int pageNumber, int pageSize);
    Task<List<CategoriaEntity>> CreateCategoriaAsync(CategoriaEntity categoria);
    Task<CategoriaEntity> UpdateCategoriaAsync(CategoriaEntity categoria);
    Task<CategoriaEntity?> DeleteCategoriaAsync(int categoriaId);
    Task<CategoriaEntity?> GetCategoriaByIdAsync(int categoriaId);
}
