//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines trait for a vectorized binary predicate that supports componentwise decomposition/evaluation
    /// </summary>
    /// <typeparam name="T">The component type</typeparam>
    [Free, SFx]
    public interface IBinaryPred<T> : IFunc
    {
        bit Invoke(T x, T y);
    }

    /// <summary>
    /// Characterizes a natural binary predicate over non-primal operands
    /// </summary>
    /// <typeparam name="W">The natural type</typeparam>
    /// <typeparam name="V">The non-primal operand type</typeparam>
    [Free, SFx]
    public interface IBinaryPred<W,V> : IFunc, IFunc<V,V,bit>
        where W : unmanaged, WType<W>
        where V : struct
    {

    }

    /// <summary>
    /// Characterizes a natural binary predicate over non-primal operands that support scalar application
    /// </summary>
    /// <typeparam name="W">The natural type</typeparam>
    /// <typeparam name="V">The non-primal type</typeparam>
    /// <typeparam name="T">The scalar type</typeparam>
    [Free, SFx]
    public interface IBinaryPred<W,V,T> : IBinaryPred<W,V>
        where W : unmanaged, WType<W>
        where V : struct
    {

    }

    /// <summary>
    /// Characterizes a vectorized binary predicate over 128-bit operands
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IBinaryPred128<T> : IBinaryPred<W128,Vector128<T>,T>, IFunc128<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized binary predicate over 256-bit operands
    /// </summary>
    /// <typeparam name="T">The component type</typeparam>
    [Free, SFx]
    public interface IBinaryPred256<T> : IBinaryPred<W256,Vector256<T>,T>, IFunc256<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized binary predicate over 128-bit operands that
    /// also supports componentwise decomposition/evaluation
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IBinaryPred128D<T> : IBinaryPred128<T>, IBinaryPred<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized binary predicate over 128-bit operands that
    /// also supports componentwise decomposition/evaluation
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IBinaryPred256D<T> : IBinaryPred256<T>, IBinaryPred<T>
        where T : unmanaged
    {

    }
}