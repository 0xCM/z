//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using XF = HexSymFacet;
    using DF = DecimalSymFacet;

    partial struct Digital
    {
        /// <summary>
        /// Tests whether a character symbol is one of '0'..'9'
        /// </summary>
        /// <param name="src">The symbol to test</param>
        [MethodImpl(Inline), Op]
        public static bit number(AsciCode c)
            => (DF)c >= DF.First && (DF)c <= DF.Last;

        /// <summary>
        /// Tests whether a <see cref='HexLowerSym'/> value is one of '0',...,'9'
        /// </summary>
        /// <param name="src">The symbol to test</param>
        [MethodImpl(Inline), Op]
        public static bool number(HexLowerSym src)
            => (XF)src <= XF.LastNumber;

        /// <summary>
        /// Tests whether a <see cref='HexUpperSym'/> value is one of '0',...,'9'
        /// </summary>
        /// <param name="src">The symbol to test</param>
        [MethodImpl(Inline), Op]
        public static bool number(HexUpperSym src)
            => (XF)src <= XF.LastNumber; 

        [Op]
        public static bool number(ReadOnlySpan<char> src, out uint j, out LineNumber dst)
        {
            j = 0;
            dst = default;
            var i = text.index(src,Chars.Colon);
            if(i == NotFound)
                return false;

            if(uint.TryParse(slice(src,0, i), out var n))
            {
                j = (uint)(i + 1);
                dst = n;
                return true;
            }

            return false;
        }
    }
}