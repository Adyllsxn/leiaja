namespace LeiaJa.Application.Services;
public class CategoryService(GetCategoriesUseCase _get, GetCategoryByIdUseCase _getbyid, DeleteCategoryUseCase _delete, CreateCategoryUseCase _create, UpdateCategoryUseCase _update) : ICategoryService
{
    public async Task<ResponseModel<List<CategoryDTO>>> CreateCategoryAsync(CategoryPostDTO categoryPostDTO)
    {
        return await _create.CreateCategoryAsync(categoryPostDTO);
    }

    public async Task<ResponseModel<CategoryDTO>> DeleteCategoryAsync(int categoryId)
    {
        return await  _delete.DeleteCategoryAsync(categoryId);
    }

    public async Task<ResponseModel<CategoryDTO>> GetCategoriaByIdAsync(int categoryId)
    {
        return await _getbyid.GetCategoriaByIdAsync(categoryId);
    }

    public async Task<ResponseModel<List<CategoryDTO>>> GetCategoriesAsync()
    {
        return await _get.GetCategoriesAsync();
    }

    public async Task<ResponseModel<CategoryDTO>> UpdateCategoryAsync(CategoryDTO categoryDTO)
    {
        return await _update.UpdateCategoryAsync(categoryDTO);
    }
}
