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
        /// Reads a partial value if there aren't a sufficient number of bytes to comprise a target value
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T Take<T>(this Span<byte> src)
            where T : struct
                => partial<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte TakeUInt8<T>(this ReadOnlySpan<T> src)
            where T : unmanaged
                => first(w8, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static sbyte TakeInt8<T>(this ReadOnlySpan<T> src)
            where T : unmanaged
                => first(w8i, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static short TakeInt16<T>(this ReadOnlySpan<T> src)
            where T : unmanaged
                => first(w16i, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int TakeInt32<T>(this ReadOnlySpan<T> src)
            where T : unmanaged
                => first(w32i, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static long TakeInt64<T>(this ReadOnlySpan<T> src)
            where T : unmanaged
                => first(w64i, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint TakeUInt24<T>(this ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var storage = 0u;
            ref var dst = ref @as<uint,byte>(storage);
            ref readonly var src8 = ref first(w8, src);
            seek(dst, 0) = skip(src8, 0);
            seek(dst, 1) = skip(src8, 1);
            seek(dst, 2) = skip(src8, 2);
            return storage;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint TakeUInt32<T>(this ReadOnlySpan<T> src)
            where T : unmanaged
                => first(w32, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong TakeUInt64<T>(this ReadOnlySpan<T> src)
            where T : unmanaged
                => first(w64, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte TakeUInt8<T>(this Span<T> src)
            where T : unmanaged
                => first(w8, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static sbyte TakeInt8<T>(this Span<T> src)
            where T : unmanaged
                => first(w8i, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static short TakeInt16<T>(this Span<T> src)
            where T : unmanaged
                => first(w16i, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort TakeUInt16<T>(this Span<T> src)
            where T : unmanaged
                => first(w16, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint TakeUInt24<T>(this Span<T> src)
            where T : unmanaged
                => src.ReadOnly().TakeUInt24();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int TakeInt32<T>(this Span<T> src)
            where T : unmanaged
                => first(w32i, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint TakeUInt32<T>(this Span<T> src)
            where T : unmanaged
                => first(w32, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static long TakeInt64<T>(this Span<T> src)
            where T : unmanaged
                => first(w64i, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong TakeUInt64<T>(this Span<T> src)
            where T : unmanaged
                => first(w64, src);
    }
}