//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        public class Eq : FreeCmpPred<Eq>
        {
            public Eq(IFreeExpr a, IFreeExpr b)
                : base(a,b)
            {
                Kind = CmpPredKind.EQ;
            }

            public override CmpPredKind Kind {get;}

            public override Eq Create(IFreeExpr a, IFreeExpr b)
                => new Eq(a,b);
        }
    }
}