//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static Jcc32 jcc32(Jcc32Code code, Disp32 disp)
            => new (code, disp);

        [MethodImpl(Inline), Op]
        public static Jcc32 jcc32(Jcc32AltCode code, Disp32 disp)
            => new (code, disp);

        [MethodImpl(Inline), Op]
        public static Jcc8 jcc8(Jcc8Code code, Disp8 disp)
            => new (code, disp);

        [MethodImpl(Inline), Op]
        public static Jcc8 jcc8(Jcc8AltCode code, Disp8 disp)
            => new (code, disp);
    }
}