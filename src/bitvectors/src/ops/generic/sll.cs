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
    [MethodImpl(Inline), Sll, Closures(Closure)]
    public static BitVector128<T> sll<T>(in BitVector128<T> x, byte count)
        where T : unmanaged
            => vgcpu.vsllx(x.State,count);

    /// <summary>
    /// Computes z := x >> s for a bitvector x and shift offset s
    /// </summary>
    /// <param name="x">The source bitvector</param>
    /// <param name="count">The shift amount</param>
    [MethodImpl(Inline), Sll, Closures(Closure)]
    public static BitVector256<T> sll<T>(in BitVector256<T> x, byte count)
        where T : unmanaged
            => vgcpu.vsllx(x.State,count);
}
