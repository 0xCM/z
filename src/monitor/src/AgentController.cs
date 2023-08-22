//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

class AgentController : BackgroundService
{
    readonly IAgent Monitor;
    
    public AgentController(ILogger<AgentController> logger, string[] args)
    {
        var src = FS.dir(args[0]);
        var dst = AppDb.Service.Catalogs("fs.change");
        Require.invariant(src.Exists);
        Monitor = DirectoryMonitor.create(new DbArchive(src), dst);
        Monitor.Start();
    }

    public override void Dispose()
    {
        Monitor.Stop();
    }

    protected override async Task ExecuteAsync(CancellationToken cancel)
    {
        while (!cancel.IsCancellationRequested)
            await Task.Delay(1000, cancel);
    }
}

