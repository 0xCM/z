//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>, IFileChangeReceiver
    {

        static int main(string[] args)
        {
            if(args.Length == 0)
            {
                term.error("Project directory not specified");
                return -1;
            }

            var result = 0;
            using var app = ApiServers.shell<App>(args);
            try
            {
                var channel = app.Channel;
                var running = ExecFlow<string>.Empty;
                DevProjects.launch(channel, FS.dir(args[0]), 
                    p => running = channel.Running($"Process started: {p.ProcessName} {p.Id}"), 
                    e => channel.Ran(running, $"Process exit code: ${e}"));
                app.Run();
            }
            catch(Exception e)
            {
                app.Channel.Error(e);
                result = -1;
            }
            return result;
        }

        IMonitor Monitor;
        
        protected override void Run()
        {
            var root = FS.dir(Args[0]).DbArchive();
            var dst = root.Scoped("db");
            Monitor = DirectoryMonitor.start(root,dst,this);
            CmdLoop.start(Channel, CmdRunner).Wait();
        }

        public static int Main(params string[] args)
            => main(args);

        public void Deposit(FileChangeEvent src)
        {
                        
        }

        protected override void Disposing()
        {
            base.Disposing();
            Monitor.Dispose();
        }
    }

    sealed class AppCmd : WfAppCmd<AppCmd>
    {

    }
}