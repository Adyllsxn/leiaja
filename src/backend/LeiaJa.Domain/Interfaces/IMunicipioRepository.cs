namespace LeiaJa.Domain.Interfaces;
public interface IMunicipioRepository
{
    Task<List<MunicipioEntity>> CreateMunicipioAsync(MunicipioEntity municipio);
    Task<MunicipioEntity?> DeleteMunicipioAsync(int municipioId);
    Task<PagedList<MunicipioEntity>> GetAllMunicipiosAsync(int pageNumber, int pageSize);
    Task<MunicipioEntity?> GetMunicipioByIdAsync(int municipioId);
    Task<MunicipioEntity> UpdateMunicipioAsync(MunicipioEntity municipio);
}
