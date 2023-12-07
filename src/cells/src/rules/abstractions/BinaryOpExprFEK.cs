//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class BinaryOpExpr<F,E,K> : OpExpr<F,K>
        where F : BinaryOpExpr<F,E,K>
        where E : IExpr
        where K : unmanaged
    {
        public E A {get;}

        public E B {get;}

        [MethodImpl(Inline)]
        protected BinaryOpExpr(E a, E b)
        {
            A = a;
            B = b;
        }

        public override string Format()
            => string.Format("{0}({1},{2})", OpName, A.Format(), B.Format());

        public abstract F Create(E a, E b);
    }
}