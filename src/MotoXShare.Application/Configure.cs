using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoXShare.Application.Features.Notifications;
using MotoXShare.Application.Messaging;
using MotoXShare.Application.Services;
using MotoXShare.Core.Data.Context;
using MotoXShare.Core.Messaging;
using MotoXShare.Core.Services;
using MotoXShare.Domain.Exceptions;

namespace MotoXShare.Core;

public static class Configure
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddExtensions()
            .AddMessageBus()
            .ConfigurePostgreSql(configuration);

        return services;
    }
    private static IServiceCollection ConfigurePostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new CustomException("Connection string cannot be empty.");

        services.AddDbContext<AppDbContext>(builder =>
        {
            builder.UseNpgsql(connectionString);
        });

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