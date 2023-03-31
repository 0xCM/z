//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitPatterns
    {
        [MethodImpl(Inline), Op]
        public static BpSpec spec(in asci32 name, in BitPattern pattern, BfOrigin origin)
            => spec(describe(name, pattern, origin));

        [MethodImpl(Inline), Op]
        public static BpSpec spec<P>(in asci32 name, in BitPattern pattern, P src)
            where P : unmanaged
                => spec(describe(name, pattern, src));

        [MethodImpl(Inline), Op]
        public static BpSpec spec(in BpInfo src)
        {
            var dst = BpSpec.Empty;
            dst.Origin = src.Origin.Format();
            dst.Content = src.Pattern;
            dst.DataType = src.DataType.DisplayName();
            dst.Descriptor = src.Descriptor;
            dst.MinSize = src.MinSize;
            dst.Name = src.Name;
            dst.DataWidth = src.DataWidth;
            return dst;
        }
    }
}