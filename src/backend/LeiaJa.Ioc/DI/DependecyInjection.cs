namespace LeiaJa.Ioc.DI;
public static class DependecyInjection
{
    public static IServiceCollection AddInfrastrusture(this IServiceCollection services, IConfiguration configuration)
    {
        #region CONTROLLERS & APIEXPLORER
            services.AddControllers();
            services.AddEndpointsApiExplorer();
        #endregion

        #region DBCONTEXT
            var connectionSQLServer = configuration.GetConnectionString(InfrastructureConfiguration.DefaultSQLServer);
            services.AddDbContext<AppDbContext>(options =>{
                options.UseSqlServer(connectionSQLServer,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                );
            });
        #endregion

        #region REPOSITORY
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ISistemaRepository, SistemaRepository>();
            services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
        #endregion

        #region SERVICE
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<ISistemaService, SistemaService>();
            services.AddScoped<IProvinciaService, ProvinciaService>();
            services.AddScoped<IMunicipioService, MunicipioService>();
            services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITipoTelefoneService, TipoTelefoneService>();
            services.AddScoped<ITelefoneService, TelefoneService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();
            services.AddScoped<IGeneroService, GeneroService>();
        #endregion

        #region AUTOMAPPER
            services.AddAutoMapper(typeof(DomainToDTOProfile));
        #endregion

        return services;
    }
}
