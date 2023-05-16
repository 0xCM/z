//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IFlow : IExpr
    {
    }

    [Free]
    public interface IFlow<S,T> : IFlow, IArrow<S,T>
    {

    }
}