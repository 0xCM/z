//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class LogicOps
    {
        public class Xor : BinaryOpExpr<Xor,IBooleanExpr,LogicExprKind>, ILogicOp
        {
            public Xor(IBooleanExpr a, IBooleanExpr b)
                : base(a,b)
            {

            }

            public override LogicExprKind Kind
                => LogicExprKind.XOr;

            public override Identifier OpName
                => "xor";

            public override Xor Create(IBooleanExpr a, IBooleanExpr b)
                => new Xor(a,b);
        }
    }
}