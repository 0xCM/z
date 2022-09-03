//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct BitPatterns
    {
        [MethodImpl(Inline), Op]
        public static BfOrigin<P> origin<P>(P src)
            where P: unmanaged
                => new BfOrigin<P>(src);

        public static Index<string> indicators(in BitPattern src)
            => text.split(src.Data, Chars.Space).Reverse();

        public static BfModel model(in asci64 name, in BitPattern src, BfOrigin origin)
            => PolyBits.model(origin, name, segs(src));

        public static string format(in BpDef src)
            => string.Format("{0}[{1}]", src.Name, src.Pattern);

        public static string format<P>(in BpDef<P> src)
            where P : unmanaged
                => string.Format("{0}[{1}]", src.Name, src.Pattern);

        public static Index<BpInfo> reflected(Type src)
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
}