//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

/// <summary>
/// Defines a permutation over the integers [0, 1, ..., n - 1] where n is the permutation length
/// </summary>
[ApiHost,Free]
public partial class Permute
{
    const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline), Op]
    public static Vector128<byte> shuffles(NatPerm<N16> src)
        => vcpu.vload(w128, (byte)first(src.Terms));

    [MethodImpl(Inline), Op]
    public static Perm32 unsize(in NatPerm<N32,byte> spec)
        => new (vgcpu.vload(w256, spec.Terms.View));

    [MethodImpl(Inline), Op]
    public static Perm16 unsize(in NatPerm<N16,byte> spec)
        => new (vgcpu.vload(w128, spec.Terms.View));

    /// <summary>
    /// Creates a generic permutation by application of a sequence of transpositions to the identity permutation
    /// </summary>
    /// <param name="n">The permutation length</param>
    /// <param name="swaps">Pairs of permutation indices (i,j) to be transposed</param>
    /// <typeparam name="T">The integral type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Perm<T> build<T>(T n, params (T i, T j)[] swaps)
        where T : unmanaged
            => new (n, swaps);

    /// <summary>
    /// Creates a generic permutation by application of a sequence of transpositions to the identity permutation
    /// </summary>
    /// <param name="n">The permutation length</param>
    /// <param name="swaps">Pairs of permutation indices (i,j) to be transposed</param>
    /// <typeparam name="T">The integral type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Perm<T> build<T>(T n, params Swap<T>[] swaps)
        where T : unmanaged
            => new (n,swaps);

    /// <summary>
    /// Defines an identity permutation on n symbols
    /// </summary>
    /// <param name="n">The permutation length</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Perm<T> Identity<T>(T n)
        where T : unmanaged
            => new (gcalc.stream(default, gmath.dec(n)));

}
