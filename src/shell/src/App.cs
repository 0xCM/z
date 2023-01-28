//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        static ReadOnlySeq<IApiCmdProvider> providers(IWfRuntime wf)
            => new IApiCmdProvider[]{
                wf.WfCmd(),
                wf.BuildCmd(),
                wf.EnvCmd(),
                wf.ImageCmd(),
                wf.ArchiveCmd(),
            };

        static int main(string[] args)
        {
            var result = 0;
            using var app = ApiServers.shell<App,AppCmd>(false, args, providers);
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

        public static int Main(params string[] args)
            => main(args);
    }

    sealed class AppCmd : WfAppCmd<AppCmd>
    {

    }
}