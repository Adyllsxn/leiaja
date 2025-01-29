namespace LeiaJa.Application.Services;
public class DashboardService(GetDashboardUseCase _get) : IDashboardService
{
    public async Task<DashboardDTO> GetQuantityItems()
    {
        return await _get.GetQuantityItems();
    }
}
