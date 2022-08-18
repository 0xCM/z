//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly:PartId(PartId.DbShell)]
namespace Z0
{
    sealed class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.DbCmd(),
            };

        public static AppCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));
    }

    [Free]
    sealed class App : AppCmdShell<App>
    {
        public static void Main(params string[] args)
            => run(wf => AppCmd.commands(wf), args);
    }
}

namespace Z0.Parts
{
    public sealed class DbShell : Part<DbShell>
    {

    }
}
