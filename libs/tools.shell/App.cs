//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        public static void Main(params string[] args)
            => run(wf => AppShellCmd.commands(wf), args);
    }


    sealed class AppShellCmd : AppCmdService<AppShellCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.ToolCmd(), 
                wf.BuildCmd(),
                };

        public static AppShellCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));
    }
}