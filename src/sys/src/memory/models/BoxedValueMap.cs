//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a function that projects one structural type onto another
    /// </summary>
    /// <param name="src">The source value</param>
    [Free]
    public delegate ValueType BoxedValueMap(ValueType src);

    /// <summary>
    /// Characterizes a result-parametric value projector
    /// </summary>
    /// <param name="src">The source value</param>
    /// <typeparam name="T">The target type</typeparam>
    [Free]
    public delegate ref T BoxedValueMap<T>(ValueType src)
        where T : struct;
}