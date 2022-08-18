//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IUnaryBitwiseOpExpr<T> : IUnaryOpExpr<ILogixExpr<T>>, IOperatorExpr<T, UnaryBitLogicKind>
        where T : unmanaged
    {

    }
}