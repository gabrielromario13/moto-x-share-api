using Microsoft.Extensions.DependencyInjection;
using MotoXShare.Application.Interactor.DeliveryRider;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.Interactor.Interface.DeliveryRider;
using MotoXShare.Application.Interactor.Interface.Motorcycle;
using MotoXShare.Application.Interactor.Interface.Notification;
using MotoXShare.Application.Interactor.Interface.Order;
using MotoXShare.Application.Interactor.Interface.Rental;
using MotoXShare.Application.Interactor.Motorcycle;
using MotoXShare.Application.Interactor.Notification;
using MotoXShare.Application.Interactor.Order;
using MotoXShare.Application.Interactor.Rental;
using MotoXShare.Application.Services;
using MotoXShare.Application.Subscribers;
using MotoXShare.Application.UseCase.DeliveryRider;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Application.UseCase.Notification;
using MotoXShare.Application.UseCase.Order;
using MotoXShare.Application.UseCase.Rental;
using MotoXShare.Domain.Notification;
using MotoXShare.Infraestructure.Messaging;

namespace MotoXShare.Application;

public static class Configure
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services
            .AddInteractors()
            .AddUseCase()
            .AddExtensions()
            .AddMessageBus();

        return services;
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