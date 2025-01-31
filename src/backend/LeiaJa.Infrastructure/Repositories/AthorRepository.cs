
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
    
    #region <Delete>
        public async Task<AthorEntity?> DeleteAthorAsync(int athorId)
        {
            try
            {
                if (athorId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(athorId), "O ID Do Autor Não Deve Ser Negativo Ou Zero.");
                }
                
                var athor = await _context.Athors.FirstOrDefaultAsync(x => x.Id == athorId);
                if (athor == null)
                {
                    throw new KeyNotFoundException($"Nenhum Atutor Encontrada com o ID {athorId}.");
                }
                
                _context.Athors.Remove(athor);
                await _context.SaveChangesAsync();
                return athor;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Deletar O Autor. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Delete>

    #region <GetId>
        public async Task<AthorEntity?> GetAthorByIdAsync(int athorId)
        {
            try
            {
                if (athorId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(athorId), "O ID Do Autor Não Deve Ser Negativo Ou Zero.");
                }
                var athor = await _context.Athors.FirstOrDefaultAsync(x => x.Id == athorId);
                if (athor == null)
                {
                    throw new KeyNotFoundException("Categoria Não Foi Encontrado.");
                }
                return athor;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Buscar o Autor Com ID {athorId}. Erro: {ex.Message}");
                return null;
            }
        }
    #endregion </GetId>

    #region <Update>
        public async Task<AthorEntity> UpdateAthorAsync(AthorEntity athor)
        {
            try
            {
                if(athor == null)
                {
                    throw new ArgumentNullException(nameof(athor),"A Entidade Autor Não Deve Ser Vazia Ou Nula.");
                }
                _context.Athors.Update(athor);
                var result = await _context.SaveChangesAsync();

                if (result == 0)
                {
                    throw new WarningException($"Nenhuma Modificação Foi Realizada Ao Editar O Autor Com ID {athor.Id}.");
                }
                return athor;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Editar O Autor. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Update>

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

    #region <Search>
        public async Task<List<AthorEntity>> SearchAthorAsync(Expression<Func<AthorEntity, bool>> predicate)
        {
            try
            {
                return await _context.Athors.AsNoTracking().Where(predicate).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um ao pesquisar os autores. Erro: {ex.Message}");
                return null!; 
            }
        }
    #endregion </Search>
}
