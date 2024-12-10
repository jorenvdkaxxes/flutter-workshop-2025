using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Configuration;
using SimplyLifestyle.Utils;
using SimplyLifestyle.Domain;

namespace SimplyLifestyle.Application;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureMediator()
            .ConfigurePipelineBehaviors()
            .ConfigureDomainServices()
            .ConfigureApplicationServices()
            .ConfigureEventPublisher()
            .ConfigureApplicationContext();

        return services;
    }

    private static IServiceCollection ConfigureMediator(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }

    private static IServiceCollection ConfigurePipelineBehaviors(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehavior<,>));

        services
           .AddValidationBehavior<CreateProductCommand, CreateProductOutputModel>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

        return services;
    }

    private static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        => services
            .Scan(selector => selector
                    .FromCallingAssembly()
                    .AddClasses(classes => classes.AssignableTo<IDomainService>())
                    .AsMatchingInterface()
                    .WithTransientLifetime());

    private static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        => services
            .Scan(selector => selector
                    .FromCallingAssembly()
                    .AddClasses(classes => classes.AssignableTo<IApplicationService>())
                    .AsMatchingInterface()
                    .WithTransientLifetime());

    private static IServiceCollection ConfigureEventPublisher(this IServiceCollection services)
    {
        services.AddScoped<IEventPublisher, EventPublisher>();

        return services;
    }

    private static IServiceCollection ConfigureApplicationContext(this IServiceCollection services)
    {
        services.AddScoped<ApplicationContext>();

        return services;
    }

    private static IServiceCollection AddValidationBehavior<TRequest, TResponseData>(this IServiceCollection services)
        where TRequest : IRequest<OperationResult<TResponseData>>
        where TResponseData : IOutputModel
        => services.AddTransient<IPipelineBehavior<TRequest, OperationResult<TResponseData>>,
                                    ValidationBehavior<TRequest, TResponseData>>();
}
