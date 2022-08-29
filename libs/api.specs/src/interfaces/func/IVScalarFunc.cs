//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Defines trait for a vectorized unary scalar function that supports componentwise decomposition/evaluation
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IVUnaryScalarFunc<T,K> : IFunc
        where T : unmanaged
        where K : unmanaged
    {
        K Invoke(T a);
    }

    /// <summary>
    /// Defines trait for a vectorized binary scalar function that supports componentwise decomposition/evaluation
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IVBinaryScalarFunc<T,K> : IFunc
        where T : unmanaged
        where K : unmanaged
    {
        K Invoke(T a, T b);
    }

    /// <summary>
    /// Defines trait for a vectorized binary scalar function that supports componentwise decomposition/evaluation
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IVTernaryScalarFunc<T,K> : IFunc
        where T : unmanaged
        where K : unmanaged
    {
        K Invoke(T a, T b, T c);
    }

    /// <summary>
    /// Characterizes a unary function that accepts a vector argument and returns a scalar value
    /// </summary>
    /// <typeparam name="W">The bit width type</typeparam>
    /// <typeparam name="V">The vector type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface IVScalarFunc<W,V,T,K> : IFunc<V,K>
        where W : unmanaged, WType<W>
        where V : struct
        where T : unmanaged
        where K : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a binary function that accepts two vector arguments and returns a scalar value
    /// </summary>
    /// <typeparam name="W1">The bit width type of the first vector</typeparam>
    /// <typeparam name="W2">The bit width type of the second vector</typeparam>
    /// <typeparam name="V1">The type of the first vector</typeparam>
    /// <typeparam name="V2">The type of the second vector</typeparam>
    /// <typeparam name="T1">The component type of the first vector</typeparam>
    /// <typeparam name="T2">The component type of the second vector</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface IVScalarFunc<W1,W2,V1,V2,T1,T2,K> : IFunc<V1,V2,K>
        where W1 : unmanaged, ITypeWidth
        where W2 : unmanaged, ITypeWidth
        where V1 : struct
        where V2 : struct
        where T1 : unmanaged
        where T2 : unmanaged
        where K : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a ternary function that accepts three vector arguments and returns a scalar value
    /// </summary>
    /// <typeparam name="W1">The bit width type of the first vector</typeparam>
    /// <typeparam name="W2">The bit width type of the second vector</typeparam>
    /// <typeparam name="W3">The bit width type of the second vector</typeparam>
    /// <typeparam name="V1">The type of the first vector</typeparam>
    /// <typeparam name="V2">The type of the second vector</typeparam>
    /// <typeparam name="V3">The type of the third vector</typeparam>
    /// <typeparam name="T1">The component type of the first vector</typeparam>
    /// <typeparam name="T2">The component type of the second vector</typeparam>
    /// <typeparam name="T3">The component type of the third vector</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface IVScalarFunc<W1,W2,W3,V1,V2,V3,T1,T2,T3,K> : IFunc<V1,V2,V3,K>
        where W1 : unmanaged, ITypeWidth
        where W2 : unmanaged, ITypeWidth
        where W3 : unmanaged, ITypeWidth
        where V1 : struct
        where V2 : struct
        where T1 : unmanaged
        where T2 : unmanaged
        where K : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a unary function that accepts a 128-bit vector argument and returns a scalar value
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface IVUnaryScalarFunc128<T,K> : IVScalarFunc<W128,Vector128<T>,T,K>, IFunc128<T>
        where T : unmanaged
        where K : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a binary function that accepts homogenous 128-bit vector arguments and returns a scalar value
    /// that supports scalar decomposition
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface ISVBinaryScalar128D<T,K> : IVScalarFunc<W128, W128, Vector128<T>,Vector128<T>,T,T,K>, IVBinaryScalarFunc<T,K>, IFunc128<T>
        where T : unmanaged
        where K : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a ternary function that accepts homogenous 128-bit vector arguments and returns a scalar value
    /// that supports scalar decomposition
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface ISVTernaryScalar128D<T,K> : IVScalarFunc<W128, W128, W128, Vector128<T>, Vector128<T>, Vector128<T>, T,T,T,K>, IVTernaryScalarFunc<T,K>, IFunc128<T>
        where K : unmanaged
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a unary function that accepts a 256-bit vector argument and returns a scalar value
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface ISVUnaryScalarFunc256<T,K> : IVScalarFunc<W256,Vector256<T>,T,K>, IFunc256<T>
        where K : unmanaged
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a unary function that accepts a 256-bit vector argument and returns a scalar value
    /// that supports scalar decomposition
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface ISVUnaryScalarFunc256D<T,K> : IVScalarFunc<W256,Vector256<T>,T,K>, IVUnaryScalarFunc<T,K>, IFunc256<T>
        where K : unmanaged
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a binary function that accepts homogenous 256-bit vector arguments and returns a scalar value
    /// that supports scalar decomposition
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface ISVBinaryScalarFunc256D<T,K> : IVScalarFunc<W256, W256, Vector256<T>,Vector256<T>, T,T,K>, IVBinaryScalarFunc<T,K>, IFunc256<T>
        where T : unmanaged
        where K : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a ternary function that accepts homogenous 256-bit vector arguments that returns a scalar value
    /// that supports scalar decomposition
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface ISVTernaryScalarFunc256D<T,K> : IVScalarFunc<W256, W256, W256, Vector256<T>, Vector256<T>, Vector256<T>, T,T,T,K>, IVTernaryScalarFunc<T,K>, IFunc256<T>
        where T : unmanaged
        where K : unmanaged
    {

    }
}