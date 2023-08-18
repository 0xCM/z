//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRender;

partial class XedOps
{
    public static string specifier(in OpSpec src)
    {
        const string OpSepSlot = "/{0}";
        const sbyte Pad = -XedFields.FieldRender.ColWidth;

        var dst = text.buffer();
        dst.AppendFormat(RP.slot(0, Pad), src.Index);
        dst.Append(" | ");
        dst.AppendFormat("{0,-4}", format(src.Name));
        dst.AppendFormat(OpSepSlot, format(src.Action));
        dst.AppendFormat(OpSepSlot, format(src.WidthCode));
        dst.AppendFormat(OpSepSlot, format(src.Visibility));
        dst.AppendFormat(OpSepSlot, format(src.OpType));
        if(src.Rule.IsNonEmpty)
            dst.AppendFormat(OpSepSlot, src.Rule.Name.ToString().ToUpper());
        else if(src.ElementType.IsNumber)
            dst.AppendFormat(OpSepSlot, src.ElementType);

        return dst.Emit();
    }
}

