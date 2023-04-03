//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a logical variable
    /// </summary>
    public interface ILogicVarExpr : ILogixVarExpr, ILogicExpr
    {
        /// <summary>
        /// Updates the variable
        /// </summary>
        /// <param name="expr">The value to assigned to the variable</param>
        void Set(ILogicExpr expr);

        /// <summary>
        /// Updates the expression value
        /// </summary>
        /// <param name="literal">The literal value to assign to the variable</param>
        void Set(Bit32 literal);

        /// <summary>
        /// The current value of the variable
        /// </summary>
        ILogicExpr Value {get;}
    }

    /// <summary>
    /// Characterizes a logical variable that also carries type information
    /// </summary>
    public interface ILogicVarExpr<T> :  ILogicVarExpr, ILogicExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// Updates the variable
        /// </summary>
        /// <param name="expr">The value to assigned to the variable</param>
        void Set(ILogicExpr<T> expr);

        /// <summary>
        /// The current value of the variable
        /// </summary>
        new ILogicExpr<T> Value {get;}
    }
}