//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WfApp<A> : AppService<A>, IWfApp<A>
        where A : WfApp<A>, new()
    {
        protected abstract void Run();

        protected virtual void Run(string[] args)
            => Run();

        void IWfApp.Run()
            => Run();

        void IWfApp.Run(string[] args)
            => Run(args);
    }
}