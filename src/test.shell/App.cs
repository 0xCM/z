//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        public static IApiService[] providers(IWfRuntime wf)
            => new IApiService[]{
                CheckCmd.create(wf)
            };

        public static void Main(params string[] args)
        {
            using var app = ApiServer.shell<App>(args);
            if(args.Length == 0)
                app.Run();
            else
                app.Runner.RunCommand(ApiServer.command(args));
        } 
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }        
}