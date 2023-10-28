//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Computes the bitwise complement z:= ~x of a bitvector x
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline), Not, Closures(Closure)]
    public static ScalarBits<T> not<T>(ScalarBits<T> x)
        where T : unmanaged
            => gmath.not(x.State);

    /// <summary>
    /// Computes the bitwise complement z:= ~x of a bitvector x
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static ScalarBits<N,T> not<N,T>(ScalarBits<N,T> x)
        where N : unmanaged,ITypeNat
        where T : unmanaged
            => gmath.not(x.State);

    /// <summary>
    /// Computes the bitwise complement z:= ~x of a bitvector x
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitVector128<T> not<T>(BitVector128<T> x)
        where T : unmanaged
            => vgcpu.vnot(x.State);

    /// <summary>
    /// Computes the bitwise complement z:= ~x of a bitvector x
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitVector256<T> not<T>(BitVector256<T> x)
        where T : unmanaged
            => vgcpu.vnot(x.State);
}
