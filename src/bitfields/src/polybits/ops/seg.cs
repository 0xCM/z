//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class PolyBits
{
    [Op]
    internal static asci64 segname(string src, out asci64 dst)
    {
        Demand.lteq(src.Length, asci64.Size);
        dst = src;
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static BfSegModel seg(string name, uint i0, uint i1, BitMask mask)
        => new (segname(name, out _), i0, i1, mask);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BfSegModel<K> seg<K>(K field, uint i0, uint i1, BitMask mask)
        where K : unmanaged
            => new (field, i0, i1, mask);
}
