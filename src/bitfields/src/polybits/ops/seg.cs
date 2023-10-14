//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static BfSegModel seg(string name, uint i0, uint i1, BitMask mask)
        => new (name, i0, i1, mask);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BfSegModel<K> seg<K>(K field, uint i0, uint i1, BitMask mask)
        where K : unmanaged
            => new (field, i0, i1, mask);
}
