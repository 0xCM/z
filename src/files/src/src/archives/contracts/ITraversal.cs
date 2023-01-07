//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITraversal<T,O>
    {
        Task<ExecToken> Start(Action<T> receiver, O options);
    }
}