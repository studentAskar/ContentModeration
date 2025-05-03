using KDS.Primitives.FluentResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface ISignalRService
{
    Task<Result> ConnectAsync();
    Task<Result> SendMessageAsync(string methodName, object message);
    Task<Result> SendCollectionListQueueAsync<T>(string methodName, List<T> queueList);
    Task<Result> SendNotification(string methodName, object notification);
    Task<Result> DisconnectAsync();
}
