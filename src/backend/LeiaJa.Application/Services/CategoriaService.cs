namespace LeiaJa.Application.Services;
public class CategoriaService : ICategoriaService
{
    #region CONFIGURATION
    private readonly ICategoriaRepository _repository;
    private readonly IMapper _mapper;
    public CategoriaService(ICategoriaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    #endregion

    #region CRAETE
    public async Task<ResponseModel<List<CategoriaDTO>>> CreateCategoriaAsync(CategoriaPostDTO categoriaPostDTO)
    {
        ResponseModel<List<CategoriaDTO>> response = new();
        try
        {
            if(categoriaPostDTO == null)
            {
                response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                return response;
            }
            var categoria = _mapper.Map<CategoriaEntity>(categoriaPostDTO);
            var createCategoria = await _repository.CreateCategoriaAsync(categoria);
            if(createCategoria == null)
            {
                response.Message = "Falha Ao Salvar A Categoria. Os Parâmetros Podem Estar Inválidos.";
                response.StatusCode = 400;
                return response;
            }

            response.Data = _mapper.Map<List<CategoriaDTO>>(createCategoria);
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
    #endregion

    #region DELETE
    public async Task<ResponseModel<CategoriaDTO>> DeleteCategoriaAsync(int categoriaId)
    {
        ResponseModel<CategoriaDTO> response = new();
        try
        {
            if(categoriaId <= 0)
            {
                response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                return response;
            }
            var deleteCategoria = await _repository.DeleteCategoriaAsync(categoriaId);
            if(deleteCategoria == null)
            {
                response.Message = $"Nenhuma Categoria Encontrado Com O ID {categoriaId}.";
                response.StatusCode = 404;
                return response;
            }
            response.Data = _mapper.Map<CategoriaDTO>(deleteCategoria);
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
    #endregion

    #region GETS
    public async Task<ResponseModel<PagedList<CategoriaDTO>>> GetAllCategoriasAsync(int pageNumber, int pageSize)
    {
        ResponseModel<PagedList<CategoriaDTO>> response = new();
        try
        {
            var categorias = await _repository.GetAllCategoriasAsync(pageNumber, pageSize);
            var categoriasDTOs = _mapper.Map<List<CategoriaDTO>>(categorias);
            if(!categoriasDTOs.Any())
            {
                response.Message = "Nenhuma Categoria Encontrado.";
                response.StatusCode = 404;
                return response;
            }
            response.Data =  new PagedList<CategoriaDTO>(categoriasDTOs, pageNumber, pageSize, categorias.TotalCount);
            response.Message = "Categorias Encontrados";
            response.StatusCode = 200;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = $"Falha Ao Listar As Categorias. Erro: {ex.Message}";
            response.StatusCode = 500;
            return response;
        }
    }
    #endregion

    #region GETID
    public async Task<ResponseModel<CategoriaDTO>> GetCategoriaByIdAsync(int categoriaId)
    {   
        ResponseModel<CategoriaDTO> response = new();
        try
        { 
            if(categoriaId <= 0)
            {
                response.Message = $"O ID Não Deve Ser Menor Ou Igual A Zero.";
                return response;
            }
            var categoria = await _repository.GetCategoriaByIdAsync(categoriaId);
            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            if(categoriaDTO == null)
            {
                response.Message = $"Não Existe A Categoria Com ID {categoriaId}!";
                response.StatusCode = 404;
                return response;
            }
            response.Data = categoriaDTO;
            response.Message = $"Foi Encontrado Categoria Com ID = {categoriaId}!";
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
    #endregion

    #region UPDATE 
    public async Task<ResponseModel<CategoriaDTO>> UpdateCategoriaAsync(CategoriaDTO categoriaDTO)
    {
        ResponseModel<CategoriaDTO> response = new();
        try
        {   
            if(categoriaDTO == null)
            {
                response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                response.StatusCode = 400;
                return response;
            }
            var categoria = _mapper.Map<CategoriaEntity>(categoriaDTO);
            var updateCategoria = await _repository.UpdateCategoriaAsync(categoria);
            if(updateCategoria == null)
            {
                response.Message = "Não Exite";
                response.StatusCode = 404;
                return response;
            }
            response.Data = _mapper.Map<CategoriaDTO>(updateCategoria);
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
    #endregion
}
