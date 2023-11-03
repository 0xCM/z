//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    [MethodImpl(Inline), Op]
    public static BpDef def(string name, in BpExpr pattern)
        => new (name, pattern, BfOrigin.Empty);

    public static BpDef def<P>()
        where P : unmanaged, IBitPattern<P>
            => def(typeof(P).Name, typeof(P).GetCustomAttribute<BitPatternAttribute>().Symbols ?? EmptyString);

    public static Index<BpDef> defs(ReadOnlySpan<BpInfo> src)
    {
        var count = src.Length;
        var dst = alloc<BpDef>(count);
        for(var i=0; i<count; i++)
            seek(dst,i) = skip(src,i).Def;
        return dst;
    }
}
