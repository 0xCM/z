//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    unsafe partial  class Bytes
    {
        /// <summary>
        /// Returns a sequence of 8-bit values selected from an 8-bit domain
        /// </summary>
        /// <param name="i0">The first value in the sequence</param>
        /// <param name="i1">The last value in the sequence</param>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<byte> sequential(byte i0, byte i1)
            => slice(B256x8u,i0, (byte)(i1 - i1 + 1));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/>-bit values selected from an 8-bit domain
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="i0">The first value in the sequence</param>
        /// <param name="i1">The last value in the sequence</param>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<byte> sequential(W8 w, byte i0, byte i1)
            => slice(B256x16u,i0, (byte)(i1 - i1 + 1));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/>-bit values selected from an 8-bit domain
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="i0">The first value in the sequence</param>
        /// <param name="i1">The last value in the sequence</param>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<ushort> sequential(W16 w, byte i0, byte i1)
            => recover<ushort>(slice(B256x16u,i0, (byte)(i1 - i1 + 1)));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/>-bit values selected from an 8-bit domain
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="i0">The first value in the sequence</param>
        /// <param name="i1">The last value in the sequence</param>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<uint> sequential(W32 w, byte i0, byte i1)
            => recover<uint>(slice(B256x32u,i0, (byte)(i1 - i1 + 1)));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/>-bit values selected from an 8-bit domain
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="i0">The first value in the sequence</param>
        /// <param name="i1">The last value in the sequence</param>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<ulong> sequential(W64 w, byte i0, byte i1)
            => recover<ulong>(slice(B256x64u,i0, (byte)(i1 - i1 + 1)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> sequential<T>(byte i0, byte i1)
            where T : unmanaged
                => recover<T>(slice(B256x8u,i0, (byte)(i1 - i1 + 1)));

        /// <summary>
        /// Returns a <typeparamref name='T'/>-valued sequence of <typeparamref name='W'/>-bit values selected from an 8-bit domain
        /// </summary>
        /// <param name="i0">The first value in the sequence</param>
        /// <param name="i1">The last value in the sequence</param>
        /// <typeparam name="W">The width type</typeparam>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> sequential<W,T>(byte i0, byte i1)
            where T : unmanaged
            where W : unmanaged, ITypeWidth
        {
            if(typeof(W) == typeof(W8))
                return recover<T>(sequential(w8, i0, i0));
            else if(typeof(W) == typeof(W16))
                return recover<T>(sequential(w16, i0, i0));
            else if(typeof(W) == typeof(W32))
                return recover<T>(sequential(w32, i0, i0));
            else if(typeof(W) == typeof(W64))
                return recover<T>(sequential(w64, i0, i0));
            else
                throw no<W>();
        }

        /// <summary>
        /// Returns a <typeparamref name='T'/>-valued sequence of <typeparamref name='W'/>-bit values selected from an 8-bit domain
        /// </summary>
        /// <param name="i0">The first value in the sequence</param>
        /// <param name="i1">The last value in the sequence</param>
        /// <param name="w">The width selector</param>
        /// <param name="t">The value type selector</param>
        /// <typeparam name="W">The width type</typeparam>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> sequential<W,T>(byte i0, byte i1, W w = default,  T t = default)
            where T : unmanaged
            where W : unmanaged, ITypeWidth
                => sequential<W,T>(i0,i1);
    }
}