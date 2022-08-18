//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TernaryOpExpr<F,K> : OpExpr<F,K>
        where F : TernaryOpExpr<F,K>
        where K : unmanaged
    {
        public IExpr A {get;}

        public IExpr B {get;}

        public IExpr C {get;}

        [MethodImpl(Inline)]
        protected TernaryOpExpr(IExpr a, IExpr b, IExpr c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override string Format()
            => string.Format("{0}({1},{2})", OpName, A.Format(), B.Format(), C.Format());
    }
}