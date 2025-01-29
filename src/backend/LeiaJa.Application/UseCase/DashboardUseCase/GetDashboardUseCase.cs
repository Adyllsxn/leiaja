namespace LeiaJa.Application.UseCase.DashboardUseCase;
public class GetDashboardUseCase(IDashboardRepository _repository, IMapper _mapper)
{
    public async Task<DashboardDTO> GetQuantityItems()
    {
        var quantityItems = await _repository.GetQtdItems();
        var quantityItemsDTO = _mapper.Map<DashboardDTO>(quantityItems);
        return quantityItemsDTO;
    }
}
