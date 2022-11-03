//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FreeOpExpr<F,K> : IFreeExpr<F>,  IKinded<K>, IKinded
        where F : FreeOpExpr<F, K>
        where K : unmanaged
    {
        public virtual Identifier OpName => typeof(F).Name;

        public abstract string Format();

        public abstract K Kind {get;}

        public abstract uint Size {get;}

        public virtual bool IsEmpty => false;

        public override string ToString()
            => Format();
    }
}