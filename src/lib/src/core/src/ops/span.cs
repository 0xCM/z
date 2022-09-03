//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    //using System.Linq;

    using static System.Runtime.InteropServices.MemoryMarshal;

    partial struct core
    {
        /// <summary>
        /// Allocates storage for a specified number of T-cells
        /// </summary>
        /// <param name="count">The cell allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> span<T>(int count)
            => sys.span<T>(count);

        /// <summary>
        /// Allocates storage for a specified number of T-cells
        /// </summary>
        /// <param name="count">The cell allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> span<T>(uint count)
            => sys.span<T>(count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> span<T>(IEnumerable<T> src)
            => sys.span(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> span<T>(T[] src)
            => src;

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> span(string src)
            => src;
 
        /// <summary>
        /// Creates a T-span from a single S-reference
        /// </summary>
        /// <param name="src">A reference to the source cell</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> span<S,T>(ref S src)
            where T : struct
            where S : struct
                => Cast<S,T>(CreateSpan(ref src, 1));
    }
}