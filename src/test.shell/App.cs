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
            using var app = AppShells.create<App>(false, args);            
            var wf = app.Wf;
            var running = wf.Running($"Creating command providers");
            app.CmdService = Cmd.service<AppShell>(wf, providers(wf));
            app.Run(args);            
        }
 
        // static IAppCmdSvc commands(IWfRuntime wf)
        //     => TestCmd.create(wf, new ICmdProvider[]{
        //         CheckCmd.create(wf)
        //     });

        // public static void Main(params string[] args)
        //     => run(commands, args);
    }

    sealed class AppShell : AppCmdService<AppShell>
    {

    }        
}