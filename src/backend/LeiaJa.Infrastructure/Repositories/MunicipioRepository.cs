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
        public async Task<List<MunicipioEntity>> CreateMunicipioAsync(MunicipioEntity municipio)
        {
            try
            {
                if(municipio == null)
                {
                    throw new ArgumentNullException(nameof(municipio));
                }
                _context.Municipios.Add(municipio);
                await _context.SaveChangesAsync();
                return await _context.Municipios.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao criar o municipio. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Create>

    #region <Delete>
        public async Task<MunicipioEntity?> DeleteMunicipioAsync(int municipioId)
        {
            try
            {   
                if(municipioId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(municipioId));
                }
                var municipio = await _context.Municipios.FirstOrDefaultAsync(x => x.Id == municipioId);
                if(municipio == null)
                {
                    throw new KeyNotFoundException(nameof(municipio));
                }
                _context.Municipios.Remove(municipio);
                await _context.SaveChangesAsync();
                return municipio;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao deletar o municipio. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Delete>

    #region <Get>
        public async Task<PagedList<MunicipioEntity>> GetAllMunicipiosAsync(int pageNumber, int pageSize)
        {
            try
            {
                var municipios = await _context.Municipios.ToListAsync();
                if(municipios == null)
                {
                    throw new KeyNotFoundException(nameof(municipios));
                }
                var query = _context.Municipios.AsQueryable();
                return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obeter os municipios. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Get>

    #region <GetId>
        public async Task<MunicipioEntity?> GetMunicipioByIdAsync(int municipioId)
        {
            try
            {
                if(municipioId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(municipioId));
                }
                var municipio = await _context.Municipios.FirstOrDefaultAsync(x => x.Id == municipioId);
                if(municipio == null)
                {
                    throw new KeyNotFoundException(nameof(municipio));
                }
                return municipio;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter o municipio com ID {municipioId}. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </GetId>

    #region <Update>
        public async Task<MunicipioEntity> UpdateMunicipioAsync(MunicipioEntity municipio)
        {
            try
            {
                if(municipio == null)
                {
                    throw new ArgumentNullException(nameof(municipio));
                }
                _context.Municipios.Update(municipio);
                var result = await _context.SaveChangesAsync();
                if(result == 0)
                {
                    throw new WarningException(nameof(municipio));
                }
                return municipio;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao atualizar os municipios. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Update>
}
