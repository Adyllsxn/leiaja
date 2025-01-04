namespace LeiaJa.Presentation.Infrastructure.Extensions;
public static class AppExtensions
{
    public static void AddAppExtensions(this WebApplication app)
    {
        app.UseInfrastructureSwagger();
        app.UseApp();
    }
}
