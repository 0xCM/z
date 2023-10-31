//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;
using static XedRules;

public class XedInstRender
{
    const byte SectionWidth = 140;

    public const string LabelPattern = "{0,-18}{1}";

    public static readonly string FieldsHeader = "Fields".PadRight(18).PadRight(SectionWidth, Chars.Dash);

    public static readonly string OpsHeader = "Operands".PadRight(18).PadRight(SectionWidth, Chars.Dash);

    public static string descriptor(MachineMode mode, in PatternOp src)
    {
        const string RenderPattern = "{0,-6} {1,-3} {2,-10} {3,-12}";
        src.ElementType(out var et);
        src.WidthCode(out var w);
        var bw = XedWidths.width(mode,w).Bits;
        var wi = XedWidths.describe(w);
        if(XedPatterns.reglit(src, out RegExpr reg))
            bw = XedWidths.width(reg);

        var seg = EmptyString;
        if(wi.SegType.CellCount > 1)
        {
            var indicator = EmptyString;
            if(et.Indicator != 0)
                indicator = ((char)et.Indicator).ToString();
            seg = string.Format("{0}x{1}{2}x{3}n", wi.SegType.DataWidth, wi.SegType.CellWidth, indicator, wi.SegType.CellCount);
        }

        var _bw = bw.ToString();
        if(src.Nonterminal(out var nt))
        {
            if(GprWidth.width(nt, out var gpr))
                _bw = gpr.Format();
        }

        return string.Format(RenderPattern, XedRender.format(w), et, _bw, seg);
    }

    public static byte operands(InstPattern src, Span<string> dst, bool title = true)
    {
        const string RenderPattern = "{0,-2} {1,-14} {2,-4} {3,-4} {4} {5,-88} [{6}]";
        var k=z8;
        if(title)
            seek(dst,k++) = OpsHeader;

        ref readonly var ops = ref src.Ops;
        for(var j=0; j<ops.Count; j++)
        {
            ref readonly var op = ref ops[j];
            op.Action(out var action);
            op.Visibility(out var opvis);
            if(op.IsNonTerminal)
            {
                op.Nonterminal(out var nt);
                var uri = XedPaths.CheckedTableDef(nt, true, out var sig);
                seek(dst,k++) = (string.Format(RenderPattern,
                    op.Index,
                    XedRender.format(op.Name),
                    XedRender.format(action),
                    opvis.Code(),
                    descriptor(src.Mode, op),
                    string.Format("{0}::{1}", nt, uri),
                    op.SourceExpr
                    ));
            }
            else
                seek(dst,k++) = (string.Format(RenderPattern,
                    op.Index,
                    XedRender.format(op.Name),
                    XedRender.format(action),
                    opvis.Code(),
                    descriptor(src.Mode, op),
                    op.IsReg ? FormatRegLit(op) : EmptyString,
                    op.SourceExpr
                    ));
        }

        return k;
    }

    public static byte fields(InstPattern src, Span<string> dst, bool title = true)
    {
        const string Pattern = "{0,-2} {1,-14} {2}";

        var k=z8;
        if(title)
            seek(dst,k++) = FieldsHeader;

        for(var j=0; j<src.Cells.Count; j++)
        {
            ref readonly var field = ref src.Cells[j];
            var fk = XedRender.format(field.Field);
            if(field.IsLiteral)
                seek(dst,k++) = string.Format(Pattern, j, "Literal", field.Format());
            else
            {
                switch(field.CellKind)
                {
                    case RuleCellKind.EqExpr:
                    case RuleCellKind.NeqExpr:
                    case RuleCellKind.NtExpr:
                        seek(dst,k++) = string.Format(Pattern, j, fk, field.ToCellExpr());
                    break;
                    case RuleCellKind.NtCall:
                    {
                        var rule = field.AsNonterm();
                        if(rule.IsNonEmpty)
                        {
                            var uri = XedPaths.CheckedTableDef(rule, true, out var sig);
                            seek(dst,k++) = string.Format(Pattern, j, "Nonterm",  string.Format("{0}::{1}", rule.Format(), uri));
                        }
                        else
                            term.warn(string.Format("There is no rule for nonterminal {0}", rule));

                    }
                    break;
                    case RuleCellKind.FieldSeg:
                        seek(dst,k++) = string.Format(Pattern, j, fk, field.ToFieldSeg());
                    break;
                    case RuleCellKind.InstSeg:
                        seek(dst,k++) = string.Format(Pattern, j, fk, field.AsInstSeg());
                    break;
                    case RuleCellKind.SegVar:
                        seek(dst,k++) = string.Format(Pattern, j, fk, field.AsSegVar());
                    break;
                    default:
                        Errors.Throw(string.Format("Unhandled case: {0}", field.CellKind));
                    break;
                }
            }
        }
        return k;
    }

    static string FormatRegLit(in PatternOp src)
    {
        var dst = EmptyString;
        if(src.RegLiteral(out var reg))
            dst = reg.Format();
        return dst;
    }
}

