//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IUnaryLogicOpExpr : IUnaryOpExpr<ILogicExpr>, ILogicOpExpr<UnaryBitLogicKind>
    {

    }

    public interface IUnaryLogicOpExpr<T> :  IUnaryLogicOpExpr, IUnaryOpExpr<ILogicExpr<T>>, ILogicOpExpr<T,UnaryBitLogicKind>
        where T : unmanaged
    {

    }
}