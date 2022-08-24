//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class text
    {
        /// <summary>
        /// Encodes the source text as unicode byte sequence
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> utf16(string src)
            => bytes(span(src));

        /// <summary>
        /// Decodes the source data as a unicode character sequence
        /// </summary>
        /// <param name="src">The utf16 encoded characters</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> utf16(ReadOnlySpan<byte> src)
            => recover<char>(src);
    }
}