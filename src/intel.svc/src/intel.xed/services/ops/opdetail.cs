//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedModels;
    using static XedRules;

    partial class XedOps
    {
        public static Index<InstOpDetail> opdetails(InstPattern src)
        {
            ref readonly var ops = ref src.Ops;
            var count = (byte)ops.Count;
            var dst = alloc<InstOpDetail>(count);
            for(var j=0; j<count; j++)
                seek(dst,j) = opdetail(src, count, ops[j]);
            return dst;
        }

        public static InstOpDetail opdetail(InstPattern pattern, byte opcount, in PatternOp op)
        {
            ref readonly var fields = ref pattern.Cells;
            var info = opinfo(pattern.Mode,op);
            var wcode = info.WidthCode;
            var dst = InstOpDetail.Empty;
            dst.Pattern = op.PatternId;
            Require.nonzero(pattern.InstClass.Kind);
            dst.InstClass = pattern.InstClass;
            dst.OpCode = pattern.OpCode;
            dst.Mode = pattern.Mode;
            dst.Lock = InstCells.@lock(fields);
            dst.Mod = InstCells.mod(fields);
            dst.RexW = InstCells.rexw(fields);
            dst.Rep = InstCells.rep(fields);
            dst.Attribs = op.Attribs;
            dst.OpCount = opcount;
            dst.Index = info.Index;
            dst.Name = info.Name;
            dst.Kind = info.Kind;
            dst.Action = info.Action;
            dst.WidthCode = wcode;
            dst.GrpWidth = info.GprWidth;
            dst.Scalable = info.GprWidth.IsScalable;
            dst.ElementType = info.ElementType;
            dst.ElementWidth = info.ElementWidth;
            dst.RegLit = info.RegLit;
            dst.Modifier = info.Modifier;
            dst.Visibility = info.Visibility;
            dst.Rule = info.NonTerminal;
            dst.BitWidth = info.BitWidth;
            if(wcode !=0)
            {
                dst.SegInfo =  Xed.describe(wcode).SegType;
                dst.ElementCount = dst.SegInfo.CellCount;
            }
            if(info.RegLit.IsNonEmpty && dst.BitWidth == 0)
            {
                var regop = XedRegMap.map(info.RegLit);
                if(regop.IsNonEmpty)
                    dst.BitWidth = (ushort)regop.Size.Width;
            }

            var expr = op.SourceExpr.Value;
            var exprFmt = op.SourceExpr.Format();
            Demand.lteq(text.quote(exprFmt), exprFmt.Length, asci64.Size);
            dst.SourceExpr = expr;
            return dst;
        }
    }
}