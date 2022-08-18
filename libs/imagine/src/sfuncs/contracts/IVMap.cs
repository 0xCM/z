//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a 128-bit vectorized transformation parameterized by source/target component types
    /// </summary>
    /// <typeparam name="S">The source component type</typeparam>
    /// <typeparam name="T">The target component type</typeparam>
    [Free, SFx]
    public interface IVMap128<S,T> : IMap<W128,W128,Vector128<S>,Vector128<T>,S,T>
        where S : unmanaged
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IVMap128<H,S,T> : IVMap128<S,T>
        where S : unmanaged
        where T : unmanaged
        where H : IVMap128<H,S,T>
    {

    }

    /// <summary>
    /// Characterizes a 256-bit vectorized transformation parameterized by source/target component types
    /// </summary>
    /// <typeparam name="S">The source component type</typeparam>
    /// <typeparam name="T">The target component type</typeparam>
    [Free, SFx]
    public interface IVMap256<S,T> : IMap<W256,W256,Vector256<S>,Vector256<T>,S,T>
        where S : unmanaged
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IVMap256<H,S,T> : IVMap256<S,T>
        where S : unmanaged
        where T : unmanaged
        where H : IVMap256<H,S,T>
    {

    }
}