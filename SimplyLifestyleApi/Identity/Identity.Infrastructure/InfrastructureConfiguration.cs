using System.Reflection;
using Common.Domain;
using Common.Infrastructure;
using Identity.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddIdentityInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddIdentity()
            .AddDBStorage<IdentityDbContext>(
                configuration,
                Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, IdentityDbInitializer>();

    private static IServiceCollection AddIdentity(
        this IServiceCollection services)
    {
        services
            .AddTransient<IIdentity, IdentityService>()
            .AddTransient<IJwtGenerator, JwtGeneratorService>()
            .AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = CommonModelConstants.Identity.MinPasswordLength;
            })
            .AddEntityFrameworkStores<IdentityDbContext>();

        return services;
    }
}