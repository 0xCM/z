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
        {
            using var app = AppShell.create<App>(false, args);            
            var wf = app.Wf;
            var running = wf.Running($"Creating command providers");
            var providers = new ICmdProvider[]{
                wf.WfCmd(),
            };
            wf.Ran(running, $"Created {providers.Length} command providers");
            app.CmdService = Cmd.service<AppCmd>(wf, providers);
            app.Run();
        }
    }
}