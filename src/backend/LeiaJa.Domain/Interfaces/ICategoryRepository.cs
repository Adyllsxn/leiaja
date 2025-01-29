namespace LeiaJa.Domain.Interfaces;
public interface ICategoryRepository : Interface<CategoryEntity>
{
    Task<List<CategoryEntity>> GetCategoriesAsync();
    Task<List<CategoryEntity>> CreateCategoryAsync(CategoryEntity category);
    Task<CategoryEntity?> DeleteCategoryAsync(int categoryId);
    Task<CategoryEntity?> GetCategoryByIdAsync(int categoryId);
    Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category);
}
