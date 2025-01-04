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

    #region CRAETE CATEGORIA
    public Task<ResponseModel<List<CategoriaDTO>>> CreateCategoriaAsync(CategoriaPostDTO categoriaPostDTO)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region DELETE CATEGORIA
    public Task<ResponseModel<CategoriaDTO>> DeleteCategoriaAsync(int categoriaId)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region GET ALL CATEGORIA
    public Task<ResponseModel<PagedList<CategoriaDTO>>> GetAllCategoriasAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region GET CATEGORIA BY ID
    public Task<ResponseModel<CategoriaDTO>> GetCategoriaByIdAsync(int categoriaId)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region UPDATE CATEGORIA
    public Task<ResponseModel<CategoriaDTO>> UpdateCategoriaAsync(CategoriaDTO categoriaDTO)
    {
        throw new NotImplementedException();
    }
    #endregion
}
