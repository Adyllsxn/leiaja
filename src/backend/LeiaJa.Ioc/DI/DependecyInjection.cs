namespace LeiaJa.Ioc.DI;
public static class DependecyInjection
{
    public static IServiceCollection AddInfrastrusture(this IServiceCollection services, IConfiguration configuration)
    {
        #region <Controllers>
            services.AddControllers();
        #endregion </Controllers>

        #region <ApiExplorer>
            services.AddEndpointsApiExplorer();
        #endregion </ApiExplorer>

        #region <ConnectioDb>
            var connectionSQLServer = configuration.GetConnectionString(StringConnection.DefaultSQLServer);
            services.AddDbContext<AppDbContext>(options =>{
                options.UseSqlServer(connectionSQLServer,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                );
            });
        #endregion </ConnectioDb>

        #region <Repositories>
            services.AddRepositoryDI();
        #endregion </Repositories>

        #region <Services>
            services.AddServiceDI();
        #endregion </Services>

        #region <UseCase>
            services.AddUseCase();
        #endregion </UseCase>

        #region <AutoMapper>
            services.AddAutoMapper(typeof(DomainToDTOProfile));
        #endregion </AutoMapper>

        #region <Cors>
            services.AddCors(
                option => option.AddDefaultPolicy(
                    policy => {
                        policy.AllowAnyOrigin().
                        AllowAnyHeader().
                        AllowAnyMethod();
                    }
                )
            );
        #endregion </Cors>

        return services;
    }
}