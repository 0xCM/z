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
        /// Presents a span of generic values as a span of signed 8-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<sbyte> AsInt8<T>(this Span<T> src)
            where T : struct
                => recover<T,sbyte>(src);

        /// <summary>
        /// Presents a span of generic values as a span of unsigned 8-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<byte> AsUInt8<T>(this Span<T> src)
            where T : struct
                => recover<T,byte>(src);

        /// <summary>
        /// Presents a span of generic values as a span of signed 16-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<short> AsInt16<T>(this Span<T> src)
            where T : struct
                => recover<T,short>(src);

        /// <summary>
        /// Presents a span of generic values as a span of unsigned 16-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<ushort> AsUInt16<T>(this Span<T> src)
            where T : struct
                => recover<T,ushort>(src);

        /// <summary>
        /// Presents a span of generic values as a span of signed 32-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<int> AsInt32<T>(this Span<T> src)
            where T : struct
                => recover<T,int>(src);

        /// <summary>
        /// Presents a span of generic values as a span of unsigned 32-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<uint> AsUInt32<T>(this Span<T> src)
            where T : struct
                => recover<T,uint>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 64-bit signed integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<long> AsInt64<T>(this Span<T> src)
            where T : struct
                => recover<T,long>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 64-bit unsigned integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<ulong> AsUInt64<T>(this Span<T> src)
            where T : struct
                => recover<T,ulong>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 32-bit floats
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<float> AsFloat32<T>(this Span<T> src)
            where T : struct
                => recover<T,float>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 64-bit floats
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<double> AsFloat64<T>(this Span<T> src)
            where T : struct
                => recover<T,double>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 64-bit floats
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<decimal> AsFloat128<T>(this Span<T> src)
            where T : struct
                => recover<T,decimal>(src);

        /// <summary>
        /// Presents a span of generic values as a span of bool
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<bool> AsBool<T>(this Span<T> src)
            where T : struct
                => recover<T,bool>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 64-bit floats
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<char> AsChar<T>(this Span<T> src)
            where T : struct
                => recover<T,char>(src);

        /// <summary>
        /// Presents a span of generic values as a span of chars
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline)]
        public static Span<E> AsEnum<T,E>(this Span<T> src, E e = default)
            where T : struct
            where E : unmanaged, Enum
                => recover<T,E>(src);

        /// <summary>
        /// Presents a readonly span of generic values as a span of signed bytes
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source span element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<sbyte> AsInt8<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,sbyte>(src);

        /// <summary>
        /// Presents a readonly span of generic values as a span of signed bytes
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source span element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<byte> AsUInt8<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,byte>(src);

        /// <summary>
        /// Presents a span of generic values as a span of signed 16-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<short> AsInt16<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,short>(src);

        /// <summary>
        /// Presents a span of generic values as a span of unsigned 16-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<ushort> AsUInt16<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,ushort>(src);

        /// <summary>
        /// Presents a span of generic values as a span of signed 32-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<int> AsInt32<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,int>(src);

        /// <summary>
        /// Presents a span of generic values as a span of unsigned 32-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<uint> AsUInt32<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,uint>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 64-bit signed integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<long> AsInt64<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,long>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 64-bit unsigned integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<ulong> AsUInt64<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,ulong>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 32-bit floats
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<float> AsFloat32<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,float>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 64-bit floats
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<double> AsFloat64<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,double>(src);

        /// <summary>
        /// Presents a span of generic values as a span of 64-bit floats
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<decimal> AsFloat128<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,decimal>(src);

        /// <summary>
        /// Presents a span of generic values as a span of bool
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<bool> AsBool<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,bool>(src);

        /// <summary>
        /// Presents a span of generic values as a span of chars
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<char> AsChar<T>(this ReadOnlySpan<T> src)
            where T : struct
                => recover<T,char>(src);
    }
}