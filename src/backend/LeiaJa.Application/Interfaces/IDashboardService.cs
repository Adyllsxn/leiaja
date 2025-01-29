namespace LeiaJa.Application.Interfaces;
public interface IDashboardService
{
    Task<DashboardDTO> GetQuantityItems();
}
