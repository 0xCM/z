//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class Delegates
{
    /// <summary>
    /// Creates a binary operator from a method
    /// </summary>
    /// <param name="src">The source method</param>
    /// <param name="host">The host instance if not static</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryOp<T> binop<T>(MethodInfo src, object host = null)
        where T : unmanaged
            => create<BinaryOp<T>>(src, host);
}
