//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class AppCmdShell : AppShell<AppCmdShell>
    {
        IAppCmdSvc CmdService;

        protected override void Initialized()
        {
            CmdService = GenCmdProvider.create(Wf);
        }


        protected override void Disposing()
        {
            CmdService?.Dispose();
        }

        protected override void Run(string[] args)
            => CmdService.Run();

        public static void Main(params string[] args)
        {
            using var wf = ApiRuntime.create(args);
            using var shell = create(wf);
            shell.Run(args);
        }
    }
}