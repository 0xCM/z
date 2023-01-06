//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class RunLoop
    {
        readonly ITaskQueue Queue;
        
        readonly ILogger<RunLoop> Log;
        
        readonly CancellationToken Ct;

        public RunLoop(ITaskQueue queue,ILogger<RunLoop> log, IHostApplicationLifetime lifetime)
        {
            Queue = queue;
            Log = log;
            Ct = lifetime.ApplicationStopping;
        }

        public void StartMonitorLoop()
        {
            Log.LogInformation($"{nameof(MonitorAsync)} loop is starting.");

            // Run a console user input loop in a background thread
            Task.Run(async () => await MonitorAsync());
        }

        private async ValueTask MonitorAsync()
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

        private async ValueTask BuildWorkItemAsync(CancellationToken token)
        {
            // Simulate three 5-second tasks to complete
            // for each enqueued work item

            int delayLoop = 0;
            var guid = Guid.NewGuid();

            Log.LogInformation("Queued work item {Guid} is starting.", guid);

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

                Log.LogInformation("Queued work item {Guid} is running. {DelayLoop}/3", guid, delayLoop);
            }

            string format = delayLoop switch
            {
                3 => "Queued Background Task {Guid} is complete.",
                _ => "Queued Background Task {Guid} was cancelled."
            };

            Log.LogInformation(format, guid);
        }
    }
}