
namespace LeiaJa.Infrastructure.Repositories;
public class ProvinciaRepository : IProvinciaRepository
{
    #region CONFIGURATION
    private readonly AppDbContext _context;
    private ILogger<ProvinciaEntity> _logger;
    public ProvinciaRepository(AppDbContext context, ILogger<ProvinciaEntity> logger)
    {
        _context = context;
        _logger = logger;
    }
    #endregion

    #region CREATE
    public async Task<List<ProvinciaEntity>> CreateProvinciaAsync(ProvinciaEntity provincia)
    {
        try
        {
            if (provincia == null)
            {
                throw new ArgumentNullException(nameof(provincia), "Os Campos Não Devem Ser Vazios.");
            }
            await _context.Provincias.AddAsync(provincia);
            await _context.SaveChangesAsync();
            return await _context.Provincias.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu Um Erro Ao Salvar A Província. Erro: {ex.Message}");
            return null!;
        }
    }
    #endregion

    #region DELETE
    public async Task<ProvinciaEntity?> DeleteProvinciaAsync(int provinciaId)
    {
        try
        {
            if(provinciaId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(provinciaId), "O ID Da Província Não Deve Ser Negativo Ou Zero.");
            }
            var provincia = await _context.Provincias.FirstOrDefaultAsync(x => x.Id == provinciaId);
            if (provincia == null)
            {
                throw new KeyNotFoundException($"Nenhuma Província Encontrada com o ID {provinciaId}.");
            }
            _context.Provincias.Remove(provincia);
            await _context.SaveChangesAsync();
            return provincia;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu Um Erro Ao Deletar A Província. Erro: {ex.Message}");
            return null!;
        }
    }
    #endregion

    #region GETS
    public async Task<PagedList<ProvinciaEntity>> GetAllProvinciasAsync(int pageNumber, int pageSize)
    {
        try
        {
            var provincias = await _context.Provincias.AsNoTracking().ToListAsync();
            if(provincias == null)
            {
                throw new KeyNotFoundException($"Províncias Não Foram Encontradas.");
            }
            var query = _context.Provincias.AsQueryable();
            return await PaginationHelper.CreateAsync(query,pageNumber,pageSize);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu Um Erro Ao Obter As Províncias. Erro: {ex.Message}");
            return null!;
        }
    }
    #endregion

    #region GET
    public async Task<ProvinciaEntity?> GetProvinciaByIdAsync(int provinciaId)
    {
        try
        {
            if(provinciaId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(provinciaId),"O ID Da Província Não Deve Ser Negativo Ou Zero.");
            }  
            var provincia = await _context.Provincias.FirstOrDefaultAsync(x => x.Id == provinciaId);
            if(provincia == null)
            {
                throw new KeyNotFoundException("Província Não Foi Encontradas.");
            }
            return provincia;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu Um Erro Ao Obter A Provincia. Erro: {ex.Message}");
            return null!;
        }
    }
    #endregion

    #region UPDATE
    public async Task<ProvinciaEntity> UpdateProvinciaAsync(ProvinciaEntity provincia)
    {
        try
        {
            if(provincia == null)
            {
                throw new ArgumentNullException(nameof(provincia), "Os Campos Não Devem Ser Vazio.");
            }
            _context.Provincias.Update(provincia);
            var result = await _context.SaveChangesAsync();
            if(result == 0)
            {
                throw new WarningException($"Nenhuma Modificação Foi Realizada Ao Editar A Categoria Com ID {provincia.Id}.");
            }
            return provincia;
        }
        catch(Exception ex)
        {
            _logger.LogError($"Ocorreu Um Erro Ao Editar A Província. Erro: {ex.Message}");
            return null!;
        }
    }
    #endregion
}
