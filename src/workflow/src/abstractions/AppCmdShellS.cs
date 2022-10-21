//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCmdShell
    {
        public static A create<A>(bool catalog, params string[] args)
            where A : IAppShell, new()
        {
            var wf = ApiRuntime.create(catalog, args);
            var app = new A();
            app.Init(wf);
            return app;
        }                    
    }

    public abstract class AppCmdShell<S> : AppShell<S>
        where S : AppCmdShell<S>, new()
    {
        protected IAppCmdSvc Commander;

        // protected static void run(Func<IWfRuntime,IAppCmdSvc> f, params string[] args)
        // {
        //     using var app = AppCmd.shell<S>(false, args);
        //     app.Commander = f(app.Wf);
        //     app.Run(args);
        // }

        // protected static void run(Func<IWfRuntime,IAppCmdSvc> factory, bool catalog, params string[] args)
        // {
        //     using var app = AppCmd.shell<S>(catalog, args);
        //     app.Commander = factory(app.Wf);
        //     app.Run(args);
        // }

        // protected static void run<C>(Func<IWfRuntime,IAppCmdSvc> factory, C context, IRunnable<C> runnable, params string[] args)
        // {
        //     using var app = AppCmd.shell<S>(false, args);
        //     app.Commander = factory(app.Wf);
        //     runnable.Run(context);
        // }

        // protected static void run(Func<IWfRuntime,IAppCmdSvc> factory, IRunnable<S> runnable, params string[] args)
        // {
        //     using var app = AppCmd.shell<S>(false, args);
        //     app.Commander = factory(app.Wf);
        //     runnable.Run(app);
        // }

        protected override void Disposing()
        {
            Commander?.Dispose();
        }

        protected override void Run(string[] args)
            => Commander.Run();
    }
}