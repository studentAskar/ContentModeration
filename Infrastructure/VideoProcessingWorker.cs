using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Domain.Entity;
using System.Text.Json;
using Domain.Interfaces;
using Domain.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Channels;
using Application;
using Microsoft.AspNetCore.SignalR;

public class VideoProcessingWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<VideoProcessingWorker> _logger;

    public VideoProcessingWorker(IServiceScopeFactory scopeFactory, ILogger<VideoProcessingWorker> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            DispatchConsumersAsync = true
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        channel.QueueDeclare("video-processing", durable: true, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            using var scope = _scopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IVideoRepository>();

            try
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                var message = JsonSerializer.Deserialize<VideoUploadedMessage>(json);
                if (message != null)
                {
                    var video = await repository.GetByIdAsync(message.VideoId);
                    if (video != null)
                    {
                        video.Status = (int)ContentStatus.Approved;
                        await repository.SaveAsync(video);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing video");
            }
        };


        channel.BasicConsume(queue: "video-processing", autoAck: true, consumer: consumer);

        // 🛑 Это — ключевая строка. Ждём отмены, чтобы сервис не завершился.
        return Task.Run(() =>
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Task.Delay(1000).Wait();
            }

            return Task.CompletedTask;
        });
    }



}


