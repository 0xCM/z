//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

using static XedModels;
using static XedRender;
using static XedRules;

public partial class XedPatterns : AppService<XedPatterns>
{
    public IEnumerable<Nonterminal> nonterminals(PatternOps src)
    {
        var storage = sys.alloc<byte>(32);
        for(var i=0; i<src.Count; i++)
        {
            var op = src[i];
            if(op.Nonterminal(out var nt))
                yield return nt;
        }
    }

    public static AsmOpCodeClass occlass(XedVexClass src)
        => src switch {
            XedVexClass.VV1 =>AsmOpCodeClass.Vex,
            XedVexClass.EVV => AsmOpCodeClass.Evex,
            XedVexClass.XOPV => AsmOpCodeClass.Xop,
            _ => AsmOpCodeClass.Legacy
        };

    [MethodImpl(Inline), Op]
    public static bool scale(in PatternOp src, out MemoryScale dst)
    {
        var result = first(src.Attribs, OpAttribKind.Scale, out var attrib);
        if(result)
            dst = attrib.ToScale();
        else
            dst = default;
        return result;
    }

    public static PatternOpInfo opinfo(MachineMode mode, in PatternOp src)
    {
        var dst = PatternOpInfo.Empty;
        dst.Index = src.Index;
        dst.Kind = src.Kind;
        dst.Name = src.Name;
        var wc = WidthCode.INVALID;
        ref readonly var attribs = ref src.Attribs;
        nonterm(src, out dst.NonTerminal);
        visibility(src, out dst.Visibility);
        action(src, out dst.Action);
        modifier(src, out dst.Modifier);
        if(widthcode(src, out wc))
        {
            dst.WidthCode = wc;
            var w = XedWidths.width(mode,wc);
            dst.BitWidth = w.Bits;
            var wi = XedWidths.describe(wc);
            dst.SegType = wi.SegType;
            dst.ElementType = wi.ElementType;
            dst.ElementWidth = wi.ElementWidth;
        }

        var gpr = GprWidth.Empty;
        if(GprWidth.width(dst.NonTerminal, out gpr))
            dst.GprWidth = gpr;
        else
            dst.GprWidth = GprWidth.Empty;

        if(src.RegLiteral(out dst.RegLit))
            dst.BitWidth = XedWidths.width(dst.RegLit);

        if(dst.BitWidth == 0 && gpr.IsNonEmpty && gpr.IsInvariant)
            dst.BitWidth = (ushort)gpr.InvariantWidth.Width;

        return dst;
    }    

    public static Index<InstOpDetail> opdetails(InstPattern src)
    {
        ref readonly var ops = ref src.Ops;
        var count = (byte)ops.Count;
        var dst = alloc<InstOpDetail>(count);
        for(var j=0; j<count; j++)
            seek(dst,j) = opdetail(src, count, ops[j]);
        return dst;
    }

    public static ReadOnlySeq<InstOpDetail> opdetails(ReadOnlySeq<InstPattern> src)
    {
        var buffer = list<InstOpDetail>();
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var pattern = ref src[i];
            ref readonly var ops = ref pattern.Ops;
            var count = (byte)ops.Count;
            for(var j=0; j<count; j++)
                buffer.Add(opdetail(pattern, count, ops[j]));
        }

        return buffer.ToArray().Sort(new PatternOrder());
    }

    public static InstOpDetail opdetail(InstPattern pattern, byte opcount, in PatternOp op)
    {
        ref readonly var fields = ref pattern.Cells;
        var info = opinfo(pattern.Mode,op);
        var wcode = info.WidthCode;
        var dst = InstOpDetail.Empty;
        dst.Pattern = pattern.PatternId;
        Require.nonzero(pattern.InstClass.Kind);
        dst.InstClass = pattern.InstClass;
        dst.InstForm = pattern.InstForm;
        dst.OpCode = pattern.OpCode;
        dst.Mode = pattern.Mode;
        dst.Lock = XedCells.@lock(fields);
        dst.Mod = XedCells.mod(fields);
        dst.RexW = XedCells.rexw(fields);
        dst.Rep = XedCells.rep(fields);
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
            dst.SegInfo =  XedWidths.describe(wcode).SegType;
            dst.ElementCount = dst.SegInfo.CellCount;
        }
        if(info.RegLit.IsNonEmpty && dst.BitWidth == 0)
        {
            var regop = XedPatterns.regop(info.RegLit);
            if(regop.IsNonEmpty)
                dst.BitWidth = (ushort)regop.Size.Width;
        }

        var expr = op.SourceExpr.Value;
        var exprFmt = op.SourceExpr.Format();
        Demand.lteq(text.quote(exprFmt), exprFmt.Length, asci64.Size);
        dst.SourceExpr = expr;
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static bool etype(in PatternOp src, out ElementType dst)
    {
        var result = first(src.Attribs, OpAttribKind.ElementType, out var attrib);
        if(result)
            dst = attrib.ToElementType();
        else
            dst = ElementType.Empty;

        return result;
    }

    [MethodImpl(Inline), Op]
    public static bool first(in OpAttribs src, OpAttribKind @class, out OpAttrib dst)
    {
        var result = false;
        dst = OpAttrib.Empty;
        var count = src.Count;
        for(var i=0; i<count; i++)
        {
            ref readonly var a = ref src[i];
            if(a.Kind == @class)
            {
                dst = a;
                result = true;
                break;
            }
        }
        return result;
    }

    [MethodImpl(Inline), Op]
    public static bool exists(in OpAttribs src, OpAttribKind @class)
    {
        var result = false;
        var count = src.Count;
        for(var i=0; i<count; i++)
        {
            ref readonly var a = ref src[i];
            if(a.Kind == @class)
            {
                result = true;
                break;
            }
        }
        return result;
    }

    [MethodImpl(Inline), Op]
    public static bool exists(ReadOnlySpan<PatternOp> src, OpAttribKind @class)
    {
        var result = false;
        for(var i=0; i<src.Length; i++)
        {
            result = exists(skip(src,i).Attribs, @class);
            if(result)
                break;
        }
        return result;
    }

    public static string specifier(in OpSpec src)
    {
        const string Pattern = "/{0}";
        var dst = text.buffer();
        dst.AppendFormat("{0}", src.Index);
        dst.AppendFormat(Pattern, format(src.Name));
        dst.AppendFormat(Pattern, format(src.Action));
        dst.AppendFormat(Pattern, format(src.WidthCode));
        dst.AppendFormat(Pattern, format(src.Visibility));
        dst.AppendFormat(Pattern, format(src.OpType));
        if(src.Rule.IsNonEmpty)
            dst.AppendFormat(Pattern, src.Rule.Name.ToString().ToUpper());
        else if(src.ElementType.IsNumber)
            dst.AppendFormat(Pattern, src.ElementType);

        return dst.Emit();
    }

    [MethodImpl(Inline), Op]
    public static bool action(in PatternOp src, out OpAction dst)
    {
        var result = first(src.Attribs, OpAttribKind.Action, out var attrib);
        if(result)
            dst = attrib.ToAction();
        else
            dst = default;

        return result;
    }

    [MethodImpl(Inline), Op]
    public static bool modifier(in PatternOp src, out OpModifier dst)
    {
        if(first(src.Attribs, OpAttribKind.Modifier, out var attrib))
            dst = attrib.ToModifier();
        else
            dst = default;
        return true;
    }    

    [MethodImpl(Inline), Op]
    public static bool visibility(in PatternOp src, out Visibility dst)
    {
        if(first(src.Attribs, OpAttribKind.Visibility, out var attrib))
            dst = attrib.ToVisibility();
        else
            dst = OpVisibility.Explicit;
        return true;
    }


    [MethodImpl(Inline), Op]
    public static bool widthcode(in PatternOp src, out WidthCode dst)
    {
        var result = first(src.Attribs, OpAttribKind.Width, out var attrib);
        if(result)
            dst= attrib.ToWidthCode();
        else
            dst = WidthCode.INVALID;;
        return result;
    }

    [MethodImpl(Inline)]
    public static bool reglit(in PatternOp src, out Register dst)
    {
        var result = first(src.Attribs, OpAttribKind.RegLiteral, out var attrib);
        if(result)
            dst = attrib.ToRegLiteral();
        else
            dst = Register.Empty;
        return result;
    }

    [MethodImpl(Inline), Op]
    public static bool broadcast(in PatternOp src, out BroadcastKind dst)
    {
        dst = 0;
        if(src.Kind == OpKind.Bcast)
            if(XedParsers.parse(src.SourceExpr, out dst))
                return true;
        return false;
    }

    [MethodImpl(Inline), Op]
    public static bool nonterm(in PatternOp src, out Nonterminal dst)
    {
        var result = first(src.Attribs, OpAttribKind.Nonterminal, out var attrib);
        if(result)
            dst = attrib.ToNonTerm();
        else
            dst = Nonterminal.Empty;
        return result;
    }
}
