//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Counts the number of enabled bits in the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static uint pop<T>(BitVector128<T> src)
        where T : unmanaged
            => gbits.pop(src.State.AsUInt64().GetElement(0)) + gbits.pop(src.State.AsUInt64().GetElement(1));

    /// <summary>
    /// Counts the number of enabled bits in the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static uint pop<T>(BitVector256<T> src)
        where T : unmanaged
            => bits.pop(seg64(src,n0))
            + bits.pop(seg64(src,n1))
            + bits.pop(seg64(src,n2))
            + bits.pop(seg64(src,n3));
}
