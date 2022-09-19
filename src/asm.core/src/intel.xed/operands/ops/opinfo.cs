//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using static XedModels;
    using static XedRules;

    partial class XedOps
    {
        public static PatternOpInfo opinfo(MachineMode mode, in PatternOp src)
        {
            var dst = PatternOpInfo.Empty;
            dst.Index = src.Index;
            dst.Kind = src.Kind;
            dst.Name = src.Name;
            var wc = OpWidthCode.INVALID;
            ref readonly var attribs = ref src.Attribs;
            nonterm(src, out dst.NonTerminal);
            visibility(src, out dst.Visibility);
            action(src, out dst.Action);
            modifier(src, out dst.Modifier);
            if(widthcode(src, out wc))
            {
                dst.WidthCode = wc;
                var w = width(mode,wc);
                dst.BitWidth = w.Bits;
                var wi = describe(wc);
                dst.SegType = wi.SegType;
                dst.ElementType = wi.ElementType;
                dst.ElementWidth = wi.ElementWidth;
            }

            var gpr = GprWidth.Empty;
            if(GprWidth.widths(dst.NonTerminal, out gpr))
                dst.GprWidth = gpr;
            else
                dst.GprWidth = GprWidth.Empty;

            if(src.RegLiteral(out dst.RegLit))
                dst.BitWidth = width(dst.RegLit);

            if(dst.BitWidth == 0 && gpr.IsNonEmpty && gpr.IsInvariant)
                dst.BitWidth = (ushort)gpr.InvariantWidth.Width;

            return dst;
        }
    }
}