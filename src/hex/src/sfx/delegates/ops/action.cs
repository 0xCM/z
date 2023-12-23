//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class Delegates
{
    /// <summary>
    /// Creates an action delegate from a method
    /// </summary>
    /// <param name="src">The source method</param>
    [MethodImpl(Inline), Op]
    public static Action action(MethodInfo src, object host)
        => create<Action>(src, host);

    /// <summary>
    /// Creates an action delegate from a method
    /// </summary>
    /// <param name="src">The source method</param>
    [MethodImpl(Inline), Op]
    public static Action action(MethodInfo src)
        => create<Action>(src);
}
