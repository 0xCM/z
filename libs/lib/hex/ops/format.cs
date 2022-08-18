//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static string format(in HexString<Hex1Kind> src, Hex1Kind kind)
            => src.String(kind);

        [MethodImpl(Inline), Op]
        public static string format(in HexString<Hex2Kind> src,  Hex2Kind kind)
            => src.String(kind);

        [MethodImpl(Inline), Op]
        public static string format(in HexString<Hex3Kind> src, Hex3Kind kind)
            => src.String(kind);

        [MethodImpl(Inline), Op]
        public static string format(in HexString<Hex4Kind> src, Hex4Kind kind)
            => src.String(kind);

        [MethodImpl(Inline), Op]
        public static string format(in HexString<Hex5Kind> src, Hex5Kind kind)
            => src.String(kind);

        [MethodImpl(Inline), Op]
        public static string format(Hex1Kind kind)
            => format(hexstring(n1), kind);

        [MethodImpl(Inline), Op]
        public static string format(Hex2Kind kind)
            => format(hexstring(n2), kind);

        [MethodImpl(Inline), Op]
        public static string format(Hex3Kind kind)
            => format(hexstring(n3), kind);

        [MethodImpl(Inline), Op]
        public static string format(Hex4Kind kind)
            => format(hexstring(n4), kind);
    }
}