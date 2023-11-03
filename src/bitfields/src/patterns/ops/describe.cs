//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
    public static string descriptor(BpExpr src)
        => text.intersperse(segs(src).Select(x => x.Format()).Storage, Chars.Space);

    public static BpInfo describe(string name, params string[] segs)
        => describe(name, new BpExpr(text.join(Chars.Space,segs.Reverse())));

    public static BpInfo describe(string name, BpExpr pattern)
        => new BpInfo(
            def(name, pattern),
            bitwidth(pattern),
            datatype(pattern),
            packedsize(pattern),
            segs(pattern),
            descriptor(pattern)
        );
}
