//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using C = System.UInt32;
    using T = System.UInt16;

    using static AsmBranch.Branch04;

    partial class AsmBranch
    {
        public static T branch4(Branch04 m, C src)
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
        public readonly struct Branch04
        {
            public const C C0 = 0xa1a0a0a;

            public const C C1= 0x10101110;

            public const C C2 = 0x20202020;

            public const C C3 = 0x30373030;

            public const C C4 = 0x40404049;

            public const C C5 = 0x50595050;

            public const C C6 = 0x60676060;

            public const C C7 = 0x70707070;

            public const C C8 = 0x38087808;

            public const C C9 = 0x19390807;

            public const C CA = 0xb7bcb0b0;

            public const C CB = 0xc9c0c0c1;

            public const T R0 = 0x11;

            public const T R1 = 0x22;

            public const T R2 = 0x33;

            public const T R3 = 0x44;

            public const T R4 = 0x55;

            public const T R5 = 0x66;

            public const T R6 = 0x77;

            public const T R7 = 0x88;

            public const T R8 = 0x99;

            public const T R9 = 0xaa;

            public const T RA = 0xbb;

            public const T RB = 0xcc;
        }
    }
}