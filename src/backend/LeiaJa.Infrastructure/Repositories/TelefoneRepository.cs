
namespace LeiaJa.Infrastructure.Repositories;
public class TelefoneRepository : ITelefoneRepository
{
    public Task<List<TelefoneEntity>> CreateTelefoneAsync(TelefoneEntity telefone)
    {
        throw new NotImplementedException();
    }

    public Task<TelefoneEntity?> DeleteTelefoneAsync(int telefoneId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<TelefoneEntity>> GetAllTelefonesAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<TelefoneEntity?> GetTelefoneByIdAsync(int telefoneId)
    {
        throw new NotImplementedException();
    }

    public Task<TelefoneEntity> UpdateTelefoneAsync(TelefoneEntity telefone)
    {
        throw new NotImplementedException();
    }
}
