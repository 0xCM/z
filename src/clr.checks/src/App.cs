//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.ClrChecks)]
namespace Z0.Parts
{
    public sealed class ClrChecks : Part<ClrChecks>
    {

    }
}
namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.BuildCmd(),
                wf.EcmaCmd()
            };

        public static void Main(params string[] args)
        {
            using var app = AppCmdShell.create<App>(false, args);
            var context = AppCmd.context<AppShellCmd>(app.Wf, () => providers(app.Wf));
            app.Commander = context.Commander;
            app.Run(args);            
        } 
        
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }
}