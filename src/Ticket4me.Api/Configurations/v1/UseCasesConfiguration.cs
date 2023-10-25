using MediatR;
using Ticket4me.Application.UseCases.v1.Category.CreateCategory;
using Ticket4me.Domain.Contracts.v1;
using Ticket4me.Infra.Data.EF;
using Ticket4me.Infra.Data.EF.Repositories.v1;

namespace Ticket4me.Api.Configurations.v1;

public static class UseCasesConfiguration
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateCategory));
        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
