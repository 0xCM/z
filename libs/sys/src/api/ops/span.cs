//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class sys
    {
        /// <summary>
        /// Allocates storage for a specified number of T-cells
        /// </summary>
        /// <param name="count">The cell allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static Span<T> span<T>(int count)
            => new T[count];

        /// <summary>
        /// Allocates storage for a specified number of T-cells
        /// </summary>
        /// <param name="count">The cell allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static Span<T> span<T>(uint count)
            => new T[count];

        /// <summary>
        /// Allocates storage for a specified number of T-cells
        /// </summary>
        /// <param name="count">The cell allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static Span<T> span<T>(long count)
            => new T[count];

        /// <summary>
        /// Allocates storage for a specified number of T-cells
        /// </summary>
        /// <param name="count">The cell allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static Span<T> span<T>(ulong count)
            => new T[count];

        [MethodImpl(Options), Op, Closures(Closure)]
        public static Span<T> span<T>(IEnumerable<T> src)
            => src.ToArray();
    }
}