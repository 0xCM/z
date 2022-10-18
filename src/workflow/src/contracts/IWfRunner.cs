//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IActionable
    {
        Task<ExecToken> Start(IWfContext context, IWfAction action);
    }

    public interface IActionable<A> : IActionable
        where A : IActionable<A>, new()
    {
        Task<ExecToken> Start(IWfContext context, A action);

        Task<ExecToken> IActionable.Start(IWfContext context, IWfAction action)
            => Start(context, (A)action);
    }
}