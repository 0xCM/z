//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a typed ternary bitwise operator
    /// </summary>
    /// <typeparam name="T">The type over which the operator is defined</typeparam>
    public interface ITernaryBitwiseOpExpr<T> : ITernaryOpExpr<ILogixExpr<T>>, IOperatorExpr<T,TernaryBitLogicKind>
        where T : unmanaged
    {


    }
}