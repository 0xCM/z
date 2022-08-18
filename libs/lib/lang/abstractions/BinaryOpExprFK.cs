//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class BinaryOpExpr<F,K> : OpExpr<F,K>
        where F : BinaryOpExpr<F,K>
        where K : unmanaged
    {
        public IExpr A {get;}

        public IExpr B {get;}

        [MethodImpl(Inline)]
        protected BinaryOpExpr(IExpr a, IExpr b)
        {
            A = a;
            B = b;
        }

        public override string Format()
            => string.Format("{0}({1},{2})", OpName, A.Format(), B.Format());

        public abstract F Create(IExpr a0, IExpr a1);
    }
}