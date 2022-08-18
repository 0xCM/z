//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Computs min(x.Length,y.Length)
        /// </summary>
        /// <param name="x">The first span</param>
        /// <param name="y">The second span</param>
        /// <typeparam name="S">The first span cell type</typeparam>
        /// <typeparam name="T">The second span cell type</typeparam>
        [MethodImpl(Inline)]
        public static int length<S,T>(ReadOnlySpan<S> x, ReadOnlySpan<T> y)
            => min(x.Length, y.Length);

        /// <summary>
        /// Computs min(x.Length,y.Length)
        /// </summary>
        /// <param name="x">The first span</param>
        /// <param name="y">The second span</param>
        /// <typeparam name="S">The first span cell type</typeparam>
        /// <typeparam name="T">The second span cell type</typeparam>
        [MethodImpl(Inline)]
        public static int length<S,T>(ReadOnlySpan<S> x, Span<T> y)
            => min(x.Length, y.Length);

        /// <summary>
        /// Computs min(x.Length,y.Length)
        /// </summary>
        /// <param name="x">The first span</param>
        /// <param name="y">The second span</param>
        /// <typeparam name="S">The first span cell type</typeparam>
        /// <typeparam name="T">The second span cell type</typeparam>
        [MethodImpl(Inline)]
        public static int length<S,T>(Span<S> x, ReadOnlySpan<T> y)
            => min(x.Length, y.Length);

        /// <summary>
        /// Computs min(x.Length,y.Length)
        /// </summary>
        /// <param name="x">The first span</param>
        /// <param name="y">The second span</param>
        /// <typeparam name="S">The first span cell type</typeparam>
        /// <typeparam name="T">The second span cell type</typeparam>
        [MethodImpl(Inline)]
        public static int length<S,T>(Span<S> x, Span<T> y)
            => min(x.Length, y.Length);
    }
}