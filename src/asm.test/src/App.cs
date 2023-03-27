//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        static ReadOnlySeq<IApiService> providers(IWfRuntime wf)
            => new IApiService[]{
                wf.WfCmd(),
                wf.XedCmd(),
                wf.IntelInxCmd(),
                wf.ImageCmd(),
                wf.AsmCheckCmd(),
            };

        static int main(string[] args)
        {
            var result = 0;
            using var app = ApiServers.shell<App>();
            var context = ApiServers.context<AppShellCmd>(app.Wf, () => providers(app.Wf));
            app.Commander = context.Commander;
            try
            {
                app.Run();
            }
            catch(Exception e)
            {
                app.Channel.Error(e);
                result = -1;
            }
            //ProcessControl.Control().Dispose();
            return result;
        }

        public static int Main(params string[] args)
            => main(args);
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }
}