using Ticket4me.Api.Filters.v1;
using Ticket4me.Api.Policies.v1;

namespace Ticket4me.Api.Configurations.v1;

public static class ControllersConfiguration
{
    public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
    {
        services
            .AddControllers(options
                => options.Filters.Add(typeof(ApiGlobalExceptionFilter))
            )
            .AddJsonOptions(jsonOptions => {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy
                    = new JsonSnakeCasePolicy();
            });
        services.AddDocumentation();
        return services;
    }

    private static IServiceCollection AddDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    public static WebApplication UseDocumentation(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
