//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IUnaryBitLogicOp<F,T> : IUnaryOpExpr<F,UnaryBitLogicKind,T>
        where F : IUnaryBitLogicOp<F,T>
    {

    }
}