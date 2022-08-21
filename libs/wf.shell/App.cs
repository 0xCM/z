//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.WfShell)]
namespace Z0
{
    sealed class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
            };

        public static AppCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));
    }

    [Free]
    sealed class App : AppCmdShell<App>
    {
        public static void Main(params string[] args)
            => run(wf => AppCmd.commands(wf), false, args);
    }
}

namespace Z0.Parts
{
    public sealed class WfShell : Part<WfShell>
    {

    }
}
