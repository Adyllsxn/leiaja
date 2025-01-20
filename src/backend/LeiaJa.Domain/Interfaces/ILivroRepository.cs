namespace LeiaJa.Domain.Interfaces;
public interface ILivroRepository
{
    Task<List<LivroEntity>> CreateLivroAsync(LivroEntity livro);
    Task<LivroEntity?> DeleteLivroAsync(int livroId);
    Task<PagedList<LivroEntity>> GetAllLivrosAsync(int pageNumber, int pageSize);
    Task<LivroEntity?> GetLivroByIdAsync(int livroId);
    Task<LivroEntity> UpdateLivroAsync(LivroEntity livro);
}
