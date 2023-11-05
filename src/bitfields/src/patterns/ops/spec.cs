//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
    [MethodImpl(Inline), Op]
    public static BpSpec spec(string name, BpExpr pattern)
        => spec(describe(name, pattern));

    [MethodImpl(Inline), Op]
    public static BpSpec spec(in BpInfo src)
    {
        var dst = BpSpec.Empty;
        dst.Content = src.Expr;
        dst.DataType = src.DataType.DisplayName();
        dst.Descriptor = src.Descriptor;
        dst.MinSize = src.PackedSize;
        dst.Name = src.Name;
        dst.DataWidth = src.DataWidth;
        return dst;
    }
}
