//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FreeBinOp<F,K> : FreeOpExpr<F,K>
        where F : FreeBinOp<F,K>
        where K : unmanaged
    {
        public IFreeExpr A { get; }

        public IFreeExpr B { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected FreeBinOp(IFreeExpr a, IFreeExpr b)
        {
            A = a;
            B = b;
            Size = a.Size;
        }

        public override string Format()
        {
            return $"{OpName}({A.Format()},{B.Format()})";
        }

        public override uint Size {get;}

        public abstract F Create(IFreeExpr a0, IFreeExpr a1);
    }

    public abstract class FreeBinOp<F,K,T> : FreeBinOp<F,K>
        where F : FreeBinOp<F,K,T>
        where K : unmanaged
        where T : unmanaged
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected FreeBinOp(IFreeExpr a, IFreeExpr b)
                :base(a,b)
        {
        }
    }
}