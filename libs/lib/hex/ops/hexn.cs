//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static Hex1 hex1(byte src)
            => new Hex1(src);

        [MethodImpl(Inline), Op]
        public static Hex2 hex2(byte src)
            => new Hex2(src);

        [MethodImpl(Inline), Op]
        public static Hex3 hex3(byte src)
            => new Hex3(src);

        [MethodImpl(Inline), Op]
        public static Hex4 hex4(byte src)
            => new Hex4(src);

        [MethodImpl(Inline), Op]
        public static Hex5 hex5(byte src)
            => new Hex5(src);

        [MethodImpl(Inline), Op]
        public static Hex5 hex6(byte src)
            => new Hex5(src);

        [MethodImpl(Inline), Op]
        public static Hex8 hex8(byte src)
            => new Hex8(src);
    }
}