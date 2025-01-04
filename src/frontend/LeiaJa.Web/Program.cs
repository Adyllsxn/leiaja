var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.AddInfrastructure();
    
    await builder.Build().RunAsync();
