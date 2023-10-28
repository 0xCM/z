//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitVector128<T> negate<T>(BitVector128<T> x)
        where T : unmanaged
            => vgcpu.vnegate(x.State);

    /// <summary>
    /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitVector256<T> negate<T>(BitVector256<T> x)
        where T : unmanaged
            => vgcpu.vnegate(x.State);
}
