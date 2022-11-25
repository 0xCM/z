//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class H0x
    {

        /// <summary>
        /// Projects a bytespan into a codespan
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The hexcode target</param>
        [MethodImpl(Inline), Op]
        public static int codes(ReadOnlySpan<byte> src, UpperCased @case, Span<HexDigitCode> dst)
        {
            var j=0u;
            for(var i=0u; i<src.Length; i++, j+=2)
            {
                ref readonly var data = ref skip(src, i);
                seek(dst, j) = code(@case, (HexDigitValue)(data >> 4));
                seek(dst, j + 1) = code(@case, (HexDigitValue)(0xF & data));
            }
            return (int)j;
        }

        /// <summary>
        /// Projects a bytespan into a codespan
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The hexcode target</param>
        [MethodImpl(Inline), Op]
        public static int codes(ReadOnlySpan<byte> src, LowerCased @case, Span<HexDigitCode> dst)
        {
            var j=0u;
            for(var i=0u; i<src.Length; i++, j+=2)
            {
                ref readonly var data = ref skip(src, i);
                seek(dst, j) = code(@case, (HexDigitValue)(data >> 4));
                seek(dst, j + 1) = code(@case, (HexDigitValue)(0xF & data));
            }
            return (int)j;
        }
    }
}