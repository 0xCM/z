//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILogicExpr : IExpr
    {
        bool INullity.IsEmpty
            => false;
    }

    /// <summary>
    /// Characterizes a typed expression that admits logical evaluation
    /// </summary>
    /// <typeparam name="T">The type over which the expression is defined</typeparam>
    public interface ILogicExpr<T> : ILogicExpr, ILogixExpr<T>
        where T : unmanaged
    {

    }
}