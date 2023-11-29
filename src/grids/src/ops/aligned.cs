//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct grids
{            
    /// <summary>
    /// Determines whether grid storage is N-bit aligned
    /// </summary>
    /// <param name="src">The source specifier</param>
    /// <param name="w">A width-type representative</param>
    /// <typeparam name="N">The bit type</typeparam>
    [MethodImpl(Inline)]
    public static bool aligned<N>(in GridMetrics src, N n = default)
        where N : unmanaged, ITypeNat
            => (ulong)src.StoreSize % TypeNats.value(n) == 0;

    /// <summary>
    /// Determines whether grid storage is data width-aligned
    /// </summary>
    /// <param name="src">The source specifier</param>
    /// <param name="w">A width-type representative</param>
    [MethodImpl(Inline), Op]
    public static bool aligned(in GridMetrics src, DataWidth w)
        => src.StoreSize % (uint)w == 0;

    /// <summary>
    /// Determines whether grid storage is aligned with that of a specified numeric kind
    /// </summary>
    /// <param name="src">The source specifier</param>
    /// <param name="w">A width-type representative</param>
    /// <typeparam name="W">The bit-width type</typeparam>
    [MethodImpl(Inline), Op]
    public static bool aligned(in GridMetrics src, NumericKind k)
        => src.StoreSize % k.Width() == 0;
}