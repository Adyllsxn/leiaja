
namespace LeiaJa.Infrastructure.Repositories;
public class EmprestimoRepository : IEmprestimoRepository
{
    public Task<List<EmprestimoEntity>> CreateEmprestimoAsync(EmprestimoEntity emprestimo)
    {
        throw new NotImplementedException();
    }

    public Task<EmprestimoEntity?> DeleteEmprestimoAsync(int emprestimoId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<EmprestimoEntity>> GetAllEmprestimosAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<EmprestimoEntity?> GetEmprestimoByIdAsync(int emprestimoId)
    {
        throw new NotImplementedException();
    }

    public Task<EmprestimoEntity> UpdateEmprestimoAsync(EmprestimoEntity emprestimo)
    {
        throw new NotImplementedException();
    }
}
