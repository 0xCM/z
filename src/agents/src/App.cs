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
            var result = 0;
            using var app = ApiServers.shell<App>();
            try
            {
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
            var root = (args.Length == 0 ? Env.cd() : FS.dir(args[0])).ToArchive();
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