//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedFields
{
    public static void convert(in FieldValue src, out Field dst)
    {
        dst = Field.Empty;
        var kind = src.Field;
        var size = FieldDefs.size(kind, src.CellKind);
        if(size.PackedWidth == 1)
            dst = Field.init(kind, (bit)src.Data);
        else if(size.NativeWidth == 1)
            dst = Field.init(kind, (byte)src.Data);
        else if(size.NativeWidth == 2)
            dst = Field.init(kind, (ushort)src.Data);
        else
            Errors.Throw($"Unsupported size {size}");
    }
}