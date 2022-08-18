//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBinaryLogicOpExpr : IBinaryOpExpr<ILogicExpr>, ILogicOpExpr<BinaryBitLogicKind>
    {

    }

    public interface IBinaryLogicOpExpr<T> : IBinaryLogicOpExpr, IBinaryOpExpr<ILogicExpr<T>>,  ILogicOpExpr<T,BinaryBitLogicKind>
        where T : unmanaged
    {

    }
}