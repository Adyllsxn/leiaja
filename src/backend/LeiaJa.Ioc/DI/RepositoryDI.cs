namespace LeiaJa.Ioc.DI;
public static class RepositoryDI
{
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();
        services.AddScoped<IAthorRepository, AthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}
