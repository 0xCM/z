//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        public class Sll : FreeBinOp<Sll,BinaryBitLogicKind>
        {
            public Sll(IFreeExpr a, IFreeExpr b)
                : base(a,b)
            {
            }

            public override BinaryBitLogicKind Kind
                => BinaryBitLogicKind.And;

            public override Sll Create(IFreeExpr a, IFreeExpr b)
                => new Sll(a,b);
        }
    }
}