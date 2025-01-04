namespace LeiaJa.Web.Core.Infrastructure.Extensions;
public static class BuildeExtensions
{
    public static void AddInfrastructure(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); 
    }
    
}
