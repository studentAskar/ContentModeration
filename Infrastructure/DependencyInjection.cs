using Domain.Interfaces;
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
        services.AddDbContext<ContentDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });


        services.AddScoped<IVideoRepository, VideoRepository>();

        return services;
    }

}