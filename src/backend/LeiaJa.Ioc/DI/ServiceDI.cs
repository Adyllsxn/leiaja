namespace LeiaJa.Ioc.DI;
public static class ServiceDI
{
    public static IServiceCollection AddServiceDI(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IAthorService, AthorService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}
