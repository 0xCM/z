//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class Delegates
{
    /// <summary>
    /// Creates an untyped delegate
    /// </summary>
    /// <param name="src">The target method</param>
    /// <param name="tDelegate">The delegate type</param>
    /// <param name="host">The host instance if not static</param>
    [MethodImpl(Inline), Op]
    public static Delegate create(MethodInfo src, Type tDelegate, object host)
        => sys.@delegate(src, tDelegate, host);

    /// <summary>
    /// Creates an untyped delegate
    /// </summary>
    /// <param name="src">The target method</param>
    /// <param name="tDelegate">The delegate type</param>
    /// <param name="host">The host instance if not static</param>
    [MethodImpl(Inline), Op]
    public static Delegate create(MethodInfo src, Type tDelegate)
        => sys.@delegate(src, tDelegate, null);

    /// <summary>
    /// Creates a generic delegate
    /// </summary>
    /// <param name="src">The target method</param>
    /// <typeparam name="D">The delegate type</typeparam>
    [MethodImpl(Inline)]
    public static D create<D>(MethodInfo src, object host)
        where D : Delegate
            => (D)sys.@delegate(src, typeof(D), host);

    /// <summary>
    /// Creates a generic delegate
    /// </summary>
    /// <param name="src">The target method</param>
    /// <typeparam name="D">The delegate type</typeparam>
    [MethodImpl(Inline)]
    public static D create<D>(MethodInfo src)
        where D : Delegate
            => (D)sys.@delegate(src, typeof(D), null);
}
