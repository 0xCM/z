//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a vectorized binary operator over 256-bit operands that accepts an 8-bit immediate
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IBinaryImm8Op512<T> : IBinaryImm8Op<Vector512<T>>, IFunc512<T>
        where T : unmanaged
    {

    }
}