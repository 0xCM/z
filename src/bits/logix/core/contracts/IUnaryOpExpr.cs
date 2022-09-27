//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a unary operator parametrized by an expression type
    /// </summary>
    public interface IUnaryOpExpr<X> : IOperatorExpr
        where X : IExpr
    {
        /// <summary>
        /// The operand
        /// </summary>
        X Operand {get;}
    }
}