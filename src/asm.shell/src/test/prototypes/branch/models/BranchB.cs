//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmBranch.Branch02;

    partial class AsmBranch
    {
        public static byte branchB(Branch02 m, byte src)
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

        public readonly struct Branch02
        {
            public const byte C0 = 0xf3;

            public const byte C1 = 0x81;

            public const byte C2 = 0x11;

            public const byte C3 = 0x12;

            public const byte C4 = 0x55;

            public const byte C5 = 0x68;

            public const byte C6 = 0x3f;

            public const byte C7 = 0x18;

            public const byte C8 = 0x14;

            public const byte C9 = 0x21;

            public const byte CA = 0x59;

            public const byte CB = 0x86;

            public const byte R0 = 0x32;

            public const byte R1 = 0x19;

            public const byte R2 = 0x78;

            public const byte R3 = 0x22;

            public const byte R4 = 0x39;

            public const byte R5 = 0x81;

            public const byte R6 = 0x23;

            public const byte R7 = 0x91;

            public const byte R8 = 0x87;

            public const byte R9 = 0x33;

            public const byte RA = 0x93;

            public const byte RB = 0x18;
        }
    }
}