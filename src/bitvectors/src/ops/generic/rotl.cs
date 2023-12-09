//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Rotates source bits leftward
    /// </summary>
    /// <param name="src">The source bitvector</param>
    /// <param name="count">The rotation magnitude</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitVector128<T> rotl<T>(in BitVector128<T> src, byte count)
        where T : unmanaged
            => vgcpu.vrolx(src.State, count);

    /// <summary>
    /// Rotates source bits leftward
    /// </summary>
    /// <param name="src">The source bitvector</param>
    /// <param name="count">The rotation magnitude</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitVector256<T> rotl<T>(in BitVector256<T> src, byte count)
        where T : unmanaged
            => vgcpu.vrolx(src.State, count);
}
