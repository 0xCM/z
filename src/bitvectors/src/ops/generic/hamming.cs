//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Computes the Hamming distance between bitvectors
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static uint hamming<T>(BitVector128<T> x, BitVector128<T> y)
        where T : unmanaged
            => pop(xor(x,y));

    /// <summary>
    /// Computes the Hamming distance between bitvectors
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static uint hamming<T>(BitVector256<T> x, BitVector256<T> y)
        where T : unmanaged
            => pop(xor(x,y));
}
