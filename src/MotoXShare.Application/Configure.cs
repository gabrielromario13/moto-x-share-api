using Microsoft.Extensions.DependencyInjection;
using MotoXShare.Application.Interactor.DeliveryRider;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.Interactor.Interface.DeliveryRider;
using MotoXShare.Application.Interactor.Interface.Motorcycle;
using MotoXShare.Application.Interactor.Interface.Order;
using MotoXShare.Application.Interactor.Interface.Rental;
using MotoXShare.Application.Interactor.Interface.User;
using MotoXShare.Application.Interactor.Motorcycle;
using MotoXShare.Application.Interactor.Order;
using MotoXShare.Application.Interactor.Rental;
using MotoXShare.Application.Interactor.User;
using MotoXShare.Application.UseCase.DeliveryRider;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Application.UseCase.Order;
using MotoXShare.Application.UseCase.Rental;
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
        services.AddScoped<IGetMotorcyclesInteractor, GetMotorcyclesInteractor>();
        services.AddScoped<IUpdateMotorcycleInteractor, UpdateMotorcycleInteractor>();
        services.AddScoped<IDeleteMotorcycleInteractor, DeleteMotorcycleInteractor>();

        services.AddScoped<ISaveDeliveryRiderInteractor, SaveDeliveryRiderInteractor>();

        services.AddScoped<ISaveRentalInteractor, SaveRentalInteractor>();
        services.AddScoped<IGetRentalInteractor, GetRentalInteractor>();

        services.AddScoped<ISaveOrderInteractor, SaveOrderInteractor>();

        return services;
    }

    public static IServiceCollection AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<SaveUserUseCase>();

        services.AddScoped<SaveMotorcycleUseCase>();
        services.AddScoped<GetMotorcyclesUseCase>();
        services.AddScoped<UpdateMotorcycleUseCase>();
        services.AddScoped<DeleteMotorcycleUseCase>();

        services.AddScoped<SaveDeliveryRiderUseCase>();

        services.AddScoped<SaveRentalUseCase>();
        services.AddScoped<GetRentalUseCase>();

        services.AddScoped<SaveOrderUseCase>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<IDeliveryRiderRepository, DeliveryRiderRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}