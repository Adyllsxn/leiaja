namespace LeiaJa.Domain.Interfaces;
public interface IEmprestimoRepository
{
    Task<List<EmprestimoEntity>> CreateEmprestimoAsync(EmprestimoEntity emprestimo);
    Task<EmprestimoEntity?> DeleteEmprestimoAsync(int emprestimoId);
    Task<PagedList<EmprestimoEntity>> GetAllEmprestimosAsync(int pageNumber, int pageSize);
    Task<EmprestimoEntity?> GetEmprestimoByIdAsync(int emprestimoId);
    Task<EmprestimoEntity> UpdateEmprestimoAsync(EmprestimoEntity emprestimo);
}
