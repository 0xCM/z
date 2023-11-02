//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
    [MethodImpl(Inline), Op]
    public static BpSpec spec(string name, BpExpr pattern, BfOrigin origin)
        => spec(describe(name, pattern, origin));

    [MethodImpl(Inline), Op]
    public static BpSpec spec<P>(string name, BpExpr pattern, P src)
        where P : unmanaged, IBitPattern<P>
            => spec(describe(name, pattern, src));

    [MethodImpl(Inline), Op]
    public static BpSpec spec(in BpInfo src)
    {
        var dst = BpSpec.Empty;
        dst.Origin = src.Origin.Format();
        dst.Content = src.Expr;
        dst.DataType = src.DataType.DisplayName();
        dst.Descriptor = src.Descriptor;
        dst.MinSize = src.PackedSize;
        dst.Name = src.Name;
        dst.DataWidth = src.DataWidth;
        return dst;
    }
}
