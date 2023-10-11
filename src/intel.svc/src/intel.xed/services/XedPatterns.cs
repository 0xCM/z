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
    public static AsmOpCodeClass occlass(XedVexClass src)
        => src switch {
            XedVexClass.VV1 =>AsmOpCodeClass.Vex,
            XedVexClass.EVV => AsmOpCodeClass.Evex,
            XedVexClass.XOPV => AsmOpCodeClass.Xop,
            _ => AsmOpCodeClass.Legacy
        };
            
    [MethodImpl(Inline), Op]
    public static bool etype(in PatternOp src, out ElementType dst)
    {
        var result = first(src.Attribs, OpAttribKind.ElementType, out var attrib);
        if(result)
            dst = attrib.ToElementType();
        else
            dst = XedModels.ElementType.Empty;

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
        var result = XedPatterns.first(src.Attribs, OpAttribKind.Nonterminal, out var attrib);
        if(result)
            dst = attrib.ToNonTerm();
        else
            dst = Nonterminal.Empty;
        return result;
    }
}
