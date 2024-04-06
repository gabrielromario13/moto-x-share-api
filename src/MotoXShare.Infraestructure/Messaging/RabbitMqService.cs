using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MotoXShare.Infraestructure.Messaging;

public class RabbitMqService : IMessageBusService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private const string QUEUE_NAME = "orders-created";

    public RabbitMqService()
    {
        var connectionFactory = new ConnectionFactory
        {
            Uri = new Uri(uriString: "amqp://guest:guest@localhost:5672")
        };


        _connection = connectionFactory.CreateConnection();

        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
                queue: QUEUE_NAME,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
    }

    public void Publish(object data)
    {
        var type = data.GetType();
        Console.WriteLine($"Message type: {type.Name} Published");

        var payload = JsonConvert.SerializeObject(data);
        var byteArray = Encoding.UTF8.GetBytes(payload);

        _channel.BasicPublish(
            exchange: string.Empty,
            routingKey: QUEUE_NAME,
            basicProperties: null,
            body: byteArray
        );
    }
}