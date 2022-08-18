//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBinaryBitwiseOpExpr<T> : IBinaryOpExpr<ILogixExpr<T>>, IOperatorExpr<T,BinaryBitLogicKind>
        where T : unmanaged
    {
    }
}