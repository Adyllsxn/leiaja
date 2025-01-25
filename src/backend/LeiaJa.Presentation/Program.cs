#region <Builder>
using LeiaJa.Presentation.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
        builder.AddBuilderExtensions();
#endregion </Builder>

#region <App>
    var app = builder.Build();
        app.AddUseExtensions();
#endregion </App>
