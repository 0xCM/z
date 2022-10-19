//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WfRunner : IWfRunner
    {
        public static R create<R>()
            where R : IWfRunner<R>, new()
                => new R();

        public abstract Task<ExecToken> Start(IWfContext context, IWfAction action);
    }

    public abstract class WfRunner<A> : WfRunner, IWfRunner<A>
        where A : WfRunner<A>, new()
    {

        public abstract Task<ExecToken> Start(IWfContext context, A action);
    }
}