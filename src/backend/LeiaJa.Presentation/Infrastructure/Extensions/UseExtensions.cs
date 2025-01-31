namespace LeiaJa.Presentation.Infrastructure.Extensions;
public static class UseExtensions
{
    public static void AddUseExtensions(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseInfrastructureSwagger();
        app.UseApp(); 
    }
}
