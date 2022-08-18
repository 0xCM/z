//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Expr<F,K> : IExpr<K>
        where F : Expr<F,K>
        where K : unmanaged
    {
        public abstract K Kind {get;}

        public abstract string Format();

        public override string ToString()
            => Format();
    }
}