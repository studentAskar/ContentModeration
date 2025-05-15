using Domain.Entity;
using Domain.Interfaces;
using KDS.Primitives.FluentResult;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Error = KDS.Primitives.FluentResult.Error;

namespace Infrastructure;

public class SignalRService : ISignalRService, IAsyncDisposable
{
    private readonly HubConnection _hubConnection;
    private readonly ILogger<SignalRService> _logger;

    public SignalRService(IOptions<SignalROptions> options, ILogger<SignalRService> logger)
    {

        _logger = logger;
        var signalROptions = options.Value;
        if (string.IsNullOrWhiteSpace(signalROptions.BaseUrl) || string.IsNullOrWhiteSpace(signalROptions.HubPath))
        {
            throw new ArgumentException($"SignalR BaseUrl or HubPath is not set. " +
                                        $"BaseUrl: '{signalROptions.BaseUrl}', HubPath: '{signalROptions.HubPath}'");
        }
        _hubConnection = new HubConnectionBuilder()
            .WithUrl($"{signalROptions.BaseUrl}{signalROptions.HubPath}")
            .Build();
    }

    public async Task<Result> SendMessageAsync(string methodName, object message)
    {
        var connectResult = await ConnectAsync();
        if (connectResult.IsFailed)
            return connectResult;

        try
        {
            await _hubConnection.InvokeAsync(methodName, message);
            await DisconnectAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при отправке сообщения в SignalR.");
            await DisconnectAsync();
            return Result.Failure(new Error(Errors.InternalServerError, "Ошибка при отправке сообщения в SignalR"));
        }
    }
    public async Task<Result> SendNotification(string methodName, object notification)
    {
        var connectResult = await ConnectAsync();
        if (connectResult.IsFailed)
            return connectResult;

        try
        {
            await _hubConnection.InvokeAsync(methodName, notification);
            await DisconnectAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при отправке списка в SignalR.");
            await DisconnectAsync();
            return Result.Failure(new Error(Errors.InternalServerError, "Ошибка при отправке списка в SignalR"));
        }
    }


    public async Task<Result> SendCollectionListQueueAsync<T>(string methodName, List<T> queueList)
    {
        var connectResult = await ConnectAsync();
        if (connectResult.IsFailed)
            return connectResult;

        try
        {

            await _hubConnection.InvokeAsync(methodName, queueList);

            await DisconnectAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при отправке списка в SignalR.");
            await DisconnectAsync();
            return Result.Failure(new Error(Errors.InternalServerError, "Ошибка при отправке списка в SignalR"));
        }
    }

    public async Task<Result> ConnectAsync()
    {
        if (_hubConnection.State == HubConnectionState.Connected)
            return Result.Success();

        try
        {
            await _hubConnection.StartAsync();
            _logger.LogInformation("SignalR подключен.");
            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка подключения к SignalR.");
            return Result.Failure(new Error(Errors.ServiceUnavailable, "Ошибка подключения к SignalR."));
        }
    }

    public async Task<Result> DisconnectAsync()
    {
        if (_hubConnection.State == HubConnectionState.Connected)
        {
            try
            {
                await _hubConnection.StopAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при отключении от SignalR.");
                return Result.Failure(new Error(Errors.InternalServerError, "Ошибка при отключении от SignalR"));
            }
        }
        return Result.Success();
    }

    public async ValueTask DisposeAsync()
    {
        if (_hubConnection != null)
        {
            await DisconnectAsync();
            await _hubConnection.DisposeAsync();
        }
    }
}

