//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        IMonitor ProcessMonitor;
        
        protected override void Run()
        {
            ProcessMonitor = Channel.ProcessMonitor();
            ProcessMonitor.Start();
            ApiCmdLoop.start(Channel, CmdRunner).Wait();
        }

        public static int Main(params string[] args)
        {
            var result = 0;
            using var app = ApiServers.shell<App>(args);
            try
            {
                app.Run();
            }
            catch(Exception e)
            {
                app.Channel.Error(e);
                result = -1;
            }
            return result;
        }

    }
}