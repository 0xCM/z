//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedRules
    {
        public Index<InstOpRow> CalcInstOpRows(Index<InstOpDetail> src)
        {
            return Data(nameof(CalcInstOpRows),Calc);

            Index<InstOpRow> Calc()
            {
                var count = src.Count;
                var rows = alloc<InstOpRow>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var detail = ref src[i];
                    ref var dst = ref rows[i];
                    Require.invariant(detail.InstClass.Kind != 0);
                    dst.Pattern = detail.Pattern;
                    dst.InstClass = classifier(detail.InstClass);
                    dst.OpCode = detail.OpCode;
                    dst.Mode = detail.Mode;
                    dst.Lock = detail.Lock;
                    dst.Mod = detail.Mod;
                    dst.RexW = detail.RexW;
                    dst.OpCount = detail.OpCount;
                    dst.Index = detail.Index;
                    dst.Name = detail.Name;
                    dst.Kind = detail.Kind;
                    dst.Action = detail.Action;
                    dst.WidthCode = detail.WidthCode;
                    dst.EType = detail.ElementType;
                    dst.EWidth = detail.ElementWidth;
                    dst.RegLit = detail.RegLit;
                    dst.Modifier = detail.Modifier;
                    dst.Visibility = detail.Visibility;
                    dst.NonTerminal = detail.Rule;
                    dst.BitWidth = detail.BitWidth;
                    dst.GprWidth = detail.GrpWidth;
                    dst.SegInfo = detail.SegInfo;
                    dst.ECount = detail.ElementCount;
                    dst.SourceExpr = detail.SourceExpr;
                }
                return rows;
            }
        }
    }
}