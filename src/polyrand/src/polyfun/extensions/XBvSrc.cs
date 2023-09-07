//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public static class XBvSrc
{
    /// <summary>
    /// Produces a 4-bit primal bitvector predicated on a random source
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    [MethodImpl(Inline)]
    public static BitVector4 BitVector(this IBoundSource source, N4 n)
        => source.Next<byte>(0,17);

    /// <summary>
    /// Produces an 8-bit primal bitvector predicated on a random source
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    [MethodImpl(Inline)]
    public static BitVector8 BitVector(this ISource source, N8 n)
        => source.Next<byte>();

    /// <summary>
    /// Produces an 8-bit primal bitvector of a specified maximal effective width
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    /// <param name="wmax">The effective width</param>
    [MethodImpl(Inline)]
    public static BitVector8 BitVector(this ISource source, N8 n, byte wmax)
    {
        var v = source.Next<byte>();
        var clamp = (byte)(nat8u(n) - math.min(nat8u(n), wmax));
        return (v >>= clamp);
    }

    /// <summary>
    /// Produces a 16-bit primal bitvector
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    [MethodImpl(Inline)]
    public static BitVector16 BitVector(this ISource source, N16 n)
        => source.Next<ushort>();

    /// <summary>
    /// Produces a 16-bit primal bitvector of a specified maximal effective width
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    /// <param name="wmax">The effected width</param>
    [MethodImpl(Inline)]
    public static BitVector16 BitVector(this ISource source, N16 n, byte wmax)
    {
        var v = source.Next<ushort>();
        var clamp = (byte)(nat8u(n) - math.min(nat8u(n), wmax));
        return (v >>= clamp);
    }

    /// <summary>
    /// Produces a 32-bit primal bitvector
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    [MethodImpl(Inline)]
    public static BitVector32 BitVector(this ISource random, N32 n)
        => random.Next<uint>();

    /// <summary>
    /// Produces a 32-bit primal bitvector of a specified maximal effective width
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    /// <param name="wmax">The maximum effected width</param>
    [MethodImpl(Inline)]
    public static BitVector32 BitVector(this ISource random, N32 n, byte wmax)
    {
        var v = random.Next<uint>();
        var clamp = (byte)(nat8u(n) - math.min(nat8u(n), wmax));
        return (v >>= clamp);
    }

    /// <summary>
    /// Produces a 64-bit primal bitvector
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    [MethodImpl(Inline)]
    public static BitVector64 BitVector(this ISource source, N64 n)
        => source.Next<ulong>();

    /// <summary>
    /// Produces a 64-bit primal bitvector of maximal effective width
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    /// <param name="wmax">The maximum effected width</param>
    [MethodImpl(Inline)]
    public static BitVector64 BitVector(this ISource source, N64 n, byte wmax)
    {
        var v = source.Next<ulong>();
        var clamp = (byte)(nat8u(n) - math.min(nat8u(n), wmax));
        return (v >>= clamp);
    }

    /// <summary>
    /// Produces a 128-bit primal bitvector
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="n">The primal bitvector selector</param>
    [MethodImpl(Inline)]
    public static BitVector128<ulong> BitVector(this ISource source, N128 n)
        => source.CpuVector<ulong>(n);

    /// <summary>
    /// Produces a generic bitvector
    /// </summary>
    /// <param name="source">The random source</param>
    /// <typeparam name="T">The underlying primal type</typeparam>
    [MethodImpl(Inline)]
    public static ScalarBits<T> ScalarBits<T>(this ISource source)
        where T : unmanaged
            => source.Next<T>();

    /// <summary>
    /// Produces a generic bitvector of a specified maximum effective width
    /// </summary>
    /// <param name="source">The random source</param>
    /// <typeparam name="T">The underlying primal type</typeparam>
    [MethodImpl(Inline)]
    public static ScalarBits<T> ScalarBits<T>(this ISource source, int wmax)
        where T : unmanaged
    {
        var v = source.Next<T>();
        var clamp = width<T>() - math.min(width<T>(), wmax);
        return gmath.srl(v,(byte)clamp);
    }

    /// <summary>
    /// Produces a natural bitvector
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="n">The bit width selector</param>
    /// <typeparam name="N">The bit width type</typeparam>
    /// <typeparam name="T">The underlying primal type</typeparam>
    [MethodImpl(Inline)]
    public static ScalarBits<N,T> ScalarBits<N,T>(this IBoundSource source, N n = default, T t = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        var v = source.Next<T>();
        var clamp = (byte)(width<T>() - math.min(width<T>(), nat32u(n)));
        return gmath.srl(v,clamp);
    }

    [MethodImpl(Inline)]
    public static BitVector128<T> BitVector<T>(this ISource source, N128 w)
        where T : unmanaged
            => source.CpuVector<T>(w128);
}
