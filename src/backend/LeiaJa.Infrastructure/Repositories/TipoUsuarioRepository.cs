namespace LeiaJa.Infrastructure.Repositories;
public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    #region <Configuration>
    #endregion </Configuration>

    #region <Create>
        public Task<List<TipoUsuarioEntity>> CreateTipoUsuarioAsync(TipoUsuarioEntity tipoUsuario)
        {
            throw new NotImplementedException();
        }
    #endregion </Create>

    #region <Delete>
        public Task<TipoUsuarioEntity?> DeleteTipoUsuarioAsync(int tipoUsuarioId)
        {
            throw new NotImplementedException();
        }
    #endregion </Delete>

    #region <Get>
        public Task<PagedList<TipoUsuarioEntity>> GetAllTipoUsuariosAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    #endregion </Get>

    #region <GetId>
        public Task<TipoUsuarioEntity?> GetTipoUsuarioByIdAsync(int tipoUsuarioId)
        {
            throw new NotImplementedException();
        }
    #endregion </GetId>

    #region <Update>
        public Task<TipoUsuarioEntity> UpdateTipoUsuarioAsync(TipoUsuarioEntity tipoUsuario)
        {
            throw new NotImplementedException();
        }
    #endregion </Update>
}
