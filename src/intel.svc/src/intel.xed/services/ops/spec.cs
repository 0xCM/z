//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class Xed
{
    public static InstOpSpec spec(in InstOpDetail src)
    {
        var dst = InstOpSpec.Empty;
        dst.Pattern = src.Pattern;
        dst.Index = src.Index;
        dst.Name = src.Name;
        dst.ElementType = src.ElementType;
        dst.Width = new OpWidth(src.WidthCode, src.BitWidth);
        dst.BitWidth = src.BitWidth;
        dst.RegLit = src.RegLit;
        dst.Rule = src.Rule;
        dst.GprWidth = src.GrpWidth;
        var wi = XedWidths.describe(src.WidthCode);
        if(wi.SegType.CellCount > 1)
            dst.Seg = new InstOpSpec.Segmentation(wi.SegType.DataWidth, wi.SegType.CellWidth, src.ElementType.Indicator, wi.SegType.CellCount);
        return dst;
    }
}
