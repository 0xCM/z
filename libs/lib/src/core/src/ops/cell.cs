//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Reads a generic value beginning at a specified offset
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The index at which span consumption should begin</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Int8x64k)]
        public static ref readonly T cell<T>(ReadOnlySpan<byte> src, int offset)
            where T : unmanaged
                => ref first<T>(slice(src,offset));

        [MethodImpl(Inline), Op]
        public static ref ushort cell16(Span<byte> src, uint offset)
            => ref first<ushort>(slice(src, offset));

        [MethodImpl(Inline), Op]
        public static ref uint cell32(Span<byte> src, uint offset)
            => ref first<uint>(slice(src, offset));

        [MethodImpl(Inline), Op]
        public static ref ulong cell64(Span<byte> src, uint offset)
            => ref first<ulong>(slice(src, offset));
    }
}