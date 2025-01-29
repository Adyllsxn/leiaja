namespace LeiaJa.Ioc.DI;
public static class RepositoryDI
{
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();

        return services;
    }
}
