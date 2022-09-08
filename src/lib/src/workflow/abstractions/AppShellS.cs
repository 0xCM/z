//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppShell
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

    public abstract class AppShell<A> : AppService<A>, IAppShell
        where A : AppShell<A>, new()
    {
        protected abstract void Run();

        protected virtual void OnExit()
        {

        }

        protected virtual void Run(string[] args)
            => Run();

        void IAppShell.OnExit()
            => OnExit();
            
        void IAppShell.Run()
            => Run();

        void IAppShell.Run(string[] args)
            => Run(args);
    }
}