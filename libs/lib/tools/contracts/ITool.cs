//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITool : IActor
    {

    }

    [Free]
    public interface ITool<L> : ITool, ILocatable<L>
        where L : IExpr
    {

    }
}