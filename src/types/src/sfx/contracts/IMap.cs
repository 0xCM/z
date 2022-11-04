//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an operator that materializes a primal value from a string
    /// </summary>
    /// <typeparam name="T">The primal value type</typeparam>
    [Free, SFx]
    public interface ITextParserFunc<T> : IFunc<string,T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized transformation parameterized by operand source/target bit widths and source/target component types
    /// </summary>
    /// <typeparam name="W1">The bit-width type of the source operand</typeparam>
    /// <typeparam name="W2">The bit-width type of the target operand</typeparam>
    /// <typeparam name="V1">The source operand type</typeparam>
    /// <typeparam name="V2">The target operand type</typeparam>
    /// <typeparam name="T1">The source component type</typeparam>
    /// <typeparam name="T2">The target component type</typeparam>
    [Free, SFx]
    public interface IMap<W1,W2,V1,V2,T1,T2> : ISFxProjector<V1,V2>
        where W1 : unmanaged, ITypeWidth
        where W2 : unmanaged, ITypeWidth
        where V1 : struct
        where V2 : struct
        where T1 : unmanaged
        where T2 : unmanaged
    {

    }
}