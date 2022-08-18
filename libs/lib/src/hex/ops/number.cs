//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using DF = DecimalSymFacet;
    using XF = HexSymFacet;

    partial struct Hex
    {
        /// <summary>
        /// Tests whether a character symbol is one of '0'..'9'
        /// </summary>
        /// <param name="src">The symbol to test</param>
        [MethodImpl(Inline), Op]
        public static bit number(char c)
            => (DF)c >= DF.First && (DF)c <= DF.Last;

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
   }
}