//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        public static IApiCmdProvider[] providers(IWfRuntime wf)
            => new IApiCmdProvider[]{
                CheckCmd.create(wf)
            };

        public static void Main(params string[] args)
        {
            using var app = ApiServers.shell<App>(false, args);
            var context = ApiServers.context<AppShellCmd>(app.Wf, () => providers(app.Wf));
            app.Commander = context.Commander;
            app.Run(args);            
        } 
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }        
}