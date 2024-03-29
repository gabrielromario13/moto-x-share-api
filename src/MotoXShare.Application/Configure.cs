using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.Interactor.User;
using MotoXShare.Application.UseCase.User;
using MotoXShare.Domain.Exceptions;
using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.Data.Repository;
using MotoXShare.Infraestructure.Data.Repository.Interface;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application;

public static class Configure
{
    public static IServiceCollection ConfigureCommon(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigurePostgreSQL(configuration)
            .AddInteractors()
            .AddUseCase()
            .AddRepositories();

        return services;
    }

    public static IServiceCollection ConfigurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DefaultConnection:ConnectionString"];

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new CustomException("Connection string cannot be empty.");

        services.AddScoped<EntityFrameworkUnitOfWorkAsync>();

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddHealthChecks()
                .AddDbContextCheck<ApplicationContext>("postgresql");

        return services;
    }

    public static IServiceCollection AddInteractors(this IServiceCollection services)
    {
        services.AddScoped<ISaveUserInteractor, SaveUserInteractor>();

        return services;
    }

    public static IServiceCollection AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<SaveUserUseCase>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}