namespace LeiaJa.Application.Services;
public class SistemaService : ISistemaService
{
    private readonly ISistemaRepository _repository;
    private readonly IMapper _mapper;
    public SistemaService(ISistemaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<QuantidadeDTO> GetQtdItems()
    {
        var quantidadeItens = await _repository.GetQtdItems();
        var QuantidadeItemsDTO = _mapper.Map<QuantidadeDTO>(quantidadeItens);
        return QuantidadeItemsDTO;
    }
}
