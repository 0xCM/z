//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEdge : IExpr
    {

    }

    [Free]
    public interface IEdge<V> : IEdge, IArrow<V>
    {

    }
}