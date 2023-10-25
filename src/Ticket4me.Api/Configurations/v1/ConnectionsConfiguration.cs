using Microsoft.EntityFrameworkCore;
using Ticket4me.Infra.Data.EF.Context.v1;

namespace Ticket4me.Api.Configurations.v1;

public static class ConnectionsConfiguration
{
    public static IServiceCollection AddAppConections(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbConnection(configuration);
        return services;
    }

    private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Ticket4meDb");
        services.AddDbContext<Ticket4meDbContext>(
            options => options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            )
        );
        return services;
    }

    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (environment == "EndToEndTest") return app;
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<Ticket4meDbContext>();
        dbContext.Database.Migrate();
        return app;
    }
}
