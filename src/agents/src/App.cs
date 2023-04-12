//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {

        static int main(string[] args)
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

        IMonitor ProcessMonitor;
        
        protected override void Run()
        {
            ProcessMonitor = Channel.ProcessMonitor();
            ProcessMonitor.Start();
            CmdLoop.start(Channel, CmdRunner).Wait();
        }

        public static int Main(params string[] args)
            => main(args);

    }
}