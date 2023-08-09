//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;

partial class XedPatterns
{
    public static Index<InstFieldRow> fieldrows(Index<InstPattern> src)
    {
        var dst = list<InstFieldRow>();
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var pattern = ref src[i];
            ref readonly var body = ref pattern.Body;
            ref readonly var fields = ref body.Cells;
            for(var k=z8; k<fields.Count; k++)
                dst.Add(fieldrow(pattern, fields[k], k));
        }
        return dst.ToIndex();
    }

    [Op]
    static InstFieldRow fieldrow(InstPattern pattern, in CellValue src, byte index)
    {
        var dst = InstFieldRow.Empty;
        dst.PatternId = pattern.PatternId;
        dst.Mode = pattern.Mode;
        dst.Lock = XedCells.@lock(pattern.Cells);
        dst.Index = Require.equal(index,src.Position);
        dst.FieldClass = src.CellKind;
        dst.FieldKind = src.Field;
        dst.InstClass = pattern.InstClass;
        dst.OpCode = pattern.OpCode;
        switch(src.CellKind)
        {
            case RuleCellKind.InstSeg:
                dst.Seg = src.AsInstSeg();
            break;
            case RuleCellKind.BitLit:
                dst.BitLiteral = src.AsBitLit();
            break;
            case RuleCellKind.NeqExpr:
            case RuleCellKind.EqExpr:
                dst.FieldExpr = src.ToCellExpr();
            break;
            case RuleCellKind.HexLit:
                dst.HexLiteral = src.AsHexLit();
            break;
            case RuleCellKind.NtCall:
                dst.Nonterminal = src.AsNonterm();
            break;
            default:
                throw new NotSupportedException();
        }

        return dst;
    }
}
