//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
    public static string descriptor(BitPattern src)
        => text.intersperse(segs(src).Select(x => x.Format()).Storage, Chars.Space);

    public static BpInfo describe<O>(string name, params string[] segs)
    {
        var pattern = new BitPattern(text.join(Chars.Space,segs));
        return describe(name, pattern, PolyBits.origin<O>());
    }

    public static BpInfo describe<O>(string name, BitPattern pattern)
        => describe(name, pattern, PolyBits.origin<O>());

    public static BpInfo describe(string name, BitPattern pattern, BfOrigin src)
            => new BpInfo(
            def(name, pattern, src),
            bitwidth(pattern),
            datatype(pattern),
            packedsize(pattern),
            segs(pattern),
            descriptor(pattern)
        );

    public static BpInfo describe<P>(string name, BitPattern pattern, P src)
        where P : unmanaged, IBpDef<P>
            => new BpInfo(
            def<P>(name, pattern),
            bitwidth(pattern),
            datatype(pattern),
            packedsize(pattern),
            segs(pattern),
            descriptor(pattern)
        );
}
