using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotoXShare.Core.Application.Commands.DeliveryRiderNotificationCommands;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MotoXShare.Core.Messaging;

public class OrdersCreatedSubscriber : BackgroundService
{
    private readonly IModel _channel;
    private const string QueueName = "orders-created";
    private readonly IServiceProvider _serviceProvider;

    public OrdersCreatedSubscriber(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        var connectionFactory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        var connection = connectionFactory.CreateConnection();
        _channel = connection.CreateModel();

        _channel.QueueDeclare(queue: QueueName,
                              durable: false,
                              exclusive: false,
                              autoDelete: false);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var contentArray = eventArgs.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(contentArray);
            var orderId = JsonConvert.DeserializeObject<int>(contentString);

            var command = new CreateDeliveryRiderNotificationCommand(orderId);

            var result = await mediator.Send(command);

            if (!result.IsSuccess)
            {
                _channel.BasicNack(eventArgs.DeliveryTag, false, true);
                return;
            }

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume(queue: QueueName,
                              autoAck: false,
                              consumer: consumer);

        return Task.CompletedTask;
    }
}