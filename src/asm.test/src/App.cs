//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        public static int Main(params string[] args)
        {
            var result = 0;
            using var app = ApiServers.shell(args);
            try
            {
                app.Run();
            }
            catch(Exception e)
            {
                term.error(e);
                result = -1;
            }
            return result;
        }
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }
}