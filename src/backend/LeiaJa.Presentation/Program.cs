#region <Builder>
    var builder = WebApplication.CreateBuilder(args);
            builder.AddBuilderExtensions();
#endregion </Builder>

#region <App>
    var app = builder.Build();
        app.AddUseExtensions();
#endregion </App>
