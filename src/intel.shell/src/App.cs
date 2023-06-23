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
            var wf = ApiServers.runtime(false);
            using var app = ApiServers.shell(wf, args);
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

    sealed class AppCmd : WfAppCmd<AppCmd>
    {
        void CmdServices()
        {
            //var src = FS.path(ExecutingPart.Assembly.Location).FolderPath;
            
        }

    }
}