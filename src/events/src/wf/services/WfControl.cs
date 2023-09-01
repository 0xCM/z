//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

public class WfControl : BackgroundService, IWfControl
{
    public static IHostBuilder configure(IWfRuntime wf, string[] args, params Action<CancellationToken>[] workers)
        => Host.CreateDefaultBuilder(args).ConfigureServices((c,s) => configure(wf, s, args, workers));

    static IWfControl configure(IWfRuntime wf, IServiceCollection services, string[] args, params Action<CancellationToken>[] workers)
    {
        var controller = default(WfControl);
        WfControl AddController(IServiceProvider provider)
        {
            controller = new (wf, provider.GetService<ILogger<WfControl>>(), args, workers);
            return controller;
        }
                
        services.AddHostedService(AddController);
        return controller;
    }

    readonly IWfRuntime Wf;

    public readonly IDbArchive Targets;

    readonly Action<CancellationToken>[] Workers;
    
    public WfControl(IWfRuntime wf, ILogger<WfControl> logger, string[] args, params Action<CancellationToken>[] workers)
    {
        Wf = wf;
        Targets = FS.archive(args[0]);
        Targets.Root.Create();
        Workers = workers;
    }

    public override void Dispose()
    {
        Wf.Dispose();
    }

    protected override async Task ExecuteAsync(CancellationToken cancel)
    {
        var tasks = Workers.Select(x => sys.start(() => x(cancel)));
        var finished = false;
        while (!cancel.IsCancellationRequested && !finished)
        {
            Task.WaitAll(tasks,1000);
            await Task.Delay(1, cancel);
        }        
    }
}
