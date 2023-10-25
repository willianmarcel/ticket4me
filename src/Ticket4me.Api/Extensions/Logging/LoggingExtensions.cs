namespace Ticket4me.Api.Extensions.Logging;

public static class LoggingExtensions
{
    public static void AddLogExtensions(this ILoggingBuilder logging, ConfigurationManager configuration)
    {
        logging.ClearProviders();
        logging.AddConsole();

        logging.AddApplicationInsights(
           configureTelemetryConfiguration: (config) =>
           {
               config.ConnectionString = configuration.GetSection("ConnectionsString:ApplicationInsights").Value;
           },
           configureApplicationInsightsLoggerOptions: (options) => { });
    }
}
