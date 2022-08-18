//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public interface IBinaryImm8Op<A> : IFunc<A,A,byte,A>
    {

    }

    /// <summary>
    /// Characterizes a vectorized binary operator over 128-bit operands that accepts an 8-bit immediate
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IBinaryImm8Op128<T> : IBinaryImm8Op<Vector128<T>>, IFunc128<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized binary operator over 256-bit operands that accepts an 8-bit immediate
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IBinaryImm8Op256<T> : IBinaryImm8Op<Vector256<T>>, IFunc256<T>
        where T : unmanaged
    {

    }
}