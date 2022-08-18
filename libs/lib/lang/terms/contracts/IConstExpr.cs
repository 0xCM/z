//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IConstExpr<T> : IValued<T>, ITerm<T>
    {

    }

    public interface IConstExpr<E,T> : IConstExpr<T>, ITerm<E,T>
        where E : IConstExpr<E,T>
    {

    }
}