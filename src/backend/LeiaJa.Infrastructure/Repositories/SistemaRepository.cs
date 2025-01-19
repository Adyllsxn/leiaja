namespace LeiaJa.Infrastructure.Repositories;
public class SistemaRepository : ISistemaRepository
{
    #region <Configuration>
        private readonly AppDbContext _context;
        public SistemaRepository(AppDbContext context)
        {
            _context = context;
        }
    #endregion </Configuration>

    #region <Get>
        public async Task<QuantidadeEntity> GetQtdItems()
        {
            QuantidadeEntity quantidadeItens =  new  QuantidadeEntity();
            quantidadeItens.QtdAutor = await _context.Autores.CountAsync();
            quantidadeItens.QtdCategoria = await _context.Categorias.CountAsync();
            return quantidadeItens;
        }
    #endregion </Get>
}
