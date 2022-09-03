//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppShell
    {
        public static A create<A>(bool catalog, params string[] args)
            where A : IWfApp<A>,new()
        {
            var wf = ApiRuntime.create(catalog, args);
            var app = new A();
            app.Init(wf);
            return app;
        }            
    }

    public abstract class AppShell<S> : WfApp<S>
        where S : AppShell<S>, new()
    {
        protected static S shell(params string[] args)
            => AppShell.create<S>(false, args);

        protected static S shell(bool catalog, params string[] args)
            => AppShell.create<S>(catalog, args);
    }
}