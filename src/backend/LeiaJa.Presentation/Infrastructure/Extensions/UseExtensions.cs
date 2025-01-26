namespace LeiaJa.Presentation.Infrastructure.Extensions;
public static class UseExtensions
{
    public static void AddUseExtensions(this WebApplication app)
    {
        app.UseApp(); 
    }
}
