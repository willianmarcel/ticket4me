using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Ticket4me.Api.Extensions.Swagger;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(
        IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                CreateVersionInfo(description));
        }
    }

    public void Configure(string? name, SwaggerGenOptions options)
    {
        Configure(options);
    }

    private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc)
    {
        var info = new OpenApiInfo()
        {
            Title = "Portal to shop tickets",
            Version = desc.ApiVersion.ToString(),
            Description = $"WebApi for buy events tickets v{Assembly.GetExecutingAssembly().GetName().Version}",
            Contact = new OpenApiContact()
            {
                Email = "willian@wmtecnologia.com.br",
                Name = "Willian Borges"
            }
        };

        if (desc.IsDeprecated)
        {
            info.Description += "Endpoint depreciado. Pesquise e utilize a versão mais recente.";
        }

        return info;
    }
}
