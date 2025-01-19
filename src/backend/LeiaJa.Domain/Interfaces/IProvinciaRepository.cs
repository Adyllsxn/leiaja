namespace LeiaJa.Domain.Interfaces;
public interface IProvinciaRepository
{
    Task<List<ProvinciaEntity>> CreateProvinciaAsync(ProvinciaEntity provincia);
    Task<ProvinciaEntity?> DeleteProvinciaAsync(int provinciaId);
    Task<PagedList<ProvinciaEntity>> GetAllProvinciasAsync(int pageNumber, int pageSize);
    Task<ProvinciaEntity?> GetProvinciaByIdAsync(int provinciaId);
    Task<ProvinciaEntity> UpdateProvinciaAsync(ProvinciaEntity provincia);
}
