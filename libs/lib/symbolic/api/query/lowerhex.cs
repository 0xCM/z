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
        public static bit lowerhex(C src)
            => ((XF)src >= XF.FirstNumber && (XF)src <= XF.LastNumber)
            || ((XF)src >= XF.FirstLetterLo && (XF)src <= XF.LastLetterLo);

        [MethodImpl(Inline), Op]
        public static bit lowerhex(char src)
            => (src >= (char)XF.FirstNumber && src <= (char)XF.LastNumber)
            || (src >= (char)XF.FirstLetterLo && src <= (char)XF.LastLetterLo);
    }
}