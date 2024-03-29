using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoXShare.Domain.Exceptions;
using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Infraestructure;

public static class Configure
{
    public static IServiceCollection ConfigureInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigurePostgreSQL(configuration);

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
}