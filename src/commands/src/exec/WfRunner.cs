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

        public abstract Task<ExecToken> Start(IApiContext context, IWfAction action);
    }
}