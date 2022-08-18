//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a parametric value projector
    /// </summary>
    /// <param name="src">The source value</param>
    /// <typeparam name="S">The operand type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    [Free]
    public delegate ref T ValueMap<S,T>(in S src)
        where S : struct
        where T : struct;

    /// <summary>
    /// Characterizes a value predicate f:T -> bool
    /// </summary>
    /// <param name="src">The source value</param>
    /// <typeparam name="S">The operand type</typeparam>
    [Free]
    public delegate bool ValuePredicate<T>(in T src)
        where T : struct;

    [Free]
    public delegate ref T RefMap<S,T>(in S src, ref T dst);
}