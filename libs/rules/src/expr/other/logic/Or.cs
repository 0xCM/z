//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Ops;

    partial class LogicOps
    {
        public class Or : BinaryOpExpr<Or,LogicExprKind>, ILogicOp
        {
            public Or(IExpr a, IExpr b)
                : base(a,b)
            {
            }

            public override Identifier OpName
                => "or";

            public override LogicExprKind Kind
                => LogicExprKind.Or;

            public override Or Create(IExpr a, IExpr b)
                => new Or(a,b);
        }
    }
}