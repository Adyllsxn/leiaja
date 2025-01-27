namespace LeiaJa.Application.Services;
public class LivroService(CreateLivroUseCase _createLivroUseCase,DeleteLivroUseCase _deleteLivroUseCase,UpdateLivroUseCase _updateLivroUseCase,GetLivroByIdUseCase _getLivroByIdUseCase,GetLivrosUseCase _getLivrosUseCase) : ILivroService
{
    public async Task<ResponseModel<LivroDTO>> DeleteLivroAsync(int livroId)
    {
        return await _deleteLivroUseCase.DeleteLivroAsync(livroId);
    }
    public async Task<ResponseModel<List<LivroDTO>>> CreateLivroAsync(LivroPostDTO livroDTO)
    {
        return await _createLivroUseCase.CreateAutorAsync(livroDTO);
    }
    public async Task<ResponseModel<LivroDTO>> UpdateLivroAsync(LivroDTO livroDTO)
    {
        return await _updateLivroUseCase.UpdateLivroAsync(livroDTO);
    }
    public async Task<ResponseModel<PagedList<LivroDTO>>> GetAllLivrosAsync(int pageNumber, int pageSize)
    {
        return await _getLivrosUseCase.GetAllLivrosAsync(pageNumber, pageSize);
    }
    public async Task<ResponseModel<LivroDTO>> GetLivroByIdAsync(int livroId)
    {
        return await _getLivroByIdUseCase.GetLivroByIdAsync(livroId);
    }
}
