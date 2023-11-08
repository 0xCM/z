//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Characterizes a variable
/// </summary>
public interface ILogixVarExpr : IExprDeprecated
{
    /// <summary>
    /// The name of the variable
    /// </summary>
    string Name {get;}
}

/// <summary>
/// Characterizes a typed variable
/// </summary>
public interface ILogixVarExpr<T> : ILogixVarExpr, ILogixExpr<T>
{
    /// <summary>
    /// Updates the variable
    /// </summary>
    /// <param name="expr">The value to assigned to the variable</param>
    void Set(ILogixExpr<T> expr);

    /// <summary>
    /// Updates the expression value
    /// </summary>
    /// <param name="literal">The literal value to assign to the variable</param>
    void Set(T literal);

    /// <summary>
    /// The current value of the variable
    /// </summary>
    ILogixExpr<T> Value {get;}
}
