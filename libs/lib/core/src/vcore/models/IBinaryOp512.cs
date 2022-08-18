//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    /// <summary>
    /// Characterizes a vectorized binary operator over 256-bit operands
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IBinaryOp512<T> : IBinaryOp<Vector512<T>>, IFunc512<T>
        where T : unmanaged
    {

    }
}