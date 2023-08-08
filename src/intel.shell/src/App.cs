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
            using var shell = ApiServers.shell(ApiServers.runtime(), args);
            try
            {
                if(args.Length == 0)
                    shell.Run();
                else
                    shell.Runner.RunCommand(ApiCmd.spec(args));
            }
            catch(Exception e)
            {
                term.error(e);
                result = -1;
            }
            return result;
        }
    }
}