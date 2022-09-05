//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static HexOptionData;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static char hexchar(Hex2 src)
            => (char)hexchar(UpperCase, src);

        [MethodImpl(Inline), Op]
        public static char hexchar(Hex3 src)
            => (char)hexchar(UpperCase, src);

        [MethodImpl(Inline), Op]
        public static char upper(Hex4 src)
            => (char)hexchar(UpperCase, src);

        [MethodImpl(Inline), Op]
        public static char lower(Hex4 src)
            => hexchar(LowerCase, src);

        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, Hex1 src)
            => (char)symbol(@case, (Hex3Kind)src.Value);

        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, Hex2 src)
            => (char)symbol(@case, (Hex3Kind)src.Value);

        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, Hex3 src)
            => (char)symbol(@case, (Hex3Kind)src.Value);

        [MethodImpl(Inline), Op]
        public static char hexchar(LowerCased @case, Hex3 src)
            => (char)symbol(@case, (Hex3Kind)src.Value);

        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, Hex4 src)
            => (char)symbol(@case, src.Value);

        [MethodImpl(Inline), Op]
        public static char hexchar(LowerCased @case, Hex4 src)
            => (char)symbol(@case, src.Value);

        [MethodImpl(Inline)]
        public static char hexchar<C>(C @case, byte value)
            where C : unmanaged, ILetterCase
        {
            if(typeof(C) == typeof(LowerCased))
                return hexchar(LowerCase,(Hex4)value);
            else if(typeof(C) == typeof(UpperCased))
                return hexchar(UpperCase,(Hex4)value);
            else
                throw no<C>();
        }
    }
}