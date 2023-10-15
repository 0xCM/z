//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


public static partial class XTend
{
    /// <summary>
    /// Reads a partial value if there aren't a sufficient number of bytes to comprise a target value
    /// </summary>
    /// <param name="src">The source span</param>
    /// <typeparam name="T">The target type</typeparam>
    [MethodImpl(Inline), Op, Closures(UnsignedInts)]
    public static T TakeScalar<T>(this ReadOnlySpan<bit> src)
        where T : unmanaged
            => BitPack.scalar<T>(src);
}
