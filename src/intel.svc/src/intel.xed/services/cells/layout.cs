//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using static XedRules;
using static XedRules.LayoutCellKind;
using static XedModels;

using K = XedRules.RuleCellKind;

partial class XedCells
{
    public static LayoutCell layout(CellValue src)
    {
        var dst = ByteBlock16.Empty;
        switch(src.CellKind)
        {
            case K.BitLit:
                dst[0] = src.AsBitLit();
                dst[15] = (byte)BL;
            break;
            case K.HexLit:
                dst[0] = src.AsHexLit();
                dst[15] = (byte)XL;
            break;
            case K.WidthVar:
                dst[0] = (byte)src.AsWidthVar();
                dst[15] = (byte)WV;
            break;

            case K.InstSeg:
            {
                var iseg = src.AsInstSeg();
                dst[14] = (byte)iseg.Field;
                if(iseg.IsLiteral)
                    @as<FieldSeg>(dst.First) = FieldSeg.literal(iseg.Field, iseg.ToLiteral());
                else
                    @as<FieldSeg>(dst.First) = FieldSeg.symbolic(iseg.Field, InstSegTypes.pattern(iseg.Type));
                dst[15] = (byte)LayoutCellKind.FS;
            }
            break;
            case K.NtCall:
                @as<Nonterminal>(dst.First) = src.AsNonterm();
                dst[15] = (byte)NT;
            break;
            default:
                Errors.Throw(AppMsg.UnhandledCase.Format(src.CellKind));
            break;

        }
        return new LayoutCell(dst);
    }
}