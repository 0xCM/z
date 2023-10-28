//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Computes the bitvector z := x | y from bitvectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static ScalarBits<T> or<T>(ScalarBits<T> x, ScalarBits<T> y)
        where T : unmanaged
            => gmath.or(x.State,y.State);

    /// <summary>
    /// Computes the bitvector z := x ^ y from bitvectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static ScalarBits<N,T> or<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
        where T : unmanaged
        where N : unmanaged, ITypeNat
            => gmath.or(x.State, y.State);

    /// <summary>
    /// Computes the bitvector z := x ^ y from bitvectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitVector128<T> or<T>(in BitVector128<T> x, in BitVector128<T> y)
        where T : unmanaged
            => vgcpu.vor(x.State,y.State);

    /// <summary>
    /// Computes the bitvector z := x ^ y from bitvectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitVector256<T> or<T>(in BitVector256<T> x, in BitVector256<T> y)
        where T : unmanaged
            => vgcpu.vor(x.State, y.State);
}
