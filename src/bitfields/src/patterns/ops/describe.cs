//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
    public static string descriptor(BpExpr src)
        => text.intersperse(segdefs(src).Select(x => x.Format()).Storage, Chars.Space);

    public static BpInfo describe(string name, params string[] segs)
        => describe(name, new BpExpr(text.join(Chars.Space,segs)));

    public static BpInfo describe(string name, BpExpr pattern)
        => new BpInfo(
            BitPatterns.pattern(name, pattern),
            bitwidth(pattern),
            datatype(pattern),
            packedsize(pattern),
            segdefs(pattern),
            descriptor(pattern)
        );
}
