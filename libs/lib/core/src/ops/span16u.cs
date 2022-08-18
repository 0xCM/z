//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Creates a u16 span from a T-cell reference
        /// </summary>
        /// <param name="src">The reference cell</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<ushort> span16u<T>(in T src)
            where T : struct
                => recover<ushort>(bytes(src));

        /// <summary>
        /// Creates a u16 span from a T-span
        /// </summary>
        /// <param name="src">The reference cell</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u<T>(Span<T> src)
            => recover<T,ushort>(src);

        /// <summary>
        /// Creates a u16 span from a T-span
        /// </summary>
        /// <param name="src">The reference cell</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ushort> span16u<T>(ReadOnlySpan<T> src)
            => recover<T,ushort>(src);
    }
}