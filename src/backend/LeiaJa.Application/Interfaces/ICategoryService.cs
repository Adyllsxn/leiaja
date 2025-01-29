namespace LeiaJa.Application.Interfaces;
public interface ICategoryService
{
    Task<ResponseModel<List<CategoryDTO>>> GetCategoriesAsync();
    Task<ResponseModel<CategoryDTO>> GetCategoriaByIdAsync(int categoryId);
    Task<ResponseModel<CategoryDTO>> DeleteCategoryAsync(int categoryId);
    Task<ResponseModel<List<CategoryDTO>>> CreateCategoryAsync(CategoryPostDTO categoryPostDTO);
    Task<ResponseModel<CategoryDTO>> UpdateCategoryAsync(CategoryDTO categoryDTO);
}
