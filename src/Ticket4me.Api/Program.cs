using Ticket4me.Api.Configurations.v1;
using Ticket4me.Api.Extensions.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppConections(builder.Configuration)
    .AddUseCases()
    .AddAndConfigureControllers();

builder.Services.AddSwagger();

var app = builder.Build();

app.MigrateDatabase();
app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
