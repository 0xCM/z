//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class UnaryOpExpr<F,K> : OpExpr<F,K>
        where F : UnaryOpExpr<F,K>
        where K : unmanaged
    {
        public IExpr A {get;}

        protected UnaryOpExpr(IExpr a)
        {
            A = a;
        }

        public override string Format()
            => string.Format("{0}({1})", OpName, A.Format());

        public abstract F Create(IExpr src);
    }
}