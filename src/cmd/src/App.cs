//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        public static void Main(params string[] args)
        {
            using var app = ApiCmd.shell<App>(false, args);            
            app.Commander = CmdPublic.context<AppShellCmd>(app.Wf).Commander;
            app.Run(args);
        }
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }
}