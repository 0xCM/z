//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                CheckCmd.create(wf)
            };

        public static void Main(params string[] args)
        {
            using var app = AppCmdShell.create<App>(false, args);
            var context = WfCmd.context<AppShellCmd>(app.Wf, () => providers(app.Wf));
            app.Commander = context.Commander;
            app.Run(args);            
        } 
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }        
}