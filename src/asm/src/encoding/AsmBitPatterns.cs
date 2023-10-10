//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

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

    const string mmm = "mmm";

    const string WRXB = "WRXB";

    const string W = "W";

    const string R = "R";

    const string X = "X";

    const string B = "B";

    const string L = "L";

    const string RXB = $"{R}{X}{B}";

    const string cccccccc = "cccccccc";

    const string mmmmm = "mmmmm";

    const string pp = "pp";

    const string aaa = "aaa";

    const string q = "q";

    const string d0 = "0";

    const string d1 = "1";

    const string z = "z";

    const string b = "b";

    const string f = "f";

    const string VL = "VL";

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

    public static readonly BpInfo Evex = describe<P>(nameof(Evex),
        mmm + sep + d0 + sep + q + sep + RXB + sep +
        pp + sep + d1 + sep + vvvv + sep + W + sep + 
        aaa + sep + f + sep + b + sep  + VL + sep + z 
        );

}
