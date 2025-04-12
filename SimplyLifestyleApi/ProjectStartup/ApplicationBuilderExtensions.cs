using Common.Infrastructure;
using Common.Web;
using Scalar.AspNetCore;

namespace ProjectStartup;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseWebService(
        this IApplicationBuilder app,
        IWebHostEnvironment env)
        => app
            .UseExceptionHandling(env)
            .UseValidationExceptionHandler()
            .UseHttpsRedirection()
            .UseRouting()
            .UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod())
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints => endpoints
                .MapControllers());

    private static IApplicationBuilder UseExceptionHandling(
        this IApplicationBuilder app,
        IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        return app;
    }

    public static IApplicationBuilder UseOpenApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        return app;
    }

    public static IApplicationBuilder Initialize(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var initializers = serviceScope.ServiceProvider.GetServices<IDbInitializer>();

        foreach (var initializer in initializers)
        {
            initializer.Initialize();
        }

        return app;
    }
}