//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public sealed class RunLoop
{
    readonly ITaskQueue Queue;
    
    readonly IWfChannel Channel;
    
    readonly CancellationToken Ct;

    public RunLoop(ITaskQueue queue, IWfChannel channel, IHostApplicationLifetime lifetime)
    {
        Queue = queue;
        Channel = channel;
        Ct = lifetime.ApplicationStopping;
    }

    public void Start()
    {
        Channel.Status($"{nameof(MonitorAsync)} loop is starting.");

        // Run a console user input loop in a background thread
        Task.Run(async () => await MonitorAsync());
    }

    async ValueTask MonitorAsync()
    {
        while (!Ct.IsCancellationRequested)
        {
            var keyStroke = Console.ReadKey();
            if (keyStroke.Key == ConsoleKey.W)
            {
                // Enqueue a background work item
                await Queue.Enqueue(BuildWorkItemAsync);
            }
        }
    }

    async ValueTask BuildWorkItemAsync(CancellationToken token)
    {
        int delayLoop = 0;
        var guid = Guid.NewGuid();

        Channel.Status(string.Format("Queued work item {Guid} is starting.", guid));

        while (!token.IsCancellationRequested && delayLoop < 3)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(5), token);
            }
            catch (OperationCanceledException)
            {
                // Prevent throwing if the Delay is cancelled
            }

            ++ delayLoop;

            Channel.Status(string.Format("Queued work item {Guid} is running. {DelayLoop}/3", guid, delayLoop));
        }

        string format = delayLoop switch
        {
            3 => "Queued Background Task {Guid} is complete.",
            _ => "Queued Background Task {Guid} was cancelled."
        };

        Channel.Status(string.Format(format, guid));
    }
}
