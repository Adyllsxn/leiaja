namespace LeiaJa.Infrastructure.Repositories;
public class DashboardRepository(AppDbContext _context) : IDashboardRepository
{
        public async Task<DashboardEntity> GetQtdItems()
        {
            DashboardEntity quantityItems =  new();

            quantityItems.CategoryItems = await _context.Categories.CountAsync();
            quantityItems.AthorItems = await _context.Athors.CountAsync();

            return quantityItems;
        }
}
