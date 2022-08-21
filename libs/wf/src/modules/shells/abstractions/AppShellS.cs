//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppShell<S> : WfApp<S>
        where S : AppShell<S>, new()
    {
        protected static S shell(params string[] args)
            => create(ApiRuntime.create(args));

        protected static S shell(bool catalog, params string[] args)
            => create(ApiRuntime.create(catalog, args));
    }
}