//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    [MethodImpl(Inline), Op]
    public static BpDef def(string name, in BitPattern pattern, BfOrigin origin)
        => new (name, pattern, origin);

    [MethodImpl(Inline), Op]
    public static BpDef<P> def<P>(string name, in BitPattern pattern)
        where P : unmanaged, IBpDef<P>
            => new (name, pattern, origin<P>());

    public static BpDef<P> def<P>()
        where P : unmanaged, IBpDef<P>
            => def<P>(typeof(P).Name, typeof(P).GetCustomAttribute<BitPatternAttribute>().Symbols ?? EmptyString);

    public static Index<BpDef> defs(ReadOnlySpan<BpInfo> src)
    {
        var count = src.Length;
        var dst = alloc<BpDef>(count);
        for(var i=0; i<count; i++)
            seek(dst,i) = skip(src,i).Def;
        return dst;
    }
}
