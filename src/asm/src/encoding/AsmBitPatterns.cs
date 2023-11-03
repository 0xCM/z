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
    const string ss = "ss";

    const string iii = "iii";

    const string bbb = "bbb";

    const string mm = "mm";

    const string rrr = "rrr";

    const string nnn = "nnn";

    const string vvvv = "vvvv";

    const string RexIndicator = "0100";

    const string VexC4Indicator = "11000100";

    const string VexC5Indicator = "11000101";

    const string W = "W";

    const string R = "R";

    const string X = "X";

    const string B = "B";

    const string L = "L";

    const string mmmmm = "mmmmm";

    const string pp = "pp";

    public static readonly BpInfo Sib = describe(nameof(Asm.Sib),
        bbb, iii, ss);

    public static readonly BpInfo ModRm = describe(nameof(Asm.ModRm),
       mm, rrr, nnn);

    public static readonly BpInfo Rex = describe(nameof(Rex),
        RexIndicator, W, R, X, B);

    public static readonly BpInfo VexC4 = describe(nameof(Asm.VexC4),
        VexC4Indicator, R, X, B, mmmmm, W, vvvv, L, pp);

    public static readonly BpInfo VexC5 = describe(nameof(Asm.VexC5),
        VexC5Indicator, R, vvvv, L, pp);
}
