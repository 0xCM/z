//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Computes z := x >> s for a bitvector x and shift offset s
    /// </summary>
    /// <param name="x">The source bitvector</param>
    /// <param name="count">The shift amount</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> srl<T>(in BitVector128<T> x, byte count)
        where T : unmanaged
            => vgcpu.vsrlx(x.State, count);

    /// <summary>
    /// Computes z := x >> s for a bitvector x and shift offset s
    /// </summary>
    /// <param name="x">The source bitvector</param>
    /// <param name="count">The shift amount</param>
    [MethodImpl(Inline)]
    public static BitVector256<T> srl<T>(in BitVector256<T> x, byte count)
        where T : unmanaged
            => vgcpu.vsrlx(x.State, count);
}
