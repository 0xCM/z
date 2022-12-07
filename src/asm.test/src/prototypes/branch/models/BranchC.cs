//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using C = System.UInt64;
    using T = System.Byte;

    using static AsmBranch.Branch03;

    partial class AsmBranch
    {
        public static byte branch3(Branch03 m, ulong src)
        {
            switch(src)
            {
                case C0:
                    return R0;
                case C1:
                    return R1;
                case C2:
                    return R2;
                case C3:
                    return R3;
                case C4:
                    return R4;
                case C5:
                    return R5;
                case C6:
                    return R6;
                case C7:
                    return R7;
                case C8:
                    return R8;
                case C9:
                    return R9;
                case CA:
                    return RA;
                case CB:
                    return RB;
                default:
                    return 0;
            }
        }
        public readonly struct Branch03
        {
            public const C C0 = 0xa0a0a0a;

            public const C C1= 0x10101010;

            public const C C2 = 0x20202020;

            public const C C3 = 0x30303030;

            public const C C4 = 0x40404040;

            public const C C5 = 0x50505050;

            public const C C6 = 0x60606060;

            public const C C7 = 0x70707070;

            public const C C8 = 0x08080808;

            public const C C9 = 0x09090809;

            public const C CA = 0xb0b0b0b0;

            public const C CB = 0xc0c0c0c0;

            public const T R0 = 0x32;

            public const T R1 = 0x19;

            public const T R2 = 0x78;

            public const T R3 = 0x22;

            public const T R4 = 0x39;

            public const T R5 = 0x81;

            public const T R6 = 0x23;

            public const T R7 = 0x91;

            public const T R8 = 0x87;

            public const T R9 = 0x33;

            public const T RA = 0x93;

            public const T RB = 0x18;
        }
    }    
}