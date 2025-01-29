namespace LeiaJa.Application.UseCase.CategoryUseCase;
public class GetCategoriesUseCase(ICategoryRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<CategoryDTO>>> GetCategoriesAsync()
    {
        ResponseModel<List<CategoryDTO>> response = new ();
        try
        {       
                var categories = await _repository.GetCategoriesAsync();
                var categoryDTOs = _mapper.Map<List<CategoryDTO>>(categories);
                if(!categoryDTOs.Any())
                {
                    response.Message = "Nenhuma categoria encontrado.";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data =  categoryDTOs.ToList();
                response.Message = "Categorias encontrados";
                response.StatusCode = 200;
                return response;
        }
        catch (Exception ex)
        {
                response.Message = $"Falha ao listar as categorias. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
        }
    }
}
