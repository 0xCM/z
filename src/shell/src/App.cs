//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.Shell)]
namespace Z0.Parts
{
    public sealed class Shell : Part<Shell>
    {
        [ModuleInitializer]
        internal static void Init()
        {
            NumRender.Service.RegisterFomatters();
        }
    }
}

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
                wf.ToolCmd()
            };
            wf.Ran(running, $"Created {providers.Length} command providers");
            app.CmdService = Cmd.service<AppShellCmd>(wf, providers);
            app.Run();
        }
    }

    sealed class AppShellCmd : AppCmdService<AppShellCmd>
    {

    }
}