using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoXShare.Application.Data.Context;
using MotoXShare.Application.Features.DeliveryRiders;
using MotoXShare.Application.Features.Motorcycles;
using MotoXShare.Application.Features.Notifications;
using MotoXShare.Application.Features.Orders;
using MotoXShare.Application.Features.Rentals;
using MotoXShare.Application.Features.Users;
using MotoXShare.Application.Messaging;
using MotoXShare.Application.Services;
using MotoXShare.Application.UnitOfWork;
using MotoXShare.Domain.Exceptions;

namespace MotoXShare.Application;

public static class Configure
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddInteractors()
            .AddUseCase()
            .AddExtensions()
            .AddMessageBus()
            .ConfigurePostgreSql(configuration)
            .AddRepositories();

        return services;
    }private static IServiceCollection ConfigurePostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new CustomException("Connection string cannot be empty.");

        var options = new DbContextOptionsBuilder<ApplicationContext>();
        options.UseNpgsql(connectionString);
        _ = new ApplicationContext(options.Options, true);

        services.AddScoped<EntityFrameworkUnitOfWorkAsync>();

        services.AddDbContext<ApplicationContext>(builder =>
        {
            builder.UseNpgsql(connectionString);
        });

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<IDeliveryRiderRepository, DeliveryRiderRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static IServiceCollection AddInteractors(this IServiceCollection services)
    {
        services.AddScoped<ISaveMotorcycleInteractor, SaveMotorcycleInteractor>();
        services.AddScoped<IGetMotorcyclesInteractor, GetMotorcyclesInteractor>();
        services.AddScoped<IUpdateMotorcycleInteractor, UpdateMotorcycleInteractor>();
        services.AddScoped<IDeleteMotorcycleInteractor, DeleteMotorcycleInteractor>();

        services.AddScoped<ISaveDeliveryRiderInteractor, SaveDeliveryRiderInteractor>();
        services.AddScoped<IUpdateDeliveryRiderInteractor, UpdateDeliveryRiderInteractor>();

        services.AddScoped<ISaveRentalInteractor, SaveRentalInteractor>();
        services.AddScoped<IGetRentalInteractor, GetRentalInteractor>();

        services.AddScoped<ISaveOrderInteractor, SaveOrderInteractor>();
        services.AddScoped<IUpdateOrderInteractor, UpdateOrderInteractor>();

        services.AddScoped<IGetNotificationInteractor, GetNotificationInteractor>();

        services.AddScoped<ISaveUserInteractor, SaveUserInteractor>();
        services.AddScoped<IAuthenticateUserInteractor, AuthenticateUserInteractor>();

        return services;
    }

    private static IServiceCollection AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<SaveMotorcycleUseCase>();
        services.AddScoped<GetMotorcyclesUseCase>();
        services.AddScoped<UpdateMotorcycleUseCase>();
        services.AddScoped<DeleteMotorcycleUseCase>();

        services.AddScoped<SaveDeliveryRiderUseCase>();
        services.AddScoped<UpdateDeliveryRiderUseCase>();

        services.AddScoped<SaveRentalUseCase>();
        services.AddScoped<GetRentalUseCase>();

        services.AddScoped<SaveOrderUseCase>();
        services.AddScoped<UpdateOrderUseCase>();

        services.AddScoped<SaveNotificationUseCase>();
        services.AddScoped<GetNotificationUseCase>();

        services.AddScoped<SaveUserUseCase>();
        services.AddScoped<AuthenticateUserUseCase>();

        return services;
    }

    private static IServiceCollection AddExtensions(this IServiceCollection services)
    {
        services.AddScoped<NotificationHandler>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }

    private static IServiceCollection AddMessageBus(this IServiceCollection services)
    {
        services.AddScoped<IRabbitMqService, RabbitMqService>();

        services.AddHostedService<OrdersCreatedSubscriber>();

        return services;
    }
}