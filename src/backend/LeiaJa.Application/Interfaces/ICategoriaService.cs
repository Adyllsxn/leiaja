namespace LeiaJa.Application.Interfaces;
public interface ICategoriaService
{
    Task<ResponseModel<PagedList<CategoriaDTO>>> GetAllCategoriasAsync(int pageNumber, int pageSize);
    Task<ResponseModel<List<CategoriaDTO>>> CreateCategoriaAsync(CategoriaPostDTO categoriaPostDTO);
    Task<ResponseModel<CategoriaDTO>> UpdateCategoriaAsync(CategoriaDTO categoriaDTO);
    Task<ResponseModel<CategoriaDTO>> DeleteCategoriaAsync(int categoriaId);
    Task<ResponseModel<CategoriaDTO>> GetCategoriaByIdAsync(int categoriaId);
}
