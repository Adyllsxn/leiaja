
namespace LeiaJa.Infrastructure.Repositories;
public class LivroRepository : ILivroRepository
{
    public Task<List<LivroEntity>> CreateLivroAsync(LivroEntity livro)
    {
        throw new NotImplementedException();
    }

    public Task<LivroEntity?> DeleteLivroAsync(int livroId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<LivroEntity>> GetAllLivrosAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<LivroEntity?> GetLivroByIdAsync(int livroId)
    {
        throw new NotImplementedException();
    }

    public Task<LivroEntity> UpdateLivroAsync(LivroEntity livro)
    {
        throw new NotImplementedException();
    }
}
