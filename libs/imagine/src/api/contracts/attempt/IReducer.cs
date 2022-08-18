//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a function that produces a 128-bit vector from a 256-bit vector
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IReducer256<T> : IFunc<Vector256<T>,Vector128<T>>
        where T : unmanaged
    {

    }
}