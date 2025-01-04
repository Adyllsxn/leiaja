namespace LeiaJa.Presentation.Infrastructure.Extensions;
public static class BuilderExtensions
{
    public static void AddBuilderExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastrusture(builder.Configuration);
        builder.Services.AddInfrastructureSwagger();
    }
}
