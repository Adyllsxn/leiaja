namespace LeiaJa.Domain.Interfaces;
public interface IDashboardRepository
{
    Task<DashboardEntity> GetQtdItems();
}
