namespace LeiaJa.Infrastructure.Repositories;
public class SistemaRepository : ISistemaRepository
{
    private readonly AppDbContext _context;
    public SistemaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<QuantidadeEntity> GetQtdItems()
    {
        QuantidadeEntity quantidadeItens =  new  QuantidadeEntity();
        quantidadeItens.QtdAutor = await _context.Autores.CountAsync();
        return quantidadeItens;
    }
}
