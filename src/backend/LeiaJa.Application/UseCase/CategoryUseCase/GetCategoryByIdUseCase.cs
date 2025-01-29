namespace LeiaJa.Application.UseCase.CategoryUseCase;
public class GetCategoryByIdUseCase(ICategoryRepository _repository, IMapper _mapper)
{
        public async Task<ResponseModel<CategoryDTO>> GetCategoriaByIdAsync(int categoryId)
        {   
            ResponseModel<CategoryDTO> response = new();
            try
            { 
                if(categoryId <= 0)
                {
                    response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                    return response;
                }
                var category = await _repository.GetCategoryByIdAsync(categoryId);
                var categoryDTO = _mapper.Map<CategoryDTO>(category);
                if(categoryDTO == null)
                {
                    response.Message = $"Não Existe A Categoria Com ID {categoryId}!";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = categoryDTO;
                response.Message = $"Foi Encontrado Categoria Com ID = {categoryId}!";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Obter A Categoria. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
