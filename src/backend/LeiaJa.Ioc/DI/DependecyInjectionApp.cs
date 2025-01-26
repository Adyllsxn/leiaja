namespace LeiaJa.Ioc.DI;
public static class DependecyInjectionApp
{
    public static void UseApp(this WebApplication app)
    {
        app.UseCors();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.MapControllers();
        app.Run();
    }
}