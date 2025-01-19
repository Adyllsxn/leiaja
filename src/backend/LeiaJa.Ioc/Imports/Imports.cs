#region Microsoft Libs
    global using Microsoft.Extensions.DependencyInjection;
    global using Microsoft.Extensions.Configuration;
    global using Microsoft.EntityFrameworkCore;
    global using Microsoft.AspNetCore.Builder;
    global using Microsoft.Extensions.Hosting;
#endregion

#region Infrastructure Class
    global using LeiaJa.Infrastructure.Context;
    global using LeiaJa.Infrastructure.Repositories;
    global using LeiaJa.Infrastructure.Common;
#endregion

#region Domain Class
    global using LeiaJa.Domain.Interfaces;
#endregion

#region Application
    global using LeiaJa.Application.Mappings;
    global using LeiaJa.Application.Interfaces;
    global using LeiaJa.Application.Services;
#endregion