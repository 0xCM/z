//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBinaryOpExpr<F,K,A0,A1> : IOpExpr<K>
        where F : IBinaryOpExpr<F,K,A0,A1>
        where K : unmanaged
    {
        F Create(A0 a0, A1 a1);
    }

    [Free]
    public interface IBinaryOpExpr<F,K,T> : IBinaryOpExpr<F,K,T,T>
        where F : IBinaryOpExpr<F,K,T>
        where K : unmanaged
    {
    }
}