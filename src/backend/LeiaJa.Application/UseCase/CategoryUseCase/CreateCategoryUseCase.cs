namespace LeiaJa.Application.UseCase.CategoryUseCase;
public class CreateCategoryUseCase(ICategoryRepository _repository, IMapper _mapper)
{
        public async Task<ResponseModel<List<CategoryDTO>>> CreateCategoryAsync(CategoryPostDTO categoryPostDTO)
        {
            ResponseModel<List<CategoryDTO>> response = new();
            try
            {
                if(categoryPostDTO == null)
                {
                    response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                    return response;
                }
                var category = _mapper.Map<CategoryEntity>(categoryPostDTO);
                var createCategory = await _repository.CreateCategoryAsync(category);
                if(createCategory == null)
                {
                    response.Message = "Falha Ao Salvar A Categoria. Os Parâmetros Podem Estar Inválidos.";
                    response.StatusCode = 400;
                    return response;
                }

                response.Data = _mapper.Map<List<CategoryDTO>>(await _repository.GetCategoriesAsync());
                response.Message = "O Autor Foi Salvo Com Sucesso";
                response.StatusCode = 201;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Salvar A Categoria. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
