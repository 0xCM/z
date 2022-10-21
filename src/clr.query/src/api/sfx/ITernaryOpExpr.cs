//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITernaryOpExpr<F,K,A0,A1,A2> : IOpExpr<K>
        where F : ITernaryOpExpr<F,K,A0,A1,A2>
        where K : unmanaged
    {
        F Create(A0 a0, A1 a1, A2 a2);
    }

    [Free]
    public interface ITernaryOpExpr<F,K,T> : ITernaryOpExpr<F,K,T,T,T>
        where F : ITernaryOpExpr<F,K,T>
        where K : unmanaged
    {

    }
}