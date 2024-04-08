using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoXShare.Domain.Exceptions;
using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.Data.Repository;
using MotoXShare.Infraestructure.Data.Repository.Interface;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Infraestructure;

public static class Configure
{
    public static IServiceCollection ConfigureInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigurePostgreSQL(configuration)
            .AddRepositories();

        return services;
    }

    private static IServiceCollection ConfigurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new CustomException("Connection string cannot be empty.");

        var options = new DbContextOptionsBuilder<ApplicationContext>();
        options.UseNpgsql(connectionString);
        _ = new ApplicationContext(options.Options, true);

        services.AddScoped<EntityFrameworkUnitOfWorkAsync>();

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddHealthChecks()
                .AddDbContextCheck<ApplicationContext>("postgresql");

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<IDeliveryRiderRepository, DeliveryRiderRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();

        return services;
    }
}