using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Galia.Infrastructure.Multitenancy;

public static class TenantExtensions
{
    internal static IApplicationBuilder UseMiddlewareTenant(this IApplicationBuilder app)
    {
        app.UseMiddleware<TenantMiddleware>();
        return app;
    }

    internal static IServiceCollection AddMiddlewareTenant(this IServiceCollection services)
    {
        services.AddScoped<TenantMiddleware>();
        return services;
    }
}
