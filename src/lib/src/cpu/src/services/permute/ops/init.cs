//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a permutation over the integers [0, 1, ..., n - 1] where n is the permutation length
    /// </summary>
    partial struct Perm
    {
         /// <summary>
        /// Defines an untyped permutation determined by values in a source span
        /// </summary>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op]
        public static Perm Init(ReadOnlySpan<int> src)
            => new Perm(src.ToArray());

        /// <summary>
        /// Creates a permutation from the elements in a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The integral type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> init<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => new Perm<T>(src.ToArray());

        /// <summary>
        /// Initializes permutation with the identity followed by a sequence of transpostions
        /// </summary>
        /// <param name="n">The length of the permutation</param>
        /// <param name="swaps">The transpositions applied to the identity</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> init<T>(T n, (T i, T j)[] swaps)
            where T : unmanaged
                => new Perm<T>(n, swaps);

        /// <summary>
        ///  Initializes permutation with the identity followed by a sequence of transpostions
        /// </summary>
        /// <param name="n">The length of the permutation</param>
        /// <param name="swaps">The transpositions applied to the identity</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> init<T>(T n, Swap<T>[] swaps)
            where T : unmanaged
                => new Perm<T>(n, swaps);

        /// <summary>
        /// Creates a permutation from the elements in a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The integral type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> init<T>(Span<T> src)
            where T : unmanaged
                => new Perm<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> init<T>(IEnumerable<T> src)
            where T : unmanaged
                => new Perm<T>(src);

        /// <summary>
        /// Creates a permutation from the elements in a parameter array
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The integral type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> init<T>(params T[] src)
            where T : unmanaged
                => new Perm<T>(src);
    }
}