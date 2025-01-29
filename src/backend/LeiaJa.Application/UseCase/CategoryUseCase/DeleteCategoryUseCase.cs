namespace LeiaJa.Application.UseCase.CategoryUseCase;
public class DeleteCategoryUseCase(ICategoryRepository _repository, IMapper _mapper)
{
        public async Task<ResponseModel<CategoryDTO>> DeleteCategoryAsync(int categoryId)
        {
            ResponseModel<CategoryDTO> response = new();
            try
            {
                if(categoryId <= 0)
                {
                    response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                    return response;
                }
                var deleteCategory = await _repository.DeleteCategoryAsync(categoryId);
                if(deleteCategory == null)
                {
                    response.Message = $"Nenhuma Categoria Encontrado Com O ID {categoryId}.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = _mapper.Map<CategoryDTO>(deleteCategory);
                response.Message = "A Categoria Foi Deletado Com Sucesso.";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Deletar A Categoria. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
