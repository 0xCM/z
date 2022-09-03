//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static bit specifier(AsciCode c)
            => c == AsciCode.X || c == AsciCode.x || c == AsciCode.h;

        [MethodImpl(Inline), Op]
        public static bit specifier(char c)
            => specifier((AsciCode)c);

        [MethodImpl(Inline), Op]
        public static bit fence(char c)
            => c == Chars.LBracket || c == Chars.RBracket;
    }
}