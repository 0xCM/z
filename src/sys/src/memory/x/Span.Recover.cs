//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        /// <summary>
        /// Presents a u8 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Recover<T>(this Span<byte> src)
            where T : struct
                => recover<byte,T>(src);

        /// <summary>
        /// Presents a u16 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Recover<T>(this Span<ushort> src)
            where T : struct
                => recover<ushort,T>(src);

        /// <summary>
        /// Presents a u32 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Recover<T>(this Span<uint> src)
            where T : struct
                => recover<uint,T>(src);

        /// <summary>
        /// Presents a u64 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Recover<T>(this Span<ulong> src)
            where T : struct
                => recover<ulong,T>(src);

        /// <summary>
        /// Presents a c16 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Recover<T>(this Span<char> src)
            where T : struct
                => recover<char,T>(src);

        /// <summary>
        /// Presents a u8 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> Recover<T>(this ReadOnlySpan<byte> src)
            where T : struct
                => recover<byte,T>(src);

        /// <summary>
        /// Presents a u16 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> Recover<T>(this ReadOnlySpan<ushort> src)
            where T : struct
                => recover<ushort,T>(src);

        /// <summary>
        /// Presents a u32 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> Recover<T>(this ReadOnlySpan<uint> src)
            where T : struct
                => recover<uint,T>(src);

        /// <summary>
        /// Presents a u64 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> Recover<T>(this ReadOnlySpan<ulong> src)
            where T : struct
                => recover<ulong,T>(src);

        /// <summary>
        /// Presents a c16 span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The Target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> Recover<T>(this ReadOnlySpan<char> src)
            where T : struct
                => recover<char,T>(src);

        /// <summary>
        /// Presents a span of one value-type as a span of another value-type
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> Recover<S,T>(this Span<S> src)
            where S : struct
            where T : struct
                => recover<S,T>(src);

        /// <summary>
        /// Presents a readonly span of one value-type as a span of another value-type
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> Recover<S,T>(this ReadOnlySpan<S> src)
            where S : struct
            where T : struct
                => recover<S,T>(src);
    }
}