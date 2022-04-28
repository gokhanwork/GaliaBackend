using Galia.Application.Common.Interfaces;
using Galia.Infrastructure.Common.Extensions;
using Galia.Infrastructure.Common.Services;
using Galia.Infrastructure.HangFire;
using Galia.Infrastructure.Identity.Extensions;
using Galia.Infrastructure.Identity.Permissions;
using Galia.Infrastructure.Localizer;
using Galia.Infrastructure.Mappings;
using Galia.Infrastructure.Multitenancy;
using Galia.Infrastructure.Persistence.Contexts;
using Galia.Infrastructure.Seeders;
using Galia.Infrastructure.Swagger;
using Hangfire;
using Hangfire.Console.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;

namespace Galia.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        MapsterSettings.Configure();
        if (config.GetSection("CacheSettings:PreferRedis").Get<bool>())
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config.GetSection("CacheSettings:RedisURL").Get<string>();
                options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
                {
                    AbortOnConnectFail = true
                };
            });
        }
        else
        {
            services.AddDistributedMemoryCache();
        }

        services.TryAdd(ServiceDescriptor.Singleton<ICacheService, CacheService>());
        services.AddSeeders();
        services.AddMiddlewareCurrentUser();
        services.AddMiddlewareTenant();
        services.AddHealthCheckExtension();
        services.AddLocalization();
        services.AddServices();
        services.AddSettings(config);
        services.AddPermissions();
        services.AddIdentity(config);
        services.AddHangfireServer(options =>
        {
            var optionsServer = services.GetOptions<BackgroundJobServerOptions>("HangFireSettings:Server");
            options.HeartbeatInterval = optionsServer.HeartbeatInterval;
            options.Queues = optionsServer.Queues;
            options.SchedulePollingInterval = optionsServer.SchedulePollingInterval;
            options.ServerCheckInterval = optionsServer.ServerCheckInterval;
            options.ServerName = optionsServer.ServerName;
            options.ServerTimeout = optionsServer.ServerTimeout;
            options.ShutdownTimeout = optionsServer.ShutdownTimeout;
            options.WorkerCount = optionsServer.WorkerCount;
        });
        services.AddHangfireConsoleExtensions();
        services.AddHangFireService();
        services.AddMultitenancy<TenantManagementDbContext, ApplicationDbContext>(config);
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddMiddlewares();
        services.AddSwaggerDocumentation();
        services.AddCorsPolicy();
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });
        services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
        services.AddNotifications();
        return services;
    }

    public static IServiceCollection AddPermissions(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
            .AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        return services;
    }
}
