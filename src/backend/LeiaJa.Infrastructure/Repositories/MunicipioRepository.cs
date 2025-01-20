namespace LeiaJa.Infrastructure.Repositories;
public class MunicipioRepository : IMunicipioRepository
{
    #region <Configuartion>
        private readonly AppDbContext _context;
        private readonly ILogger<MunicipioEntity> _logger;
        public MunicipioRepository(AppDbContext context, ILogger<MunicipioEntity> logger)
        {
            _context = context;
            _logger = logger;
        }
    #endregion </Configuartion>
    
    #region <Create>
        public Task<List<MunicipioEntity>> CreateMunicipioAsync(MunicipioEntity municipio)
        {
            throw new NotImplementedException();
        }
    #endregion </Create>

    #region <Delete>
        public Task<MunicipioEntity?> DeleteMunicipioAsync(int municipioId)
        {
            throw new NotImplementedException();
        }
    #endregion </Delete>

    #region <Get>
        public Task<PagedList<MunicipioEntity>> GetAllMunicipiosAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    #endregion </Get>

    #region <GetId>
        public Task<MunicipioEntity?> GetMunicipioByIdAsync(int municipioId)
        {
            throw new NotImplementedException();
        }
    #endregion </GetId>

    #region <Update>
        public Task<MunicipioEntity> UpdateMunicipioAsync(MunicipioEntity Municipio)
        {
            throw new NotImplementedException();
        }
    #endregion </Update>
}
