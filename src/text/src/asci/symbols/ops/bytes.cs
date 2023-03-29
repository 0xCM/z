//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static AsciChars;

    partial struct AsciSymbols
    {
        /// <summary>
        /// Presents a span of character codes as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(Span<AsciCode> src)
            => recover<AsciCode,byte>(src);

        /// <summary>
        /// Presents a span of asci symbols as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(Span<AsciSymbol> src)
            => recover<AsciSymbol,byte>(src);

        /// <summary>
        /// Selects a contiguous asci character sequence encoded as as bytespan
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> bytes(byte offset, byte count)
            => slice(CharBytes, offset, count);
    }
}