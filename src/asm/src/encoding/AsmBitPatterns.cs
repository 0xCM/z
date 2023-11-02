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

    const string WRXB = "WRXB";

    const string W = "W";

    const string R = "R";

    const string X = "X";

    const string B = "B";

    const string L = "L";

    const string cccccccc = "cccccccc";

    const string mmmmm = "mmmmm";

    const string pp = "pp";

    public static readonly BpInfo Sib = describe<P>(nameof(Asm.Sib),
        ss, iii, bbb);

    public static readonly BpInfo ModRm = describe<P>(nameof(Asm.ModRm),
        mm, rrr, nnn);

    public static readonly BpInfo Rex = describe<P>(nameof(Rex),
        WRXB, W, R, X, B);

    public static readonly BpInfo VexC4 = describe<P>(nameof(Asm.VexC4),
        cccccccc, R, X, B, mmmmm, W, vvvv, L, pp);

    public static readonly BpInfo VexC5 = describe<P>(nameof(Asm.VexC5),
        cccccccc, R, vvvv, L, pp);
}
