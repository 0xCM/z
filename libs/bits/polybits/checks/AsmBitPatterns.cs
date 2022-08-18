//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static BitPatterns;

    using P = AsmBitPatterns;

    [LiteralProvider("asm.bits.patterns")]
    public readonly struct AsmBitPatterns
    {
        const string join = "_";

        const string sep = " ";

        const string ss = "ss";

        const string iii = "iii";

        const string bbb = "bbb";

        const string Disp1 = "dddddddd";

        const string Imm1 = "iiiiiiii";

        const string mm = "mm";

        const string rrr = "rrr";

        const string nnn = "nnn";

        const string vvvv = "vvvv";

        const string WRXB = "WRXB";

        const string W = "W";

        const string R = "R";

        const string X = "X";

        const string B = "B";

        const string L = "L";

        const string cccccccc = "cccccccc";

        const string mmmmm = "mmmmm";

        const string pp = "pp";

        public static readonly BpInfo Sib = describe<P>(nameof(Sib),
            ss + sep + iii + sep + bbb);

        public static readonly BpInfo ModRm = describe<P>(nameof(ModRm),
            mm + sep + rrr + sep + nnn);

        public static readonly BpInfo Rex = describe<P>(nameof(Rex),
            WRXB + sep + W + sep + R + sep + X + sep + B);

        public static readonly BpInfo VexC4 = describe<P>(nameof(VexC4),
            cccccccc + sep + R + sep + X + sep + B + sep + mmmmm + sep + W + sep + vvvv + sep + L + sep + pp)
            ;

        public static readonly BpInfo VexC5 = describe<P>(nameof(VexC5),
            cccccccc + sep + R + sep + vvvv + sep + L + sep + pp
            );

        const string Prefix1 = "qqqqqqqq";

        const string OcByte1 = "11111111";

        const string OcByte2 = "22222222";

        const string OcByte3 = "33333333";

        const string Disp2 = Disp1 + join +  Disp1;

        const string Disp4 = Disp2 + join + Disp2;

        const string Imm2 = Imm1 + join + Imm1;

        const string Imm4 = Imm2 + join + Imm2;
    }
}