//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an expression defined via an operator
    /// </summary>
    public interface IOperatorExpr : IExprDeprecated
    {

    }

    /// <summary>
    /// Characterizes a parametric operator that varies over operand type
    /// </summary>
    /// <typeparam name="T">The type over which the expression is defined</typeparam>
    public interface IOperatorExpr<T> : IOperatorExpr, ILogixExpr<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a parametric operator that varies over operator kind and operand type
    /// </summary>
    /// <typeparam name="T">The type over which the expression is defined</typeparam>
    /// <typeparam name="K">The operator classifier</typeparam>
    public interface IOperatorExpr<T,K> : IOperatorExpr<T>
        where T : unmanaged
        where K : unmanaged
    {
        /// <summary>
        /// Specifies the class to which the operator belongs
        /// </summary>
        K ApiClass {get;}
    }
}