//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Or : BinaryOpExpr<Or,BinaryBitLogicKind>
    {
        public Or(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Identifier OpName
            => "or";

        public override BinaryBitLogicKind Kind
            => BinaryBitLogicKind.Or;

        public override Or Create(IExpr a, IExpr b)
            => new Or(a,b);
    }
}