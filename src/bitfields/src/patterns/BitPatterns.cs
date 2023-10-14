//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public readonly partial struct BitPatterns
{
    [MethodImpl(Inline), Op]
    public static BfOrigin<P> origin<P>()
        where P: unmanaged
            => new (default(P));

    [MethodImpl(Inline), Op]
    public static BpExpr define(string src)
        => new(src);

    public static BfModel model(string name, BpExpr src, BfOrigin origin)
        => PolyBits.model(origin, name, segs(src));

    public static ReadOnlySeq<BpInfo> reflected(Type src)
    {
        var target = typeof(BpInfo);
        var props = src.Properties().Ignore().Static().WithPropertyType(target).Index();
        var fields = src.Fields().Ignore().Static().Where(x => x.FieldType == target).Index();
        var methods = src.Methods().Ignore().Public().WithArity(0).Returns(target).Index();
        var count = props.Count + fields.Count + methods.Count;
        Index<BpInfo> dst = alloc<BpInfo>(count);
        var k=0u;
        for(var i=0; i<props.Count; i++, k++)
            dst[k] = (BpInfo)props[i].GetValue(null);

        for(var i=0; i<fields.Count; i++, k++)
            dst[k] = (BpInfo)fields[i].GetValue(null);

        for(var i=0; i<methods.Count; i++, k++)
            dst[k] = (BpInfo)methods[i].Invoke(null, new object[]{});
        return dst;
    }
}
