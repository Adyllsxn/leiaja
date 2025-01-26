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
            //services.AddScoped<ISistemaRepository, SistemaRepository>();
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            //services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
        #endregion </Repositories>

        #region <Services>
            //services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<ILivroService, LivroService>();
            //services.AddScoped<IEmprestimoService, EmprestimoService>();
        #endregion </Services>

        #region <AutoMapper>
            //services.AddAutoMapper(typeof(DomainToDTOProfile));
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