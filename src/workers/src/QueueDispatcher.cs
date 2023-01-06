//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class QueueDispathcher : Worker<QueueDispathcher>
    {
        readonly ITaskQueue Queue;

        readonly ILogger<QueueDispathcher> Log;

        public QueueDispathcher(ITaskQueue taskQueue,ILogger<QueueDispathcher> logger) =>
            (Queue, Log) = (taskQueue, logger);

        protected override Task ExecuteAsync(CancellationToken ct)
        {
            // Log.LogInformation(
            //     $"{nameof(QueueService)} is running.{Environment.NewLine}" +
            //     $"{Environment.NewLine}Tap W to add a work item to the " +
            //     $"background queue.{Environment.NewLine}");

            return ProcessTaskQueueAsync(ct);
        }

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

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            Log.LogInformation(
                $"{nameof(QueueDispathcher)} is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }

}