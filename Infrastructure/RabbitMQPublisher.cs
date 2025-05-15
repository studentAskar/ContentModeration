
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Domain.Interfaces;
using Microsoft.AspNetCore.Connections;

namespace Infrastructure.Messaging;

public class RabbitMqPublisher(IOptions<RabbitMqOptions> options) : IRabbitMqPublisher
{
    private readonly RabbitMqOptions _options = options.Value;

    public void Publish<T>(T message)
    {
        var factory = new ConnectionFactory
        {
            HostName = _options.Host,
            Port = _options.Port,
            UserName = _options.Username,
            Password = _options.Password
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: _options.QueueName,
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "",
                             routingKey: _options.QueueName,
                             basicProperties: null,
                             body: body);
    }
}
