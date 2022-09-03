//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITernaryLogicOpExpr :  ITernaryOpExpr<ILogicExpr>,  ILogicOpExpr<TernaryBitLogicKind>
    {

    }

    public interface ITernaryLogicOpExpr<T> : ITernaryLogicOpExpr, ITernaryOpExpr<ILogicExpr<T>>,ILogicOpExpr<T,TernaryBitLogicKind>
        where T : unmanaged
    {

    }
}