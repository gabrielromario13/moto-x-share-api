using Microsoft.Extensions.DependencyInjection;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.Interactor.Motorcycle;
using MotoXShare.Application.Interactor.User;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Application.UseCase.User;
using MotoXShare.Infraestructure.Data.Repository;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application;

public static class Configure
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services
            .AddInteractors()
            .AddUseCase()
            .AddRepositories();

        return services;
    }

    public static IServiceCollection AddInteractors(this IServiceCollection services)
    {
        services.AddScoped<ISaveUserInteractor, SaveUserInteractor>();

        services.AddScoped<ISaveMotorcycleInteractor, SaveMotorcycleInteractor>();

        return services;
    }

    public static IServiceCollection AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<SaveUserUseCase>();

        services.AddScoped<SaveMotorcycleUseCase>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();

        return services;
    }
}