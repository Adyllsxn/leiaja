namespace LeiaJa.Domain.Interfaces;
public interface IProvinciaRepository
{
    Task<PagedList<ProvinciaEntity>> GetAllProvinciasAsync(int pageNumber, int pageSize);
    Task<List<ProvinciaEntity>> CreateProvinciaAsync(ProvinciaEntity provincia);
    Task<ProvinciaEntity> UpdateProvinciaAsync(ProvinciaEntity provincia);
    Task<ProvinciaEntity?> DeleteProvinciaAsync(int provinciaId);
    Task<ProvinciaEntity?> GetProvinciaByIdAsync(int provinciaId);
}
