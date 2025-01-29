namespace LeiaJa.Ioc.DI;
public static class UseCaseDI
{
    public static IServiceCollection AddUseCase(this IServiceCollection services)
    {
        #region <Dashboard>
            services.AddScoped<GetDashboardUseCase>();
        #endregion </Dashboard>
        
        #region <Category>
            services.AddScoped<GetCategoriesUseCase>();
            services.AddScoped<GetCategoryByIdUseCase>();
            services.AddScoped<CreateCategoryUseCase>();
            services.AddScoped<UpdateCategoryUseCase>();
            services.AddScoped<DeleteCategoryUseCase>();
        #endregion </Category>

        return services;
    }
}
