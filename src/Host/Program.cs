using FluentValidation.AspNetCore;
using Galia.Application.DependencyInjection;
using Galia.Host.Extensions;
using Galia.Infrastructure.DependencyInjection;
using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
Log.Information("Server Booting Up...");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.AddConfigurations();
    builder.Host.UseSerilog((_, config) => config.WriteTo.Console().ReadFrom.Configuration(builder.Configuration));

    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers().AddFluentValidation();

    var app = builder.Build();

    app.UseInfrastructure(builder.Configuration);
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}