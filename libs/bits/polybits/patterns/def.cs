//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct BitPatterns
    {
        [MethodImpl(Inline), Op]
        public static BpDef def(in asci32 name, in BitPattern pattern, BfOrigin origin)
            => new BpDef(name, pattern, origin);

        [MethodImpl(Inline), Op]
        public static BpDef<P> def<P>(in asci32 name, in BitPattern pattern, P src)
            where P : unmanaged
                => new BpDef<P>(name, pattern, origin(src));

        public static Index<BpDef> defs(ReadOnlySpan<BpInfo> src)
        {
            var count = src.Length;
            var dst = alloc<BpDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i).Def;
            return dst;
        }
    }
}