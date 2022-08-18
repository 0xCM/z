//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        public class Ge : FreeCmpPred<Ge>
        {
            public Ge(IFreeExpr a, IFreeExpr b)
                : base(a,b)
            {
            }

            public override CmpPredKind Kind
                => CmpPredKind.GE;

            public override Ge Create(IFreeExpr a, IFreeExpr b)
                => new Ge(a,b);
        }
    }
}