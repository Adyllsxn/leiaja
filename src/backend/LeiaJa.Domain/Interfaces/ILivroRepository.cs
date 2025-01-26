namespace LeiaJa.Domain.Interfaces;
public interface ILivroRepository : Interface<LivroEntity>
{
    Task<List<LivroEntity>> CreateLivroAsync(LivroEntity livro);
    Task<LivroEntity?> DeleteLivroAsync(int livroId);
    Task<PagedList<LivroEntity>> GetAllLivrosAsync(int pageNumber, int pageSize);
    Task<LivroEntity?> GetLivroByIdAsync(int livroId);
    Task<LivroEntity> UpdateLivroAsync(LivroEntity livro);
    Task<List<LivroEntity>> SearchAutorAsync(Expression<Func<LivroEntity, bool>> predicate);
}
