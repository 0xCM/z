//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Distinguishes varied expressions from other sorts of expressions
    /// </summary>
    public interface IVariedExpr : IExprDeprecated
    {

    }

    /// <summary>
    /// Characterizes an expression that varies over a typed expression
    /// </summary>
    /// <typeparam name="T">The type over which the expression is defined</typeparam>
    public interface IVariedExpr<T> : IVariedExpr, ILogixExpr<T>
        where T : unmanaged
    {
        ILogixExpr<T> BaseExpr {get;}

        ILogixVarExpr<T>[] Vars {get;}

        void SetVars(params ILogixExpr<T>[] values);

        void SetVars(params T[] values);
    }
}