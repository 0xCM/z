//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppCmdShell<S> : AppShell<S>
        where S : AppCmdShell<S>, new()
    {
        protected IAppCmdSvc CmdService;

        protected static void run(Func<IWfRuntime,IAppCmdSvc> f, params string[] args)
        {
            using var app = AppShell.create<S>(false, args);
            app.CmdService = f(app.Wf);
            app.Run();
        }

        protected static void run(Func<IWfRuntime,IAppCmdSvc> factory, bool catalog, params string[] args)
        {
            using var app = AppShell.create<S>(catalog, args);
            app.CmdService = factory(app.Wf);
            app.Run();
        }

        protected static void run<C>(Func<IWfRuntime,IAppCmdSvc> factory, C context, IRunnable<C> runnable, params string[] args)
        {
            using var app = AppShell.create<S>(false, args);
            app.CmdService = factory(app.Wf);
            runnable.Run(context);
        }

        protected static void run(Func<IWfRuntime,IAppCmdSvc> factory, IRunnable<S> runnable, params string[] args)
        {
            using var app = AppShell.create<S>(false, args);
            app.CmdService = factory(app.Wf);
            runnable.Run(app);
        }

        protected override void Disposing()
        {
            CmdService?.Dispose();
        }

        protected override void Run()
            => CmdService.Run();
    }
}