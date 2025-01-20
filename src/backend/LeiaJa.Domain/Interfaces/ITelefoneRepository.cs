namespace LeiaJa.Domain.Interfaces;
public interface ITelefoneRepository
{
    Task<List<TelefoneEntity>> CreateTelefoneAsync(TelefoneEntity telefone);
    Task<TelefoneEntity?> DeleteTelefoneAsync(int telefoneId);
    Task<PagedList<TelefoneEntity>> GetAllTelefonesAsync(int pageNumber, int pageSize);
    Task<TelefoneEntity?> GetTelefoneByIdAsync(int telefoneId);
    Task<TelefoneEntity> UpdateTelefoneAsync(TelefoneEntity telefone);
}
