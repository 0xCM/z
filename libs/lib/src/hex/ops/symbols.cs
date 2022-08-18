//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;
    using static HexFormatSpecs;
    using static HexOptionData;

    partial struct Hex
    {
        /// <summary>
        /// Presents the source value as a sequence of hex symbols
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="case">The case selector</param>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<HexDigitSym> symbols<C>(C @case, byte src)
            where C : unmanaged, ILetterCase
        {
            if(typeof(C) == typeof(LowerCased))
                return recover<char,HexDigitSym>(span(src.ToString(LC)));
            else
                return recover<char,HexDigitSym>(span(src.ToString(UC)));
        }

        [MethodImpl(Inline)]
        public static void symbols<T,C>(in T src, C @case, Span<HexDigitSym> dst)
            where T : unmanaged
            where C : unmanaged, ILetterCase
        {
            ref readonly var b = ref @as<T,byte>(src);
            var cellsize = size<T>();
            for(var i=0; i<cellsize*2; i+=2)
            {
                var lo = (HexDigitValue)(0x0F & skip(b,i));
                var hi = (HexDigitValue)(skip(b,i) >> 4);
                seek(dst,i) = symbol(@case, lo);
                seek(dst,i+1) = symbol(@case, hi);
            }
        }

        [MethodImpl(Inline)]
        public static void symbols<C>(C @case, ReadOnlySpan<HexDigitValue> src, Span<HexDigitSym> dst)
            where C : unmanaged, ILetterCase
        {
            var len = src.Length;
            for(var i = 0u; i<len; i++)
                seek(dst,i) = symbol(@case, skip(src,i));
        }

        /// <summary>
        /// Presents the source value as a sequence of hex symbols
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="case">The case selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<HexUpperSym> symbols(UpperCased @case)
            => recover<byte,HexUpperSym>(UpperHexDigits);

        /// <summary>
        /// Presents the source value as a sequence of hex symbols
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="case">The case selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<HexLowerSym> symbols(LowerCased @case)
            => recover<byte,HexLowerSym>(LowerHexDigits);
    }
}