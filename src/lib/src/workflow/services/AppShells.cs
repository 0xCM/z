//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppShells
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
}