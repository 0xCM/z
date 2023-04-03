//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IUnaryArithmeticOpExpr :  IArithmeticOpExpr
    {

    }

    public interface IUnaryArithmeticOpExpr<T> :  IUnaryArithmeticOpExpr, IArithmeticOpExpr<T, ApiUnaryArithmeticClass>
        where T : unmanaged
    {

    }
}