//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FreeCmpPred<F> : FreeBinOp<F,CmpPredKind>
        where F : FreeCmpPred<F>
    {
        protected FreeCmpPred(IFreeExpr a, IFreeExpr b)
            : base(a,b)
        {
            Size = a.Size;
        }

        public override uint Size {get;}

        public override Identifier OpName
            => typeof(F).Name;
    }
}