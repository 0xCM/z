//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using XF = HexSymFacet;
    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static bit upperhex(C src)
            => ((XF)src >= XF.FirstNumber && (XF)src <= XF.LastNumber)
            || ((XF)src >= XF.FirstLetterUp && (XF)src <= XF.LastLetterUp);

        [MethodImpl(Inline), Op]
        public static bit upperhex(char src)
            => (src >= (char)XF.FirstNumber && src <= (char)XF.LastNumber)
            || (src >= (char)XF.FirstLetterUp && src <= (char)XF.LastLetterUp);
    }
}