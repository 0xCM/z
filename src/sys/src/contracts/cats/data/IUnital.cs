//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Advertises a distinguished value One:T such that for every t:T, One*t = t*One = t
    /// for binary operator * over T
    /// </summary>
    /// <typeparam name="T">The unital value type</typeparam>
    [Free]
    public interface IUnital<T>
    {
        T One {get;}
    }

    /// <summary>
    /// Characterizes a structure with unit
    /// </summary>
    /// <typeparam name="S">The unital value type</typeparam>
    [Free]
    public interface IUnital<F,T> : IUnital<F>
        where F : IUnital<F,T>, new()
    {

    }
}