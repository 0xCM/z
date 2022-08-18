//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct AsciSymbols
    {
        [MethodImpl(Inline), Op]
        public static char decode(byte src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char decode(AsciCode src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char decode(AsciSymbol src)
            => src;
    }
}