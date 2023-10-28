//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Computes the material implication z := x | ~y for bitvectors x and y
    /// </summary>
    /// <param name="x">The left bitvector</param>
    /// <param name="y">The right bitvector</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> impl<T>(BitVector128<T> x, BitVector128<T> y)
        where T : unmanaged
            => vgcpu.vimpl(x.State, y.State);

    /// <summary>
    /// Computes the material implication z := x | ~y for bitvectors x and y
    /// </summary>
    /// <param name="x">The left bitvector</param>
    /// <param name="y">The right bitvector</param>
    [MethodImpl(Inline)]
    public static BitVector256<T> impl<T>(BitVector256<T> x, BitVector256<T> y)
        where T : unmanaged
            => vgcpu.vimpl(x.State, y.State);            
}
