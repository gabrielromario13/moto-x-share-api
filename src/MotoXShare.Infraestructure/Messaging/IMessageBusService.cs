namespace MotoXShare.Infraestructure.Messaging;

public interface IMessageBusService
{
    void Publish(object data);
}