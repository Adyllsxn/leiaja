
#region <Microsoft>
    global using Microsoft.AspNetCore.Builder;
    global using Microsoft.Extensions.DependencyInjection;
    global using Microsoft.Extensions.Hosting;
    global using Microsoft.EntityFrameworkCore;
    global using Microsoft.Extensions.Configuration;
#endregion </Microsoft>

#region <Domain>
    global using LeiaJa.Domain.Interfaces;
#endregion </Domain>

#region <Infrastructure>
    global using LeiaJa.Infrastructure.Context;
    global using LeiaJa.Infrastructure.Repositories;
#endregion </Infrastructure>

#region <Application>
    global using LeiaJa.Application.UseCase.CategoryUseCase;
    global using LeiaJa.Application.UseCase.DashboardUseCase;
    global using LeiaJa.Application.Mapping;
    global using LeiaJa.Application.Interfaces;
    global using LeiaJa.Application.Services;
#endregion </Application>