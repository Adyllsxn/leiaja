#region <Microsoft>
    global using Microsoft.Extensions.DependencyInjection;
    global using Microsoft.Extensions.Configuration;
    global using Microsoft.EntityFrameworkCore;
    global using Microsoft.AspNetCore.Builder;
    global using Microsoft.Extensions.Hosting;
#endregion </Microsoft>

#region <Infrastructure>
    global using LeiaJa.Infrastructure.Context;
    global using LeiaJa.Infrastructure.Repositories;
    global using LeiaJa.Infrastructure.Common;
#endregion </Infrastructure>

#region <Domain>
    global using LeiaJa.Domain.Interfaces;
#endregion </Domain>

#region <Application>
    global using LeiaJa.Application.Mappings;
    global using LeiaJa.Application.Interfaces;
    global using LeiaJa.Application.Services;
#endregion </Application>