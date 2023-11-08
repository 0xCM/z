//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Bitfields
{
    [MethodImpl(Inline), Op]
    public static BfSegDef segdef(string name, byte min, byte max, BitMask mask)
        => new (name, min, max, mask);

    [MethodImpl(Inline), Op]
    public static BfSegDef segdef(string name, NativeSize size, byte min, byte max)
        => new (name, min, max, mask(size, min, max));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BfSegDef<K> segdef<K>(K field, byte i0, byte i1, BitMask mask)
        where K : unmanaged
            => new (field, i0, i1, mask);    

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BfSegDef<K> segdef<K>(K field, NativeSize size, byte min, byte max)
        where K : unmanaged
            => new (field, min, max, mask(size, min, max));
}
