//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Reflection.Emit;

partial class Delegates
{
    /// <summary>
    /// Creates a parameteric dynamic delegate
    /// </summary>
    /// <param name="id">The identity to confer on the result</param>
    /// <param name="src">The source method</param>
    /// <param name="dst">The dynamic method</param>
    /// <typeparam name="D">The target delegate type</typeparam>
    [MethodImpl(Inline)]
    public static DynamicDelegate<D> dynamic<D>(OpIdentity id, MethodInfo src, DynamicMethod dst)
        where D : Delegate
            => new DynamicDelegate<D>(id, src, dst, (D)dst.CreateDelegate(typeof(D)));

    /// <summary>
    /// Creates a non-parameteric dynamic delegate
    /// </summary>
    /// <param name="id">The identity to confer on the result</param>
    /// <param name="src">The source method</param>
    /// <param name="dst">The dynamic method</param>
    /// <param name="@delegate">The target delegate type</param>
    [MethodImpl(Inline), Op]
    public static DynamicDelegate dynamic(OpIdentity id, MethodInfo src, DynamicMethod dst, Type @delegate)
        => new DynamicDelegate(id, src, dst, dst.CreateDelegate(@delegate));

    /// <summary>
    /// Creates a non-parameteric dynamic delegate
    /// </summary>
    /// <param name="id">The identity to confer on the result</param>
    /// <param name="src">The source method</param>
    /// <param name="dst">The dynamic method</param>
    /// <param name="@delegate">The target delegate type</param>
    [MethodImpl(Inline), Op]
    public static DynamicDelegate dynamic(OpIdentity id, MethodInfo src, DynamicMethod dst, Delegate op)
        => new DynamicDelegate(id, src, dst, op);
}
