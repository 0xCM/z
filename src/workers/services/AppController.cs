//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    class AppController : BackgroundService
    {
        readonly IWfRuntime Wf;

        readonly IMonitor Monitor;
        
        public AppController(IWfRuntime wf, ILogger<AppController> logger, string[] args)
        {
            Wf = wf;
            var src = Datasets.archive(FS.dir(args[0]));
            var dst = AppDb.Service.Catalogs("fs.change");
            Require.invariant(src.Exists);
            Monitor = DirectoryMonitor.start(src, dst);
        }

        public override void Dispose()
        {
            Monitor.Stop();
            Wf.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken cancel)
        {
            while (!cancel.IsCancellationRequested)
                await Task.Delay(1000, cancel);
        }
    }
}
