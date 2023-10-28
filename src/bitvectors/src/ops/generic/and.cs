//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Computes the bitvector z := x & y from bitvectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline), And, Closures(Closure)]
    public static BitVector128<T> and<T>(BitVector128<T> x, BitVector128<T> y)
        where T : unmanaged
            => vgcpu.vand(x.State, y.State);

    /// <summary>
    /// Computes the bitvector z := x & y from bitvectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline), And, Closures(Closure)]
    public static BitVector256<T> and<T>(BitVector256<T> x, BitVector256<T> y)
        where T : unmanaged
            => vgcpu.vand(x.State, y.State);
}
