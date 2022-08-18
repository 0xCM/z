//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NativeClass;

    partial class NativeTypes
    {
        [MethodImpl(Inline), Op]
        public static char indicator(NativeClass @class)
            => @class switch {
                B => Chars.b,
                U => Chars.u,
                I => Chars.i,
                F => Chars.f,
                C => Chars.c,
                _ => ' ',
            };
    }
}