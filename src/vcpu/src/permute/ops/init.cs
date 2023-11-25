//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class Permute
{
    /// <summary>
    /// Creates a permutation from the elements in a readonly span
    /// </summary>
    /// <param name="src">The source span</param>
    /// <typeparam name="T">The integral type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Perm<T> init<T>(ReadOnlySpan<T> src)
        where T : unmanaged
            => new (src.ToArray());

    /// <summary>
    /// Initializes permutation with the identity followed by a sequence of transpostions
    /// </summary>
    /// <param name="n">The length of the permutation</param>
    /// <param name="swaps">The transpositions applied to the identity</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Perm<T> init<T>(T n, (T i, T j)[] swaps)
        where T : unmanaged
            => new (n, swaps);

    /// <summary>
    ///  Initializes permutation with the identity followed by a sequence of transpostions
    /// </summary>
    /// <param name="n">The length of the permutation</param>
    /// <param name="swaps">The transpositions applied to the identity</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Perm<T> init<T>(T n, Swap<T>[] swaps)
        where T : unmanaged
            => new (n, swaps);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Perm<T> init<T>(IEnumerable<T> src)
        where T : unmanaged
            => new (src);

    /// <summary>
    /// Creates a permutation from the elements in a parameter array
    /// </summary>
    /// <param name="src">The source array</param>
    /// <typeparam name="T">The integral type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Perm<T> init<T>(params T[] src)
        where T : unmanaged
            => new (src);
}
