//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfRunner
    {
        Task<ExecToken> Start(IApiContext context, IWfAction action);
    }

    public interface IWfRunner<A> : IWfRunner
        where A : IWfRunner<A>, new()
    {
        Task<ExecToken> Start(IApiContext context, A action);

        Task<ExecToken> IWfRunner.Start(IApiContext context, IWfAction action)
            => Start(context, (A)action);
    }
}