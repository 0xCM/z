//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ILogicOp : IOpExpr
    {

    }

    [Free]
    public interface ILogicOp<K> :  ILogicOp, IKinded<K>
        where K : unmanaged
    {

    }
}