namespace LeiaJa.Application.UseCase.CategoryUseCase;
public class UpdateCategoryUseCase(ICategoryRepository _repository, IMapper _mapper)
{
        public async Task<ResponseModel<CategoryDTO>> UpdateCategoryAsync(CategoryDTO categoryDTO)
        {
            ResponseModel<CategoryDTO> response = new();
            try
            {   
                if(categoryDTO == null)
                {
                    response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                    response.StatusCode = 400;
                    return response;
                }
                var category = _mapper.Map<CategoryEntity>(categoryDTO);
                var updateCategory = await _repository.UpdateCategoryAsync(category);
                if(updateCategory == null)
                {
                    response.Message = "Não Exite";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = _mapper.Map<CategoryDTO>(updateCategory);
                response.Message = "Categoria Editada Com Sucesso!";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Editar A Categoria. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
