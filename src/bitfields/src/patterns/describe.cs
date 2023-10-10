//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitPatterns
    {
        public static string descriptor(in BitPattern src)
            => text.intersperse(segs(src).Select(x => x.Format()), Chars.Space);

        public static BpInfo describe<O>(in asci32 name, in BitPattern pattern)
            => describe(name, pattern, PolyBits.origin<O>());

        public static BpInfo describe(in asci32 name, in BitPattern pattern, BfOrigin src)
                => new BpInfo(
                def(name, pattern, src),
                bitwidth(pattern),
                datatype(pattern),
                minsize(pattern),
                segs(pattern),
                descriptor(pattern)
            );

        public static BpInfo describe<P>(in asci32 name, in BitPattern pattern, P src)
            where P : unmanaged
                => new BpInfo(
                def(name, pattern, src),
                bitwidth(pattern),
                datatype(pattern),
                minsize(pattern),
                segs(pattern),
                descriptor(pattern)
            );
    }
}