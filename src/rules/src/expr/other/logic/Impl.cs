//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class LogicOps
    {
        /// <summary>
        /// Represents logical implication: impl(a,b) := or(a, not(b))
        /// </summary>
        public class Impl : BinaryOpExpr<Impl,IBooleanExpr,LogicExprKind>
        {
            public Impl(IBooleanExpr a, IBooleanExpr b)
                : base(a,b)
            {
            }

            public override Identifier OpName
                => "impl";


            public override LogicExprKind Kind
                => LogicExprKind.Impl;

            public override Impl Create(IBooleanExpr a, IBooleanExpr b)
                => new Impl(a,b);
        }
    }
}