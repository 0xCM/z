//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

class AppController : BackgroundService
{
    readonly IWfRuntime Wf;

    public AppController(IWfRuntime wf, ILogger<AppController> logger, string[] args)
    {
        Wf = wf;
        var src = FS.dir(args[0]);
        var dst = AppDb.Service.Catalogs("fs.change");
        Require.invariant(src.Exists);
    }

    public override void Dispose()
    {
        Wf.Dispose();
    }

    protected override async Task ExecuteAsync(CancellationToken cancel)
    {
        while (!cancel.IsCancellationRequested)
            await Task.Delay(1000, cancel);
    }
}

