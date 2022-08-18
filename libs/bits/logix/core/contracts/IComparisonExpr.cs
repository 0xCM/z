//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a claim that two variable-dependent comparison expressions are equivalent
    /// </summary>
    public interface IComparisonExpr : ILogicExpr
    {
        /// <summary>
        /// The left expression
        /// </summary>
        ILogicExpr Left {get;}

        /// <summary>
        /// The right expression
        /// </summary>
        ILogicExpr Right {get;}

        /// <summary>
        /// Variables upon which the expression depends
        /// </summary>
        ILogicVarExpr[] Vars {get;}
    }

    /// <summary>
    /// Characterizes a claim that two variable-dependent typed comparison expressions are equivalent
    /// </summary>
    public interface IComparisonExpr<T> : ILogixExpr<T>
    {
        /// <summary>
        /// The left expression
        /// </summary>
        ILogixExpr<T> Left {get;}

        /// <summary>
        /// The right expression
        /// </summary>
        ILogixExpr<T> Right {get;}

        /// <summary>
        /// Variables upon which the expression depends
        /// </summary>
        ILogixVarExpr<T>[] Vars {get;}

        /// <summary>
        /// The sort of comparison to be applied
        /// </summary>
        ApiComparisonClass ComparisonKind {get;}
    }
}