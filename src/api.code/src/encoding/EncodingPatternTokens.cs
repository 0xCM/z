//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EncodingPatternTokens
    {
        public const byte ZED = 0;

        public const byte FF = 0xff;

        public const byte RET_xC3 = 0xc3;

        public const byte INTR_xCC = 0xcc;

        public const byte SBB_x19 = 0x19;

        public const byte E0 = 0xe0;

        public const byte Jmp_x48 = 0x48;

        public const byte Call_xE8 = 0xe8;
    }
}