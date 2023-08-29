//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Microsoft.Extensions.Logging;

public sealed class QueueDispathcher : Worker<QueueDispathcher>
{
    readonly ITaskQueue Queue;

    readonly ILogger<QueueDispathcher> Log;

    public QueueDispathcher(ITaskQueue taskQueue, ILogger<QueueDispathcher> logger) =>
        (Queue, Log) = (taskQueue, logger);

    protected override Task ExecuteAsync(CancellationToken ct)
        => ProcessTaskQueueAsync(ct);

    async Task ProcessTaskQueueAsync(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            try
            {
                Func<CancellationToken, ValueTask>? workItem = await Queue.Dequeue(ct);
                await workItem(ct);
            }
            catch (OperationCanceledException)
            {
                
            }
            catch (Exception ex)
            {
                Log.LogError(ex, "Error occurred executing task work item.");
            }
        }
    }

    public override async Task StopAsync(CancellationToken ct)
    {
        Log.LogInformation(
            $"{nameof(QueueDispathcher)} is stopping.");

        await base.StopAsync(ct);
    }
}
