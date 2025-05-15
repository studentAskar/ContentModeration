using Domain.Interfaces;
using Infrastructure.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection
           services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection:"];
        services.AddDbContext<QueueDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });


        services.AddScoped<IVideoRepository, VideoRepository>();

        services.Configure<SignalROptions>(configuration.GetSection(nameof(SignalROptions)));
        services.Configure<RabbitMqOptions>(configuration.GetSection(nameof(RabbitMqOptions)));
        services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();
        services.AddHostedService<VideoProcessingWorker>();


        return services;
    }

}