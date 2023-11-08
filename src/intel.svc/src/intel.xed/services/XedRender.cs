//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static XedRules;
using static AsmOpCodes;
using static sys;

using OC = XedModels.OpAttribKind;
using FTK = XedFormToken.TokenKind;

public class XedRender
{
    static EnumRender<Asm.FlagEffectKind> FlagEffects = new();

    static EnumRender<XedRegFlag> RegFlags = new();

    static EnumRender<ElementSize> ElementSizes = new();

    static EnumRender<DispWidth> DispWidthKinds = new();

    static EnumRender<VisibilityKind> VisKind = new();

    static EnumRender<VexValid> VexClasses = new();

    static EnumRender<XedVexKind> VexKinds = new();

    static EnumRender<VexMapKind> VexMap = new();

    static EnumRender<LegacyMapKind> LegacyMap = new();

    static EnumRender<EvexMapKind> EvexMap = new();

    static EnumRender<InstAttribKind> AttribKinds = new();

    static EnumRender<AsmOpCodeIndex> OcKindIndex = new();

    static EnumRender<OpKind> RuleOpKinds = new();

    static EnumRender<RuleMacroKind> MacroKinds = new();

    static EnumRender<OpModKind> OpModKinds = new();

    static EnumRender<FieldKind> FieldKinds = new();

    static EnumRender<RuleTableKind> RuleTableKinds = new();

    static EnumRender<EASZ> EaszKinds = new();

    static EnumRender<EOSZ> EoszKinds = new();

    static EnumRender<ExtensionKind> ExtensionKinds = new();

    static EnumRender<RoundingKind> RoundingKinds = new();

    static EnumRender<SMODE> SModes = new();

    static EnumRender<MaskReg> MaskCodes = new();

    static EnumRender<ChipCode> ChipCodes = new();

    static EnumRender<OperatorKind> RuleOps = new();

    static EnumRender<OpAction> OpActions = new();

    static EnumRender<WidthCode> OpWidthKinds = new();

    static EnumRender<ElementKind> ElementTypes = new();

    static EnumRender<XedModels.RepPrefix> RepPrexixKinds = new();

    static EnumRender<OpNameKind> OpNames = new();

    static EnumRender<OpVisibility> OpVis = new();

    static EnumRender<XedInstKind> Classes = new();

    static EnumRender<AsmVL> VexLengthKinds = new();

    static EnumRender<OSZ> OszKinds = new();

    static EnumRender<ASZ> AszKinds = new();

    static EnumRender<LLRC> LLRCKinds = new();

    static EnumRender<CategoryKind> CategoryKinds = new();

    static EnumRender<InstIsaKind> IsaKinds = new();

    static EnumRender<OpType> OpTypes = new();

    static EnumRender<HintKind> HintKinds = new();

    static EnumRender<ESRC> EsrcKinds = new();

    static readonly EnumRender<ModKind> ModIndicators = new();

    static EnumRender<XedRegId> XedRegs = new();

    static EnumRender<RuleName> RuleNames = new();

    static EnumRender<RuleCellKind> RuleCellKinds = new();

    public static void render(Index<OpSpec> src, ITextEmitter dst)
    {
        dst.AppendLineFormat(XedFieldRender.Columns, "Operands", EmptyString);
        dst.AppendLine(RP.PageBreak80);
        for(var i=0; i<src.Count; i++)
            dst.AppendLine(src[i].Format());
    }

    public static string format(XedFormToken src)
    {
        var dst = EmptyString;
        switch(src.Kind)
        {
            case FTK.InstClass:
                dst = src.InstClassValue().Format();
            break;
            case FTK.Hex8Lit:
                dst = src.Hex8Value().Format();
            break;
            case FTK.Hex16Lit:
                dst = src.Hex16Value().Format();
            break;
            default:
                dst = src.Value.Format();
            break;
        }
        return dst;
    }



    public static string format(Nonterminal src)
        => src.IsEmpty ? EmptyString : string.Format("{0}()", XedRender.format(src.Name));

    public static string format(Hex4 src)
        => $"0x{src}";

    public static string format(Hex8 src)
        => $"0x{src}";

    public static string format(Hex16 src)
        => $"0x{src}";

    public static string format(Hex32 src)
        => $"0x{src}";

    public static string format(Hex64 src)
        => $"0x{src}";

    public static string format(uint1 src)
        => "0b" + src.Format();

    public static string format(uint2 src)
        => "0b" + src.Format();

    public static string format(num2 src)
        => "0b" +  src.Bitstring();

    public static string format(num3 src)
        => "0b" +  src.Bitstring();

    public static string format(num4 src)
        => "0b" +  src.Bitstring();

    public static string format(uint4 src)
        => "0b" + src.Format();

    public static string format(uint5 src)
        => "0b" + src.Format();

    public static string format(uint6 src)
        => "0b" + src.Format();

    public static string format(uint7 src)
        => "0b" + src.Format();

    public static string format(uint8b src)
        => "0b" + src.Format();

    public static string format(byte src)
        => src.ToString();

    public static string format(ushort src)
        => src.ToString();

    public static string format(LogicClass src)
    {
        var dst = EmptyString;
        if(src.Kind == LogicKind.Antecedant)
            dst = "A";
        else if(src.Kind == LogicKind.Consequent)
            dst = "C";
        else if(src.Kind == LogicKind.Operator)
            dst = "B";
        return dst;
    }

    public static string format(LLRC src)
        => LLRCKinds.Format(src);

    public static string format(FlagEffectKind src)
        => FlagEffects.Format(src);

    public static string format(XedRegFlag src)
        => RegFlags.Format(src);

    public static string format(InstIsaKind src)
        => src == 0 ? EmptyString : IsaKinds.Format(src);

    public static string format(ESRC src)
        => EsrcKinds.Format(src);

    public static string format(ExtensionKind src)
        => src == 0 ? EmptyString : ExtensionKinds.Format(src);

    public static string format(CategoryKind src)
        => src == 0 ? EmptyString : CategoryKinds.Format(src);

    public static string format(OpWidth src)
        => src.Code != 0 ?  format(src.Code) : (src.Bits != 0 ? src.Bits.ToString() : EmptyString);

    public static string format(AsmOpCodeIndex src, DataFormatCode fc = DataFormatCode.Expr)
        => EnumRender.format(OcKindIndex, src, fc);

    public static string format(EASZ src, DataFormatCode fc = DataFormatCode.Expr)
        => fc == DataFormatCode.BitWidth ? nsize(src) : EnumRender.format(EaszKinds,src,fc);

    public static string format(EOSZ src, DataFormatCode fc = DataFormatCode.Expr)
        => fc == DataFormatCode.BitWidth ? nsize(src) : EnumRender.format(EoszKinds,src,fc);

    public static string format(SMODE src, DataFormatCode fc = DataFormatCode.Expr)
        => fc == DataFormatCode.BitWidth ? nsize((byte)src + 1) : EnumRender.format(SModes,src,fc);

    public static string format(VexValid src, DataFormatCode fc = DataFormatCode.Expr)
        => EnumRender.format(VexClasses, src, fc);

    public static string format(HintKind src, DataFormatCode fc = DataFormatCode.Expr)
        => EnumRender.format(HintKinds, src, fc);

    public static string format(XedVexKind src, DataFormatCode fc = DataFormatCode.Expr)
        => EnumRender.format(VexKinds, src, fc);

    public static string format(MaskReg src, DataFormatCode fc = DataFormatCode.Expr)
        => EnumRender.format(MaskCodes, src, fc);

    public static string format(XedModels.RepPrefix src, DataFormatCode fc = DataFormatCode.Expr)
        => EnumRender.format(RepPrexixKinds, src, fc);

    public static string format(AsmVL src, DataFormatCode fc = DataFormatCode.Expr)
        => fc == DataFormatCode.BitWidth ? XedWidths.width(src).ToString() : EnumRender.format(VexLengthKinds,src,fc);

    public static string format(ASZ src)
        => AszKinds.Format(src);

    public static string format(ElementSize src)
        => ElementSizes.Format(src);

    public static string format(OSZ src, DataFormatCode fc = DataFormatCode.BitWidth)
        => fc == DataFormatCode.BitWidth ? XedWidths.width(src).ToString() : EnumRender.format(OszKinds, src, fc);

    public static string format(DispWidth src)
        => DispWidthKinds.Format(src);

    public static string format(RuleName src)
        => RuleNames.Format(src);

    public static string format(ModKind src)
        => ModIndicators.Format(src);

    public static string format(OpCodeValue src)
        => OpCodeValue.format(src);

    public static string format(EvexMapKind src)
        => EvexMap.Format(src);

    public static string format(LegacyMapKind src)
        => LegacyMap.Format(src);

    public static string format(RuleTableKind src)
        => RuleTableKinds.Format(src);

    public static string format(FieldSeg src)
    {
        var dst = EmptyString;
        if(src.Field == 0)
            dst = src.Seg.Format();
        else
            dst = string.Format("{0}[{1}]", format(src.Field), src.Seg);
        return dst;
    }

    public static string format(FieldKind src)
        => src == 0 ? EmptyString : FieldKinds.Format(src);

    public static string format(RuleMacroKind src)
        => MacroKinds.Format(src);

    public static string format(InstAttribKind src)
        => AttribKinds.Format(src);

    public static string format(OpKind src)
        => RuleOpKinds.Format(src);

    public static string format(VisibilityKind src)
        => VisKind.Format(src);

    public static string format(Visibility src)
    {
        if(src.V0 != 0)
            return format(src.V0);
        else if(src.V1 != 0)
            return format(src.V1);
        else
            return EmptyString;
    }

    public static string format(RoundingKind src)
        => RoundingKinds.Format(src);

    public static string format(XedRegId src)
    {
        if(RuleKeyword.IsWildcard(src))
            return RuleKeyword.Wildcard.Format();
        else
            return XedRegs.Format(src);
    }

    public static string format(OpAction src)
        => OpActions.Format(src);

    public static string format(ChipCode src)
        => ChipCodes.Format(src);

    public static string format(XopMapKind src)
        => src == 0 ? EmptyString : src.ToString();

    public static string format(XedInstKind src)
        => Classes.Format(src);

    public static string format(RuleCellKind src)
        => RuleCellKinds.Format(src);

    public static string format(OpModKind src)
        => OpModKinds.Format(src);

    public static string format(VexMapKind src)
        => VexMap.Format(src);

    public static string format(WidthCode src)
        => src == 0 ? EmptyString : OpWidthKinds.Format(src);

    public static string format(OpType src)
        => OpTypes.Format(src);

    public char format(NumericIndicator src)
        => src switch
        {
            NumericIndicator.Float => 'f',
            NumericIndicator.Unsigned => 'u',
            NumericIndicator.Signed=> 'i',
            _ => '\0',
        };

    public static void describe(in XedDisasmDetailRow src, ITextEmitter dst)
    {
        const sbyte Pad = -XedFieldRender.ColWidth;
        var pattern = RP.slot(0,Pad) + " | " + RP.slot(1);

        dst.AppendLineFormat(pattern, nameof(src.InstructionId), src.InstructionId);
        dst.AppendLineFormat(pattern, nameof(src.Asm), src.Asm);
        dst.AppendLineFormat(pattern, nameof(src.Instruction), src.Instruction);
        dst.AppendLineFormat(pattern, nameof(src.Form), src.Form);
        dst.AppendLineFormat(pattern, nameof(src.Offsets), src.Offsets);
        dst.AppendLineFormat(pattern, nameof(src.OpCode), src.OpCode);
    }

    public static string format(Index<XedFlagEffect> src, bool embrace = true, char sep = Chars.Comma)
    {
        if(src.IsEmpty)
            return EmptyString;

        var dst = text.buffer();
        if(embrace)
            dst.Append(Chars.LBrace);
        for(var i=0; i<src.Count; i++)
        {
            if(i != 0)
                dst.Append(sep);

            dst.Append(format(src[i]));
        }
        if(embrace)
            dst.Append(Chars.RBrace);

        return dst.Emit();
    }

    public static string format(in XedFlagEffect src)
        => string.Format("{0}-{1}", format(src.Flag), format(src.Effect));

    public static string format(in OpAttribs src)
    {
        if(src.IsEmpty)
            return EmptyString;

        var dst = text.buffer();
        var count = src.Count;
        for(var i=0; i<count; i++)
        {
            if(i != 0)
                dst.Append(Chars.Colon);

            dst.Append(src[i].Format());
        }

        return dst.Emit();
    }

    public static string format(in InstOpDetail src)
    {
        var dst = text.buffer();
        dst.Append(format(src.Name));
        if(src.Attribs.IsNonEmpty)
            dst.Append(Chars.Colon);
        dst.Append(format(src.Attribs));
        return dst.Emit();
    }

    public static string format(in PatternOp src)
    {
        if(src.Kind == OpKind.Bcast)
        {
            src.Broadcast(out var kind);
            var def = asm.broadcast(kind);
            return def.Symbol.Format();
        }
        else
        {
            var dst = text.buffer();
            dst.Append(format(src.Name));
            if(src.Attribs.IsNonEmpty)
                dst.Append(Chars.Colon);
            dst.Append(format(src.Attribs));
            return dst.Emit();
        }
    }

    public static string format(OpAttrib src)
    {
        var dst = EmptyString;
        switch(src.Kind)
        {
            case OC.None:
                dst = EmptyString;
            break;

            case OC.Action:
                dst = format(src.ToAction());
            break;
            case OC.Width:
                dst = format(src.ToWidthCode());
            break;

            case OC.ElementType:
                dst = src.ToElementType().Format();
            break;

            case OC.Modifier:
                dst = src.ToModifier().Format();
            break;

            case OC.Scale:
                dst = src.ToScale().Format();
            break;

            case OC.Nonterminal:
                dst = src.ToNonTerm().Format();
            break;

            case OC.Visibility:
                dst = src.ToVisibility().Format();
            break;

            case OC.RegLiteral:
                dst = format(src.ToRegLiteral());
            break;

            default:
                Errors.Throw(string.Format("Unhandled class:{0}", src.Kind));
            break;
        }
        return dst;
    }

    public static string format(in MacroExpansion src)
    {
        if(src.Value.IsEmpty)
            return EmptyString;
        else if(src.Operator == 0)
            return format(src.Field);
        else
            return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), format(src.Value));
    }

    public static string format(in InstCells src)
    {
        var dst = text.buffer();
        render(src.Values, dst);
        return dst.Emit();
    }

    public static void render(ReadOnlySpan<CellValue> src, ITextBuffer dst)
    {
        for(var i=0; i<src.Length; i++)
        {
            if(i!=0)
                dst.Append(Chars.Space);

            dst.Append(format(skip(src,i)));
        }
    }

    public static string format(in OpDetails src)
    {
        var dst = text.buffer();
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var d = ref src[i];
            if(i==0)
                dst.AppendFormat("{0} |", d);
            else
                dst.AppendFormat("{0}| ", d);
        }

        return dst.Emit();
    }

    public static string format(OpNameKind src)
        => src == 0 ? EmptyString : OpNames.Format(src);

    public static string format(OperatorKind src)
        => RuleOps.Format(src);

    [MethodImpl(Inline)]
    public static string format(BroadcastKind src)
    {
        if(src == 0)
            return EmptyString;
        var bcasts = XedTables.Broadcasts;
        var index = (byte)src;
        if(index < bcasts.Length)
            return bcasts[index].Symbol.Format();
        else
            return RP.Error;
    }

    public static string format(in TableCriteria src)
    {
        var dst = text.buffer();
        dst.AppendLine(string.Format("{0}()", src.SigKey.TableName));
        dst.AppendLine(Chars.LBrace);
        var rows = src.Rows;
        for(var i=0; i<rows.Count; i++)
            dst.IndentLine(4, rows[i]);
        dst.AppendLine(Chars.RBrace);
        return dst.Emit();
    }

    public static string format(PointerWidth src)
        => src.Keyword.Format();

    public static string format(ElementType src)
        => src.IsEmpty ? EmptyString : ElementTypes.Format(src.Kind);

    public static string format(OpVisibility src)
        => OpVis.Format(src);

    public static string format(AsmOpCodeKind src)
        => format(AsmOpCodes.index(src));

    public static string format(in RuleKeyword src)
        => src.ToAsci().Format();

    public static string format(InstFieldSeg src)
        => src.IsEmpty
        ? EmptyString
        : string.Format("{0}[{1}]", format(src.Field), src.Type.Format());

    public static string format(in FieldValue src)
    {
        var dst = EmptyString;
        if(src.IsEmpty)
            return EmptyString;
        else if(src.IsNontermCall)
            return format(src.ToNonterm());
        else if(src.CellKind == RuleCellKind.SegVar)
            return src.ToSegVar().Format();
        else if(src.CellKind == RuleCellKind.WidthVar)
            return src.ToWidthVar().Format();
        else if(src.CellKind == RuleCellKind.Keyword)
            return format(src.ToKeyword());
        else if(src.CellKind == RuleCellKind.InstSeg)
            return format(src.ToInstSeg());
        else if(src.CellKind == RuleCellKind.FieldSeg)
            return format(src.ToSegField());
        else
            return XedCellRender.format(src);
    }

    public static string format(in CellExpr src)
    {
        var dst = EmptyString;
        var value = EmptyString;
        if(src.Value.IsNonterm)
            value = format(src.Value.ToNonterm());
        else
            value = format(src.Value);

        if(src.IsNonEmpty)
        {
            if(src.Field == 0)
                dst = value;
            else
                dst = string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), value);
        }
        return dst;
    }

    public static string format(SegVar src)
        => src.Format();

    public static string format(WidthVar src)
        => src.Format();

    static string atomic(in CellValue src)
    {
        Require.invariant(!src.IsExpr);
        var @class = src.CellKind;
        var dst = EmptyString;
        switch(@class)
        {
            case RuleCellKind.Void:
                break;
            case RuleCellKind.HexLit:
                dst = format(src.AsHexLit());
            break;
            case RuleCellKind.IntVal:
                dst = format(src.AsWord());
            break;
            case RuleCellKind.InstSeg:
                dst = format(src.AsInstSeg());
            break;
            case RuleCellKind.BitLit:
                dst = format5(src.AsBitLit());
            break;
            case RuleCellKind.NtCall:
                dst = format(src.AsNonterm());
            break;
            case RuleCellKind.Operator:
                dst = format(src.AsOperator().Kind);
            break;
            case RuleCellKind.Keyword:
                dst = format(src.ToKeyword());
            break;
            case RuleCellKind.FieldSeg:
                dst = format(src.ToFieldSeg());
            break;
            case RuleCellKind.SegVar:
                dst = src.AsSegVar().Format();
            break;
            case RuleCellKind.WidthVar:
                dst = src.AsWidthVar().Format();
            break;
            default:
                Errors.Throw(AppMsg.UnhandledCase.Format(@class.ToString()));
                break;
        }

        return dst;
    }

    static string expr(in CellValue src)
    {
        Require.invariant(src.IsExpr);
        return format(src.AsCellExpr());
    }

    public static string format(in CellValue src)
        => src.IsExpr ? expr(src) : atomic(src);

    public static string format(in MacroSpec src)
    {
        var dst = text.buffer();
        for(var i=0; i<src.Expansions.Count; i++)
        {
            ref readonly var x = ref src.Expansions[i];
            if(i!=0)
                dst.Append(Chars.Space);

            dst.Append(x.Format());
        }
        return dst.Emit();
    }

    public static string format(in RowCriteria src)
    {
        var dst = text.buffer();

        if(src.Antecedant.Count == 0)
            dst.Append(XedLiterals.Null);

        for(var i=0; i<src.Antecedant.Count; i++)
        {
            if(i!=0)
                dst.Append(Chars.Space);
            dst.Append(src.Antecedant[i].Data);
        }

        if(src.Consequent.Count != 0)
        {
            dst.AppendFormat(" {0} ", XedLiterals.Implication);

            for(var i=0; i<src.Consequent.Count; i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);
                dst.Append(src.Consequent[i].Data);
            }
        }
        return dst.Emit();
    }

    public static string format(InstAttribs src, bool embrace = true, char sep = Chars.Comma)
    {
        if(src.IsEmpty)
            return EmptyString;
        var dst = text.buffer();
        if(embrace)
            dst.Append(Chars.LBrace);
        for(var i=0; i<src.Count; i++)
        {
            if(i != 0)
                dst.Append(sep);
            dst.Append(format(src[i]));
        }
        if(embrace)
            dst.Append(Chars.RBrace);
        return dst.Emit();
    }

    public static string format(in RuleNames src, char sep = Chars.Comma)
    {
        var dst = text.buffer();
        var counter = 0u;
        for(var i=0; i<XedRules.RuleNames.MaxCount; i++)
        {
            var kind = (RuleName)i;
            if(src.Contains(kind))
            {
                if(counter != 0)
                    dst.Append(sep);
                dst.Append(XedRender.format(kind));
                counter++;
            }
        }
        return dst.Emit();
    }

    public static string format(in FieldSet src, char sep = Chars.Comma)
    {
        var dst = text.buffer();
        Span<FieldKind> kinds = stackalloc FieldKind[FieldSet.Capacity];
        var count = src.Members(kinds);
        for(var i=0; i<count; i++)
        {
            if(i != 0)
                dst.Append(sep);
            dst.Append(XedRender.format(skip(kinds,i)));
        }
        return dst.Emit();
    }

    static string format5(uint5 src)
    {
        var storage = 0ul;
        var dst = recover<AsciSymbol>(bytes(storage));
        var i=0;
        var j=(byte)(uint5.Width - 1);
        seek(dst,i++) = Chars.D0;
        seek(dst,i++) = Chars.b;
        seek(dst,i++) = src[j--].ToChar();
        seek(dst,i++) = src[j--].ToChar();
        seek(dst,i++) = src[j--].ToChar();
        seek(dst,i++) = src[j--].ToChar();
        seek(dst,i++) = Chars.Underscore;
        seek(dst,i++) = src[j].ToChar();
        return new asci8(storage);
    }

    public static string format(in EncodingExtract src)
    {
        const string RP0 = "{0,-8} | {1,-5} | {2,-5} | {3,-12} | {4,-12}";
        const string RP1 = "{0,-8} | {1,-5} | {2,-5} | {3,-12} | {4,-12} | {5,-5}";
        var pattern = src.Offsets.HasImm1 ? RP1 : RP0;
        var header = string.Format(pattern, nameof(src.OpCode), nameof(src.ModRm), nameof(src.Sib), nameof(src.Imm), nameof(src.Disp), nameof(src.Imm1));
        var content = string.Format(pattern,
            XedRender.format(src.OpCode),
            src.Offsets.HasModRm ? src.ModRm.Format() : EmptyString,
            src.Offsets.HasSib ? src.Sib.Format() : EmptyString,
            src.Offsets.HasImm0 ? src.Imm.Format() : EmptyString,
            src.Offsets.HasDisp ? src.Disp.Format() : EmptyString,
            src.Offsets.HasImm1 ? src.Imm1.Format() : EmptyString
            );
        return string.Format("{0}{1}{2}",header, Chars.Eol, content);
    }

    static string nsize<T>(T src)
        => ((NativeSize)((NativeSizeCode)u8(src))).Format();
}
