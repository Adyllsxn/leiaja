namespace LeiaJa.Ioc.DI;
public static class DependecyInjectionSwagger
{
    #region <Swagger>
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            
            return services;
        }
    #endregion </Swagger>

    #region <UseSwagger>
        public static void UseInfrastructureSwagger(this WebApplication app)
        {
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    #endregion </UseSwagger>
}