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
            using var app = ApiServers.shell<App>();
            try
            {
                var projects = app.Wf.ProjectManager();
                var running = ExecFlow<string>.Empty;
                projects.Launch(FS.dir(args[0]), 
                    p => running = app.Channel.Running($"Process started: {p.ProcessName} {p.Id}"), 
                    e => app.Channel.Ran(running, $"Process exit code: ${e}"));
                app.Run(args);
            }
            catch(Exception e)
            {
                app.Channel.Error(e);
                result = -1;
            }
            return result;
        }

        IMonitor Monitor;
        
        protected override void Run(string[] args)
        {
            var root = FS.dir(args[0]).DbArchive();
            var dst = root.Scoped("db");
            Monitor = DirectoryMonitor.start(root,dst,this);
            CmdLoop.start(Channel).Wait();
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