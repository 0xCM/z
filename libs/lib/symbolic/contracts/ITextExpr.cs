//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a variable-parametric text block
    /// </summary>
    public interface ITextExpr
    {
        /// <summary>
        /// The parametric body
        /// </summary>
        string Body {get;}

        /// <summary>
        /// The bound variable
        /// </summary>
        ITextVarExpr VarExpr {get;}

        /// <summary>
        /// Evaluates the body using the bound variable
        /// </summary>
        string Eval();
    }
}