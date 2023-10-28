using Ticket4me.Api.Configurations.v1;
using Ticket4me.Api.Extensions.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppConections(builder.Configuration)
    .AddUseCases()
    .AddAndConfigureControllers();

builder.Services.AddSwagger();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
});

var app = builder.Build();

app.MigrateDatabase();
app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
