//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics;

    /// <summary>
    /// Characterizes a function that produces a vector predicated on a source value
    /// </summary>
    /// <typeparam name="W">The vector width</typeparam>
    /// <typeparam name="S">The source value type</typeparam>
    /// <typeparam name="V">The target vector type</typeparam>
    /// <typeparam name="T">The target vector component type</typeparam>
    [Free, SFx]
    public interface IFactory<W,S,V,T> : IFunc<S,V>
        where W : unmanaged, INativeSize<W>
        where T : unmanaged
        where V : struct
    {

    }

    /// <summary>
    /// Characterizes an operator that produces a 128-bit target vector predicated on a source value
    /// </summary>
    /// <typeparam name="S">The source value type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IFactory128<S,T> : IFactory<W128,S,Vector128<T>,T>, IFunc128<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes an operator that produces a 256-bit target vector predicated on a source value
    /// </summary>
    /// <typeparam name="S">The source value type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IFactory256<S,T> : IFactory<W256,S,Vector256<T>,T>, IFunc256<T>
        where T : unmanaged
    {

    }
}