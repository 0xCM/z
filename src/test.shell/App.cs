//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        static IAppCmdSvc commands(IWfRuntime wf)
            => TestCmd.create(wf, new ICmdProvider[]{
                CheckCmd.create(wf)
            });

        public static void Main(params string[] args)
            => run(commands, args);
    }
}