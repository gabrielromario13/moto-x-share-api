using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotoXShare.Application.UseCase.Notification;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MotoXShare.Application.Subscribers;

public class OrdersCreatedSubscriber : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private const string QUEUE_NAME = "orders-created";
    private readonly SaveNotificationUseCase _saveNotificationUseCase;

    public OrdersCreatedSubscriber(IServiceProvider serviceProvider)
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        _connection = connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(QUEUE_NAME, false, false);

        _saveNotificationUseCase = serviceProvider.CreateScope()
            .ServiceProvider.GetRequiredService<SaveNotificationUseCase>();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var contentArray = eventArgs.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(contentArray);
            var orderId = JsonConvert.DeserializeObject<Guid>(contentString);

            if (!await _saveNotificationUseCase.Action(orderId))
            {
                _channel.BasicNack(eventArgs.DeliveryTag, false, true);
                return;
            }

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume(QUEUE_NAME, false, consumer);

        return Task.CompletedTask;
    }
}