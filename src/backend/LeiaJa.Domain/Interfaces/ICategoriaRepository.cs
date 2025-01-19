namespace LeiaJa.Domain.Interfaces;
public interface ICategoriaRepository
{
    Task<List<CategoriaEntity>> CreateCategoriaAsync(CategoriaEntity categoria);
    Task<CategoriaEntity?> DeleteCategoriaAsync(int categoriaId);
    Task<PagedList<CategoriaEntity>> GetAllCategoriasAsync(int pageNumber, int pageSize);
    Task<CategoriaEntity?> GetCategoriaByIdAsync(int categoriaId);
    Task<CategoriaEntity> UpdateCategoriaAsync(CategoriaEntity categoria);
}
