//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Computes the scalar product between two bitvectors
    /// </summary>
    /// <param name="x">The left bitvector</param>
    /// <param name="y">The right bitvector</param>
    [MethodImpl(Inline)]
    public static bit dot<T>(BitVector128<T> x, BitVector128<T> y)
        where T : unmanaged
            => parity(and(x,y));

    /// <summary>
    /// Computes the scalar product between two bitvectors
    /// </summary>
    /// <param name="x">The left bitvector</param>
    /// <param name="y">The right bitvector</param>
    [MethodImpl(Inline)]
    public static bit dot<T>(BitVector256<T> x, BitVector256<T> y)
        where T : unmanaged
            => parity(and(x,y));
}
