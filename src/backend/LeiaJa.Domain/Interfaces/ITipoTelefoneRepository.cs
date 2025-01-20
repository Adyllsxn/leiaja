namespace LeiaJa.Domain.Interfaces;
public interface ITipoTelefoneRepository
{
    Task<List<TipoTelefoneEntity>> GetTipoTelefonesAsync();
    Task<TipoTelefoneEntity> GetTipoTelefoneByIdAsync(int tipoTelefoneId);
}
