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

        #region <Athor>
            services.AddScoped<CreateAthorUseCase>();
            services.AddScoped<GetAthorsUseCase>();
            services.AddScoped<GetAthorByIdUseCase>();
            services.AddScoped<DeleteAthorUseCase>();
            services.AddScoped<UpdateAthorUseCase>();
            services.AddScoped<SearchAthorUseCase>();
        #endregion </Athor>

        #region <Book>
            services.AddScoped<CreateBookUseCase>();
            services.AddScoped<GetBookUseCase>();
            services.AddScoped<GetBookByIdUseCase>();
            services.AddScoped<DeleteBookUseCase>();
            services.AddScoped<UpdateBookUseCase>();
            services.AddScoped<SearchBookUseCase>();
        #endregion </Book>

        #region <User>
            services.AddScoped<CreateUserUseCase>();
            services.AddScoped<DeleteUseUseCase>();
            services.AddScoped<UpdateUserUseCase>();
            services.AddScoped<SearchUserUseCase>();
            services.AddScoped<GetUserByIdUseCase>();
            services.AddScoped<GetUsersUseCase>();
            services.AddScoped<ExistUserUseCase>();
        #endregion </User>


        return services;
    }
}
