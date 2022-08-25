//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmBranch.Branch01;

    partial class AsmBranch
    {
        [Op]
        public static uint branchA(Branch01 m, string src)
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
                default:
                    return 0;
            }
        }

        public readonly struct Branch01
        {
            public const string C0 = "201313252";

            public const string C1 = "5013138882";

            public const string C2 = "33892742222";

            public const string C3 = "1927465333";

            public const string C4 = "4653331633";

            public const string C5 = "1011051110";

            public const uint R0 = 0x32;

            public const uint R1 = 0x19;

            public const uint R2 = 0x78;

            public const uint R3 = 0x22;

            public const uint R4 = 0x349;

            public const uint R5 = 0x81;
        }
    }   
}