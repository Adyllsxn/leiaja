namespace LeiaJa.Infrastructure.Repositories;
public class AthorRepository(AppDbContext _context, ILogger<AthorEntity> _logger) : IAthorRepository
{
    #region <Create>
        public async Task<List<AthorEntity>> CreateAthorAsync(AthorEntity athor)
        {
            try
            {
                if (athor == null)
                {
                    throw new ArgumentNullException(nameof(athor), "Os campos não devem ser vazios.");
                }

                await _context.Athors.AddAsync(athor);
                await _context.SaveChangesAsync();
                return await _context.Athors.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao salvar o autor. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Create>

    #region </Get>
        public async Task<List<AthorEntity>> GetAthorsAsync()
        {
            try
                {
                    var athors = await _context.Athors.ToListAsync();
                    if(athors == null)
                    {
                        throw new KeyNotFoundException($"Autores não foram encontradas.");
                    }
                    return athors;
                }
                catch(Exception ex)
                {
                    _logger.LogError($"Ocorreu um ao obter os autores. Erro: {ex.Message}");
                    return null!; 
                }
        }
    #endregion </Get>
}
