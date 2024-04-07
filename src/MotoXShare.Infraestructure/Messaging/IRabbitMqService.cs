namespace MotoXShare.Infraestructure.Messaging;

public interface IRabbitMqService
{
    void Publish(object data);
}