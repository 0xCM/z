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

        protected override void Run(string[] args)
        {
            CmdLoop.start(Channel).Wait();
        }

        public static int Main(params string[] args)
            => main(args);
    }

    sealed class AppCmd : WfAppCmd<AppCmd>
    {

    }
}