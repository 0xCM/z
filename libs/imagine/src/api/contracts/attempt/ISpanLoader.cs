//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes an operation that accepts a source span and produces a derived target vector
    /// </summary>
    /// <typeparam name="W">The target vector width</typeparam>
    /// <typeparam name="S">The span source cell type</typeparam>
    /// <typeparam name="V">The target vector type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface ISpanLoader<S,V> : IFunc
        where S : unmanaged
        where V : struct
    {
        V Invoke(ReadOnlySpan<S> src, int offset);
    }

    [Free, SFx]
    public interface ISpanLoader128<S,T> : ISpanLoader<S,Vector128<T>>, IFunc128<T>
        where S : unmanaged
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface ISpanLoader256<S,T> : ISpanLoader<S,Vector256<T>>, IFunc256<T>
        where S : unmanaged
        where T : unmanaged
    {

    }
}