//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Not : UnaryOpExpr<Not,UnaryBitLogicKind>
    {
        public Not(IExpr a)
            : base(a)
        {
        }

        public override Identifier OpName
            => "not";

        public override UnaryBitLogicKind Kind
            => UnaryBitLogicKind.Not;

        public override Not Create(IExpr a)
            => new Not(a);
    }
}