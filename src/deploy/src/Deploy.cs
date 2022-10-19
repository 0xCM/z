//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId("deploy")]
namespace Z0.Parts
{
    public sealed class Deploy : Part<Deploy>
    {
    }
}

namespace Z0
{
    sealed class DeploymentServices : AppCmdService<DeploymentServices>
    {

    }

    [Free]
    sealed class App : AppCmdShell<App>
    {
        public static void Main(params string[] args)
        {
            using var app = AppShells.create<App>(false, args);            
            var wf = app.Wf;
            var running = wf.Running($"Creating command providers");
            var providers = new ICmdProvider[]{
                wf.WfCmd(),
            };
            wf.Ran(running, $"Created {providers.Length} command providers");
            app.CmdService = AppCmd.service<DeploymentServices>(wf, providers);
            app.Run(args);
        }
    }
}
