//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        public static int Main(string[] args)
        {
            var result = 0;
            try
            {
                using var shell = ApiServer.shell(ApiServer.runtime(), args);
                if(args.Length == 0)
                {
                    shell.Run();
                }
                else
                {                                
                    shell.Runner.RunCommand(ApiServer.spec(args));
                }
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