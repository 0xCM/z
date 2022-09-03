//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IUnaryOpExpr<F,K,T> : IOpExpr<K>
        where F : IUnaryOpExpr<F,K,T>
        where K : unmanaged
    {
        F Create(T src);
    }
}