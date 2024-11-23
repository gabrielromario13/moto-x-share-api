namespace MotoXShare.Application.Messaging;

public interface IRabbitMqService
{
    void Publish(object data);
}