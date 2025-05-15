namespace Domain.Interfaces;

public interface IRabbitMqPublisher
{
    void Publish<T>(T message);
}