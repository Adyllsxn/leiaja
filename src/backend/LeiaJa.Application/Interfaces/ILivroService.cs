namespace LeiaJa.Application.Interfaces;
public interface ILivroService
{
    Task<ResponseModel<LivroDTO>> DeleteLivroAsync(int livroId);
    Task<ResponseModel<List<LivroDTO>>> CreateLivroAsync(LivroPostDTO livroDTO);
    Task<ResponseModel<LivroDTO>> UpdateLivroAsync(LivroDTO livroDTO);
    Task<ResponseModel<PagedList<LivroDTO>>> GetAllLivrosAsync(int pageNumber, int pageSize);
    Task<ResponseModel<LivroDTO>> GetLivroByIdAsync(int livroId);
}
