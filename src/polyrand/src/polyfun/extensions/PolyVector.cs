//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines the matrix api surface
/// </summary>
[ApiHost]
public static class PolyVector
{
    const NumericKind Closure = AllNumeric;

    /// <summary>
    /// Creates a 128-bit vectorized emitter predicated an a specified source
    /// </summary>
    /// <param name="w">The vector bit width</param>
    /// <param name="src">The data source</param>
    /// <param name="t">A vector component type representative</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static VEmitter128<T> vemitter<T>(N128 w, ISource src)
        where T : unmanaged
            => new (src);

    /// <summary>
    /// Creates a 256-bit vectorized emitter predicated an a specified source
    /// </summary>
    /// <param name="w">The vector bit width</param>
    /// <param name="src">The data source</param>
    /// <param name="t">A vector component type representative</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static VEmitter256<T> vemitter<T>(N256 w, ISource src)
        where T : unmanaged
            => new (src);

    /// <summary>
    /// Creates a 256-bit vectorized emitter predicated an a specified source
    /// </summary>
    /// <param name="w">The vector bit width</param>
    /// <param name="src">The data source</param>
    /// <param name="t">A vector component type representative</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static VEmitter512<T> vemitter<T>(N512 w, ISource src)
        where T : unmanaged
            => new (src);

    /// <summary>
    /// Produces a blocked vector
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static RowVector256<T> VectorBlock<T>(this IPolyrand random, int len, Interval<T>? domain = null)
        where T : unmanaged
    {
        var dst = RowVectors.blockalloc<T>(len);
        if(domain != null)
            random.Fill(domain.Value, len, ref dst[0]);
        else
            random.Fill(len, ref dst[0]);
        return dst;
    }

    /// <summary>
    /// Produces a generic random vector over one domain and converts it to a vector over another
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="len">The vector length</param>
    /// <param name="domain">The domain over which random selection will occur</param>
    /// <param name="t">A target domain representative</param>
    /// <typeparam name="S">The source domain type</typeparam>
    /// <typeparam name="T">The target domain type</typeparam>
    [MethodImpl(Inline)]
    public static RowVector256<T> VectorBlock<S,T>(this IPolyrand random, int len, Interval<S>? domain = null)
        where S: unmanaged
        where T : unmanaged
            => random.VectorBlock(len,domain).Convert<T>();

    /// <summary>
    /// Allocates and populates a vector of natural length
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static Block256<N,T> VectorBlock<N,T>(this IPolyrand random, Interval<T> domain, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        var dst = RowVectors.blockalloc<N, T>();
        random.Fill(domain, ref dst);
        return dst;
    }

    /// <summary>
    /// Allocates and populates a vector of natural length
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <param name="n">The natural vector length</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="S">The sample domain type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static Block256<N,T> VectorBlock<N,S,T>(this IPolyrand random, Interval<S> domain, N n = default)
        where T : unmanaged
        where S: unmanaged
        where N : unmanaged, ITypeNat
            => random.VectorBlock<N,S>(domain).Convert<T>();

    /// <summary>
    /// Allocates and populates a vector of natural length
    /// </summary>
    /// <param name="random">The random source</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static Block256<N,T> VectorBlock<N,T>(this IPolyrand random,  N n = default, T t = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        var dst = RowVectors.blockalloc<N,T>();
        random.Fill(ref dst);
        return dst;
    }

    /// <summary>
    /// Populates a vector of natural length with random values from the source
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <param name="vector">The vector to populate</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static void Fill<N,T>(this IPolySource random, Interval<T> domain, ref Block256<N,T> vector, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
            => random.Fill<T>(domain, Typed.nat32i<N>(), ref vector.Unsized[0]);

    /// <summary>
    /// Populates a vector of natural length with random values from the source
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <param name="vector">The vector to populate</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static void Fill<N,T>(this IPolySource random, ref Block256<N,T> vector, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
            => random.Fill<T>(Typed.nat32i<N>(), ref vector.Unsized[0]);

    /// <summary>
    /// Produces a generic vector
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static RowVector<T> RowVector<T>(this IPolySource random, int len, Interval<T>? domain = null)
        where T : unmanaged
    {
        var dst = Z0.RowVectors.alloc<T>(len);
        if(domain != null)
            random.Fill(domain.Value, len, ref dst[0]);
        else
            random.Fill(len, ref dst[0]);
        return dst;
    }

    /// <summary>
    /// Produces a natural vector
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static RowVector<N,T> RowVector<N,T>(this IPolySource random, Interval<T> domain, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        var dst = Z0.RowVectors.alloc<N,T>();
        random.Fill(domain, ref dst);
        return dst;
    }

    /// <summary>
    /// Produces a natural vector
    /// </summary>
    /// <param name="random">The random source</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static RowVector<N,T> RowVector<N,T>(this IPolySource random, T min, T max,  N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        var dst = Z0.RowVectors.alloc<N,T>();
        random.Fill(Intervals.closed(min,max), ref dst);
        return dst;
    }

    /// <summary>
    /// Allocates and populates a vector of natural length
    /// </summary>
    /// <param name="random">The random source</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static RowVector<N,T> RowVector<N,T>(this IPolySource random, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        var dst = Z0.RowVectors.alloc<N,T>();
        random.Fill(ref dst);
        return dst;
    }

    /// <summary>
    /// Produces a natural vector over one domain and converts it to another
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <param name="n">The natural vector length</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="S">The sample domain type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static RowVector<N,T> RowVector<N,S,T>(this IPolySource random, Interval<S> domain, N n = default)
        where T : unmanaged
        where S : unmanaged
        where N : unmanaged, ITypeNat
            => random.RowVector<N,S>(domain).Convert<T>();

    /// <summary>
    /// Produces a natural vector over one domain and converts it to another
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="len">The vector length</param>
    /// <param name="domain">The domain over which random selection will occur</param>
    /// <param name="rep">A target domain representative</param>
    /// <typeparam name="S">The source domain type</typeparam>
    /// <typeparam name="T">The target domain type</typeparam>
    [MethodImpl(Inline)]
    public static RowVector<T> RowVector<S,T>(this IPolySource random, int len, Interval<S>? domain = null)
        where S: unmanaged
        where T : unmanaged
            => random.RowVector<S>(len,domain).Convert<T>();

    /// <summary>
    /// Populates a vector of natural length with random values from the source
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <param name="vector">The vector to populate</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static void Fill<N,T>(this IPolySource random, Interval<T> domain, ref RowVector<N,T> vector, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
            => random.Fill<T>(domain, Typed.nat32i<N>(), ref vector.Storage[0]);

    /// <summary>
    /// Populates a vector of natural length with random values from the source
    /// </summary>
    /// <param name="random">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <param name="vector">The vector to populate</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static void Fill<N,T>(this IPolySource random, ref RowVector<N,T> vector, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
            => random.Fill<T>(Typed.nat32i<N>(), ref vector.Storage[0]);

    /// <summary>
    /// Produces a 128-bit cpu vector over random T-cells
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The width selector</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static Vector128<T> CpuVector<T>(this ISource src, N128 w)
        where T : unmanaged
            => src.SpanBlocks<T>(w).LoadVector();

    /// <summary>
    /// Produces a random 256-bit cpu vector
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static Vector256<T> CpuVector<T>(this ISource src, N256 w)
        where T : unmanaged
            => src.SpanBlocks<T>(w).LoadVector();

    /// <summary>
    /// Produces a random 256-bit cpu vector
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static Vector512<T> CpuVector<T>(this ISource src, N512 w)
        where T : unmanaged
            => src.SpanBlocks<T>(w).LoadVector();

    /// <summary>
    /// Produces a 128-bit cpu vector over random T-cells
    /// </summary>
    /// <param name="source">The data source</param>
    /// <param name="w">The width selector</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static Vector128<T> CpuVector<T>(this ISource source, Vec128Kind<T> k)
        where T : unmanaged
            => source.SpanBlocks<T>(w128).LoadVector();

    /// <summary>
    /// Produces a random 256-bit cpu vector
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static Vector256<T> CpuVector<T>(this ISource src, Vec256Kind<T> k)
        where T : unmanaged
            => src.SpanBlocks<T>(w256).LoadVector();

    /// <summary>
    /// Produces a random 256-bit cpu vector
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static Vector512<T> CpuVector<T>(this ISource src, Vec512Kind<T> k)
        where T : unmanaged
            => src.SpanBlocks<T>(w512).LoadVector();

    /// <summary>
    /// Produces a stream of 128-bit cpu vectors over random T-cells
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The width selector</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static IEnumerable<Vector128<T>> CpuVectors<T>(this ISource src, W128 w)
        where T : unmanaged
    {
        while(true)
            yield return src.CpuVector<T>(w);
    }

    /// <summary>
    /// Produces a stream of 256-bit cpu vectors over random T-cells
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The width selector</param>
    /// <typeparam name="T">The vector component type</typeparam>
    public static IEnumerable<Vector256<T>> CpuVectors<T>(this ISource src, W256 w)
        where T : unmanaged
    {
        while(true)
            yield return src.CpuVector<T>(w);
    }

    /// <summary>
    /// Produces a 128-bit cpu vector over random T-cells, each bound to a specified common domain
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <param name="domain">An interval to which component values are constrained</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static Vector128<T> CpuVector<T>(this IBoundSource src, W128 w, Interval<T> domain)
        where T : unmanaged
            => src.SpanBlocks<T>(w,domain,1).LoadVector();

    /// <summary>
    /// Produces a 256-bit cpu vector over random T-cells, each bound to a specified common domain
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <param name="domain">An interval to which component values are constrained</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static Vector256<T> CpuVector<T>(this IBoundSource src, W256 w, Interval<T> domain)
        where T : unmanaged
            => src.SpanBlocks<T>(w, domain, 1).LoadVector();

    /// <summary>
    /// Produces a random 512-bit cpu vector
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <param name="domain">An interval to which vector component values are constrained</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static Vector512<T> CpuVector<T>(this IBoundSource src, W512 w, Interval<T> domain)
        where T : unmanaged
            => src.CpuVector(w,domain,null);

    /// <summary>
    /// Produces a stream of 128-bit cpu vectors over random T-cells, each bound to a specified common domain
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <param name="domain">An interval to which component values are constrained</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static IEnumerable<Vector128<T>> CpuVectors<T>(this IBoundSource src, W128 w, Interval<T> domain)
        where T : unmanaged
    {
        while(true)
            yield return src.CpuVector<T>(w, domain);
    }

    /// <summary>
    /// Produces a random 128-bit cpu vector
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <param name="domain">An interval to which component values are constrained</param>
    /// <param name="filter">A domain refinement filter</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static Vector128<T> CpuVector<T>(this IBoundSource src, W128 w, Interval<T> domain, Func<T,bool> filter)
        where T : unmanaged
            => src.SpanBlocks<T>(w, domain, 1, filter).LoadVector();

    /// <summary>
    /// Produces a stream of 256-bit cpu vectors over random T-cells, each bound to a specified common domain
    /// </summary>
    /// <param name="source">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <param name="domain">An interval to which component values are constrained</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static IEnumerable<Vector256<T>> CpuVectors<T>(this IBoundSource source, W256 w, Interval<T> domain)
        where T : unmanaged
    {
        while(true)
            yield return source.CpuVector<T>(w, domain);
    }

    /// <summary>
    /// Produces a random 256-bit cpu vector
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <param name="domain">An interval to which component values are constrained</param>
    /// <param name="filter">A domain refinement filter</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static Vector256<T> CpuVector<T>(this IBoundSource src, W256 w, Interval<T> domain, Func<T,bool> filter)
        where T : unmanaged
            => src.SpanBlocks<T>(w, domain, 1, filter).LoadVector();

    /// <summary>
    /// Produces a random 512-bit cpu vector
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="w">The vector width selector</param>
    /// <param name="domain">An interval to which component values are constrained</param>
    /// <param name="filter">A domain refinement filter</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static Vector512<T> CpuVector<T>(this IBoundSource src, W512 w, Interval<T> domain, Func<T,bool> filter)
        where T : unmanaged
            => src.SpanBlocks(w, domain, 1, filter).LoadVector();
}
