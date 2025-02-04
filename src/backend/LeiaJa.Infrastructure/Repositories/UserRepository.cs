namespace LeiaJa.Infrastructure.Repositories;
public class UserRepository(AppDbContext _context, ILogger<UserEntity> _logger) : IUserRepository
{
    #region <Create>
        public async Task<List<UserEntity>> CreateUserAsync(UserEntity user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "Os campos não devem ser vazios.");
                }

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return await _context.Users.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao salvar o usuário. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion</Create>
    
    #region <Delete>
        public async Task<UserEntity?> DeleteUserAsync(int userId)
        {
            try
            {
                if (userId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(userId), "O ID Do Usuário Não Deve Ser Negativo Ou Zero.");
                }
                
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null)
                {
                    throw new KeyNotFoundException($"Nenhum Usuário Encontrada com o ID {userId}.");
                }
                
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Deletar O Autor. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Delete>

    #region <Exist>
    public async Task<bool> ExistUserRegisterAsync()
    {
        try
        {
            return await _context.Users.AsNoTracking().AnyAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion </Exist>

    #region <GetId>
        public async Task<UserEntity?> GetUserByIdAsync(int userId)
        {
            try
            {
                if (userId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(userId), "O ID Do Usuário Não Deve Ser Negativo Ou Zero.");
                }
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null)
                {
                    throw new KeyNotFoundException("Usuário Não Foi Encontrado.");
                }
                return user;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Buscar o Usuário Com ID {userId}. Erro: {ex.Message}");
                return null;
            }
        }
    #endregion </GetId>

    #region <Get>
        public async Task<List<UserEntity>> GetUsersAsync()
        {
            try
                {
                    var users = await _context.Users.AsNoTracking().ToListAsync();
                    if(users == null)
                    {
                        throw new KeyNotFoundException($"Usuário não foram encontradas.");
                    }
                    return users;
                }
                catch(Exception ex)
                {
                    _logger.LogError($"Ocorreu um ao obter os usuários. Erro: {ex.Message}");
                    return null!; 
                }
        }
    #endregion </Get>

    #region <Update>
    public async Task<UserEntity> UpdateUserAsync(UserEntity user)
        {
            try
            {
                if(user == null)
                {
                    throw new ArgumentNullException(nameof(user),"Usuário Não Deve Ser Vazia Ou Nula.");
                }
                _context.Users.Update(user);
                var result = await _context.SaveChangesAsync();

                if (result == 0)
                {
                    throw new WarningException($"Nenhuma Modificação Foi Realizada Ao Editar O usuário Com ID {user.Id}.");
                }
                return user;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Editar O Usuário. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Update>

    #region <Search>
        public async Task<List<UserEntity>> SearchUserAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            try
            {
                return await _context.Users.AsNoTracking().Where(predicate).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um ao pesquisar os autores. Erro: {ex.Message}");
                return null!; 
            }
        }
    #endregion </Search>
}
