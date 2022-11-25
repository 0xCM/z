//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static char upper(Hex4 src)
            => Hex4.hexchar(UpperCase, src);

        [MethodImpl(Inline), Op]
        public static char lower(Hex4 src)
            => Hex4.hexchar(LowerCase, src);

    }
}