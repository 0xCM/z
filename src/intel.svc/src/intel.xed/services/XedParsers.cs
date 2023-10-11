//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static XedRules;
using static XedZ;
using static sys;

using R = XedRules;
using RFK = XedRules.FieldKind;

public partial class XedParsers
{
    static readonly EnumParser<WidthCode> OpWidthParser = new();

    static readonly EnumParser<OpAction> OpActions = new();

    static readonly EnumParser<MmxRegId> MmxRegs = new();

    static readonly EnumParser<OpType> OpTypes = new();

    static readonly EnumParser<PointerWidthKind> PointerWidths = new();

    static readonly EnumParser<XedRegId> Regs = new();

    static readonly EnumParser<ElementKind> ElementKinds = new();

    static readonly EnumParser<ElementSize> ElementSizes = new();

    static readonly EnumParser<OpVisibility> OpVisKinds = new();

    static readonly EnumParser<VisibilityKind> VisKinds = new();

    static readonly EnumParser<OpModKind> OpModKinds = new();

    static readonly EnumParser<FieldKind> FieldKinds = new();

    static readonly EnumParser<FpuRegId> FpuRegs = new();

    static readonly EnumParser<XedInstKind> Classes = new();

    static readonly EnumParser<XedFormType> Forms = new();

    static readonly EnumParser<DispWidth> DispWidths = new();

    static readonly EnumParser<ExtensionKind> ExtensionKinds = new();

    static readonly EnumParser<FlagEffectKind> FlagActionKinds = new();

    static readonly EnumParser<XedRegFlag> RegFlags = new();

    static readonly EnumParser<InstIsaKind> IsaKinds = new();

    static readonly EnumParser<CategoryKind> CategoryKinds = new();

    static readonly EnumParser<OpNameKind> RuleOpNames = new();

    static readonly EnumParser<RuleMacroKind> MacroKinds = new();

    static readonly EnumParser<XedVexClass> VexClasses = new();

    static readonly EnumParser<XedVexKind> VexKinds = new();

    static readonly EnumParser<AsmOpCodeKind> OpCodeKinds = new();

    static readonly EnumParser<ErrorKind> ErrorKinds = new();

    static readonly EnumParser<ChipCode> ChipCodes = new();

    static readonly EnumParser<EASZ> EaszKinds = new();

    static readonly EnumParser<EOSZ> EoszKinds = new();

    static readonly EnumParser<ASZ> AszKinds = new();

    static readonly EnumParser<OSZ> OszKinds = new();

    static readonly EnumParser<RoundingKind> RoundingKinds = new();

    static readonly EnumParser<SMODE> SModes = new();

    static readonly EnumParser<RuleName> RuleNames = new();

    static XedParsers Instance = new();

    static ConcurrentDictionary<string,RuleName> NontermUppers
        = uppers();

    static ConcurrentDictionary<string,RuleName> uppers()
    {
        var dst = cdict<string,RuleName>();
        var kinds =  Symbols.index<RuleName>().Kinds;
        for(var i=0; i<kinds.Length; i++)
        {
            ref readonly var kind = ref skip(kinds,i);
            dst.TryAdd(kind.ToString().ToUpper(), kind);
        }
        return dst;
    }

    XedParsers()
    {

    }

    public static bool parse(RFK field, string value, out FieldValue dst)
    {
        var result = true;
        dst = FieldValue.Empty;
        switch(field)
        {
            case RFK.AGEN:
            case RFK.AMD3DNOW:
            case RFK.ASZ:
            case RFK.CET:
            case RFK.CLDEMOTE:
            case RFK.DF32:
            case RFK.DF64:
            case RFK.DUMMY:
            case RFK.ENCODER_PREFERRED:
            case RFK.ENCODE_FORCE:
            case RFK.HAS_MODRM:
            case RFK.HAS_SIB:
            case RFK.ILD_F2:
            case RFK.ILD_F3:
            case RFK.IMM0:
            case RFK.IMM0SIGNED:
            case RFK.IMM1:
            case RFK.LOCK:
            case RFK.LZCNT:
            case RFK.MEM0:
            case RFK.MEM1:
            case RFK.MODE_FIRST_PREFIX:
            case RFK.MODE_SHORT_UD0:
            case RFK.MODEP5:
            case RFK.MODEP55C:
            case RFK.MPXMODE:
            case RFK.MUST_USE_EVEX:
            case RFK.NEEDREX:
            case RFK.NEED_SIB:
            case RFK.NOREX:
            case RFK.NO_RETURN:
            case RFK.NO_SCALE_DISP8:
            case RFK.REX:
            case RFK.OSZ:
            case RFK.OUT_OF_BYTES:
            case RFK.P4:
            case RFK.PREFIX66:
            case RFK.PTR:
            case RFK.REALMODE:
            case RFK.RELBR:
            case RFK.TZCNT:
            case RFK.UBIT:
            case RFK.USING_DEFAULT_SEGMENT0:
            case RFK.USING_DEFAULT_SEGMENT1:
            case RFK.VEX_C4:
            case RFK.VEXDEST3:
            case RFK.VEXDEST4:
            case RFK.WBNOINVD:
            case RFK.REXRR:
            case RFK.SAE:
            case RFK.BCRC:
            case RFK.ZEROING:
            {
                if(parse(value, out bit b))
                {
                    dst = new(field, b);
                    result = true;
                }
            }
            break;

            case RFK.REXW:
            {
                if(parse(value, out bit b))
                {
                    dst = new (field, b);
                    result = true;
                }
                else if(value.Length == 1 && value[0] == 'w')
                {
                    dst = new (FieldSeg.symbolic(field, 'w'));
                    result = true;
                }
            }
            break;
            case RFK.REXR:
            {
                if(parse(value, out bit x))
                {
                    dst = new (field,x);
                    result = true;
                }
                else if(value.Length == 1 && value[0] == 'r')
                {
                    dst = new (FieldSeg.symbolic(field, 'r'));
                    result = true;
                }
            }
            break;
            case RFK.REXX:
            {
                if(parse(value, out bit x))
                {
                    dst = new (field,x);
                    result = true;
                }
                else if(value.Length == 1 && value[0] == 'x')
                {
                    dst = new (FieldSeg.symbolic(field, 'x'));
                    result = true;
                }
            }
            break;
            case RFK.REXB:
            {
                if(parse(value, out bit x))
                {
                    dst = new (field, x);
                    result = true;
                }
                else if(value.Length == 1 && value[0] == 'b')
                {
                    dst = new (FieldSeg.symbolic(field, 'b'));
                    result = true;
                }
            }
            break;

            case RFK.NELEM:
            case RFK.ELEMENT_SIZE:
            case RFK.MEM_WIDTH:
            {
                if(ushort.TryParse(value, out ushort x))
                {
                    dst = new (field,x);
                    result = true;
                }
            }
            break;

            case RFK.SIBBASE:
            case RFK.HINT:
            case RFK.ROUNDC:
            case RFK.SEG_OVD:
            case RFK.VEXVALID:
            case RFK.MOD:
            case RFK.SIBSCALE:
            case RFK.EASZ:
            case RFK.EOSZ:
            case RFK.FIRST_F2F3:
            case RFK.LAST_F2F3:
            case RFK.DEFAULT_SEG:
            case RFK.MODE:
            case RFK.REP:
            case RFK.SMODE:
            case RFK.VEX_PREFIX:
            case RFK.VL:
            case RFK.LLRC:
            case RFK.MAP:
            case RFK.SCALE:
            case RFK.BRDISP_WIDTH:
            case RFK.DISP_WIDTH:
            case RFK.ILD_SEG:
            case RFK.IMM1_BYTES:
            case RFK.IMM_WIDTH:
            case RFK.MAX_BYTES:
            case RFK.MODRM_BYTE:
            case RFK.NPREFIXES:
            case RFK.NREXES:
            case RFK.NSEG_PREFIXES:
            case RFK.POS_DISP:
            case RFK.POS_IMM:
            case RFK.POS_IMM1:
            case RFK.POS_MODRM:
            case RFK.POS_NOMINAL_OPCODE:
            case RFK.POS_SIB:
            case RFK.NEED_MEMDISP:
            case RFK.RM:
            case RFK.SIBINDEX:
            case RFK.REG:
            case RFK.VEXDEST210:
            case RFK.MASK:
            case RFK.SRM:
            {
                if(parse(value, out byte b))
                {
                    dst = new (field,b);
                    result = true;
                }
            }
            break;

            case RFK.ESRC:
            {
                if(HexParser.parse(value, out Hex4 x))
                {
                    dst = new (field,(byte)x);
                    result = true;
                }
            }
            break;


            case RFK.NOMINAL_OPCODE:
            {
                if(HexParser.parse(value, out Hex8 x))
                {
                    dst = new (field, x);
                    result = true;
                }
            }
            break;

            case RFK.DISP:
            case RFK.UIMM0:
            case RFK.UIMM1:
            {
                result = byte.TryParse(value, out var b);
                if(result)
                    dst = new (field,b);
                else
                {
                    if(IsSeg(value))
                    {
                        if(segdata(value, out var sd))
                        {
                            var type = InstSegTypes.type(sd);
                            if(type.IsNonEmpty)
                                dst = new (field,type);
                            else
                                Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldValue), value));
                        }
                    }
                }
            }
            break;

            case RFK.BASE0:
            case RFK.BASE1:
            case RFK.INDEX:
            case RFK.OUTREG:
            case RFK.SEG0:
            case RFK.SEG1:
            case RFK.REG0:
            case RFK.REG1:
            case RFK.REG2:
            case RFK.REG3:
            case RFK.REG4:
            case RFK.REG5:
            case RFK.REG6:
            case RFK.REG7:
            case RFK.REG8:
            case RFK.REG9:
            {
                if(reg(field, value, out dst))
                    result = true;
            }
            break;
            case RFK.CHIP:
            {
                if(parse(value, out ChipCode x))
                {
                    dst = new (field, (ushort)x);
                    result = true;
                }
            }
            break;

            case RFK.ERROR:
            {
                if(parse(value, out ErrorKind x))
                {
                    dst = new (field, (ushort)x);
                    result = true;
                }
            }
            break;

            case RFK.ICLASS:
            {
                if(parse(value, out XedInstKind x))
                {
                    dst = new (field, (ushort)x);
                    result = true;
                }
            }
            break;

            case RFK.BCAST:
            {
                if(parse(value, out BroadcastKind kind))
                {
                    dst = new (field, (byte)kind);
                    result = true;
                }
            }
            break;
        }

        return result;
    }

    public static bool parse(string src, out InstAttribs dst)
    {
        dst = InstAttribs.Empty;

        var input = text.trim(src);
        if(empty(input))
            return false;

        var sep = ',';
        if(input.Contains(Chars.Colon))
            sep = ':';
        else if(input.Contains(Chars.Space))
            sep = ' ';
        if(Fenced.test(input, Fenced.Embraced))
        {
            if(input.Length > 2)
                input = Fenced.unfence(input, Fenced.Embraced);
            else
                input = EmptyString;
        }

        if(empty(input))
            return false;

        var parts = input.SplitClean(sep);
        var count = parts.Length;
        if(count == 0)
            return default;

        var counter = 0u;
        var _dst = span<InstAttrib>(count);
        for(var i=0; i<count; i++)
        {
            ref var target = ref seek(_dst,i);
            var result = DataParser.eparse(skip(parts,i), out target);
            if(result)
            {
                if(target.IsNonEmpty)
                    counter++;
            }
            else
                return false;
        }

         dst = slice(_dst,0,counter).ToArray();

        return dst.IsNonEmpty;
    }


    public static bool IsEq(string src)
        => !src.Contains("!=") && src.Contains("=");

    public static bool IsNe(string src)
        => src.Contains("!=");

    public static bool IsImpl(string src)
        => src.Contains("=>");

    public static bool IsExpr(string src)
        => IsEq(src) || IsNe(src);

    public static bool IsSeg(string src)
    {
        var i = text.index(src, Chars.LBracket);
        var j = text.index(src, Chars.RBracket);
        return i> 0 && j > i;
    }

    public static bool parse(string src, out RuleName dst)
    {
        dst = Nonterminal.Empty;
        var input = text.trim(src.Remove(":").Remove("()"));
        var result = RuleNames.Parse(input, out RuleName rule);
        if(result)
            dst = rule;
        else
        {
            result = NontermUppers.TryGetValue(input.ToUpper(), out rule);
            if(result)
                dst = rule;
        }
        return result;
    }

    public static bool parse(string src, out OpType dst)
        => OpTypes.Parse(src, out dst);

 
    public static void parse(string src, out Index<XedFlagEffect> dst)
    {
        var i = text.index(src,Chars.LBracket);
        var j = text.index(src,Chars.RBracket);
        var buffer = sys.empty<XedFlagEffect>();
        if(i >=0 && j>1)
        {
            var specs = text.split(text.despace(text.inside(src,i,j)), Chars.Space);
            var count = specs.Length;
            buffer = alloc<XedFlagEffect>(count);
            for(var k=0; k<count; k++)
            {
                ref readonly var spec = ref skip(specs,k);
                var m = text.index(spec,Chars.Dash);
                if(m>0)
                {
                    var name = text.left(spec, m);
                    var action = text.right(spec,m);
                    if(parse(name, out XedRegFlag flag) && parse(action, out FlagEffectKind ak))
                        seek(buffer,k) = new XedFlagEffect(flag, ak);
                }
            }
        }

        dst = buffer;
    }

    public static bool parse(string src, out Imm8 dst)
        => Imm8.parse(src, out dst);

    public static bool parse(string src, out Imm64 dst)
        => Imm64.parse(src, out dst);

    public static bool IsNonterm(string src)
        => text.trim(text.remove(src,Chars.Colon)).EndsWith("()");

    public static bool IsHexLiteral(string src)
        => text.begins(src, HexFormatSpecs.PreSpec);

    public static bool IsBinaryLiteral(string src)
        => text.begins(src, "0b");

    public static bool IsInt(string src)
        => ushort.TryParse(src, out _);

    public static bool parse(string src, out bit dst)
        => BitParser.parse(src, out dst);

    public static bool parse(string src, out ChipCode dst)
        => ChipCodes.Parse(src, out dst);

    public static bool parse(string src, out RoundingKind dst)
        => RoundingKinds.Parse(src, out dst);

    public static bool parse(string src, out ElementSize dst)
        => ElementSizes.Parse(src, out dst);

    public static bool parse(string src, out Disp64 dst)
        => Disp.parse(src, out dst);

    public static bool parse(string src, out ErrorKind dst)
        => ErrorKinds.Parse(text.remove(text.trim(src), "XED_ERROR_"), out dst);

    public static bool parse(string src, out XedVexKind dst)
        => VexKinds.Parse(src, out dst);

    public static bool parse(string src, out DispWidth dst)
        => DispWidths.Parse(src, out dst);

    public static bool parse(string src, out EASZ dst)
        => EaszKinds.Parse(src, out dst);

    public static bool parse(string src, out EOSZ dst)
        => EoszKinds.Parse(src, out dst);

    public static bool parse(string src, out ASZ dst)
        => AszKinds.Parse(src, out dst);

    public static bool parse(string src, out OSZ dst)
        => OszKinds.Parse(src, out dst);

    public static bool parse(string src, out uint1 dst)
    {
        if(IsBinaryLiteral(src))
            return BitNumbers.parse(src, out dst);
        else
        {
            dst = default;
            return false;
        }
    }

    public static bool parse(string src, out uint2 dst)
    {
        if(IsBinaryLiteral(src))
            return BitNumbers.parse(src, out dst);
        else
        {
            dst = default;
            return false;
        }
    }

    public static bool parse(string src, out uint3 dst)
    {
        if(IsBinaryLiteral(src))
            return BitNumbers.parse(src, out dst);
        else
        {
            dst = default;
            return false;
        }
    }

    public static bool parse(string src, out uint4 dst)
    {
        if(IsBinaryLiteral(src))
        {
            return BitNumbers.parse(src, out dst);
        }
        else
        {
            dst = default;
            return false;
        }
    }

    public static bool parse(string src, out uint5 dst)
    {
        if(IsBinaryLiteral(src))
            return BitNumbers.parse(src, out dst);
        else
        {
            dst = default;
            return false;
        }
    }

    public static bool bitnumber(string src, out byte n, out byte number)
    {
        n = 0;
        number = 0;
        if(!parse(src, out uint5 value))
            return false;

        var len = src.Length - 2;
        switch(len)
        {
            case 1:
                number = (uint1)value;
                n = (byte)len;
            break;
            case 2:
                number = (uint2)value;
                n = (byte)len;
            break;
            case 3:
                number = (uint3)(byte)value;
                n = (byte)len;
            break;
            case 4:
                number = (uint4)(byte)value;
                n = (byte)len;
            break;
            case 5:
                number = value;
                n = (byte)len;
            break;
        }

        return n != 0;
    }

    public static bool segdata(string src, out string dst)
    {
        var i = text.index(src, Chars.LBracket);
        var j = text.index(src, Chars.RBracket);
        var result = i>0 && j>i;
        if(result)
            dst = text.inside(src,i,j);
        else
            dst = EmptyString;
        return result;
    }

    public static bool parse(string src, out RuleMacroKind dst)
        => MacroKinds.Parse(src, out dst);

    public static bool parse(string src, out VisibilityKind dst)
        => VisKinds.Parse(src, out dst);

    public static bool parse(string src, out Visibility dst)
    {
        if(parse(src, out OpVisibility ov))
        {
            dst = ov;
            return true;
        }
        else if(parse(src, out VisibilityKind vk))
        {
            dst = vk;
            return true;
        }
        else
        {
            dst = default;
            return false;
        }
    }

    public static bool parse(string src, out uint8b dst)
    {
        if(IsBinaryLiteral(src))
            return BitNumbers.parse(src, out dst);
        else
        {
            dst = default;
            return false;
        }
    }

    public static bool parse(string src, out Hex8 dst)
    {
        if(IsHexLiteral(src))
            return HexParser.parse(src, out dst);
        dst = default;
        return false;
    }

    public static bool parse(string src, out SegVar dst)
    {
        dst = SegVar.parse(src);
        return true;
    }

    public static bool parse(string src, out WidthVar v)
        => WidthVar.parse(src, out v);

    public static bool parse(string src, out Hex16 dst)
    {
        if(IsHexLiteral(src))
            return HexParser.parse(src, out dst);
        dst = default;
        return false;
    }

    public static bool parse(string src, out AsmOpCodeKind dst)
        => Instance.Parse(src, out dst);

    public static bool parse(string src, out OpModKind dst)
        => OpModKinds.Parse(src, out dst);

    public static bool parse(string src, out OpNameKind dst)
        => RuleOpNames.Parse(src, out dst);

    public static bool parse(string src, out OpName dst)
    {
        var result = parse(src, out OpNameKind kind);
        if(result)
            dst = kind;
        else
            dst = OpName.Empty;
        return result;
    }

    public static bool parse(string src, out CategoryKind dst)
        => CategoryKinds.Parse(src, out dst);

    public static bool parse(string src, out XedVexClass dst)
        => VexClasses.Parse(src, out dst);

    public static bool parse(string src, out InstCategory dst)
    {
        if(parse(src, out CategoryKind kind))
        {
            dst = kind;
            return true;
        }
        else
        {
            dst = default;
            return false;
        }
    }

    public static bool parse(string src, out XedInstKind dst)
        => Classes.Parse(src, out dst);

    public static bool parse(string src, out XedInstClass dst)
    {
        if(parse(src, out XedInstKind @class))
        {
            dst = @class;
            return true;
        }
        else
        {
            dst = XedInstClass.Empty;
            return false;
        }
    }

    public static bool parse(string src, out XedInstForm dst)
    {
        if(empty(src))
        {
            dst = XedInstForm.Empty;
            return true;
        }

        if(Forms.Parse(src, out XedFormType type))
        {
            dst = type;
            return true;
        }
        else
        {
            dst = XedInstForm.Empty;
            return false;
        }
    }

    public static bool parse(string src, out InstIsaKind dst)
        => IsaKinds.Parse(src, out dst);

    public static bool parse(string src, out InstIsa dst)
    {
        if(parse(src, out InstIsaKind isa))
        {
            dst = isa;
            return true;
        }
        dst = InstIsa.Empty;
        return false;
    }

    public static bool parse(string src, out ExtensionKind dst)
        => ExtensionKinds.Parse(src, out dst);

    public static bool parse(string src, out InstExtension dst)
    {
        dst = default;
        var result = false;
        if(parse(src, out ExtensionKind kind))
        {
            dst = kind;
            result = true;
        }
        return result;
    }

    public static bool parse(string src, out ElementType dst)
    {
        var result = ElementKinds.Parse(src, out ElementKind kind);
        dst = kind;
        return result;
    }

    public static bool parse(string src, out FlagEffectKind dst)
        => FlagActionKinds.Parse(src, out dst);

    public static bool parse(string src, out XedRegFlag dst)
        => RegFlags.Parse(src, out dst);

    public static bool parse(string src, out byte dst)
        => Numbers.num8(src, out dst);

    public static bool parse(string src, out ushort dst)
        => ushort.TryParse(src, out dst);

    public static bool parse(string src, out FieldKind dst)
    {
        var result = true;
        if(empty(src))
        {
            dst = 0;
            return true;
        }
        else
        {
            if(src == nameof(XedInstForm))
                dst = FieldKind.ICLASS;
            else
                result = FieldKinds.Parse(src, out dst);
        }
        return result;
    }

    public static bool parse(string src, out WidthCode dst)
    {
        if(src == nameof(WidthCode.INVALID))
        {
            dst = 0;
            return true;
        }
        else
            return OpWidthParser.Parse(src, out dst);
    }

    public static bool parse(string src, out OpAction dst)
        => OpActions.Parse(src, out dst);

    public static bool parse(string src, out PointerWidth dst)
    {
        if(PointerWidths.Parse(src, out PointerWidthKind pw))
        {
            dst = pw;
            return true;
        }
        else
        {
            dst = PointerWidth.Empty;
            return false;
        }
    }

    public static bool parse(string src, out Nonterminal dst)
    {
        var result = parse(src, out RuleName rn);
        dst = rn;
        return result;
    }

    public static bool parse(string src, out XedRegId dst)
    {
        var input = text.remove(text.trim(src), "XED_REG_");
        if(RuleKeyword.IsWildcard(input))
        {
            dst = RuleKeyword.WildcardReg;
            return true;
        }

        var result = Regs.Parse(input, out dst);
        if(!result)
        {
            result = MmxRegs.Parse(input, out MmxRegId mmx);
            if(result)
                dst = (XedRegId)mmx;
            else
            {
                result = FpuRegs.Parse(src, out FpuRegId fpu);
                if(result)
                    dst = (XedRegId)fpu;
            }
        }
        return result;
    }

    public static bool parse(string src, out Register dst)
    {
        var result = parse(src, out XedRegId reg);
        if(result)
            dst = reg;
        else
            dst = Register.Empty;
        return result;
    }

    public static bool parse(string src, out RuleKeyword dst)
        => RuleKeyword.parse(src, out dst);

    public static bool reg(FieldKind field, string value, out FieldValue dst)
    {
        var result = false;
        dst = R.FieldValue.Empty;
        if(IsNonterm(value))
        {
            result = parse(value, out RuleName name);
            dst = new(field, name);
        }
        else if(parse(value, out XedRegId reg))
        {
            dst = new (field, reg);
            result = true;
        }
        else if(parse(value, out RuleKeyword kw))
        {
            dst = new(kw);
            result = true;
        }
        return result;
    }

    public static bool reg(string src, out OpAttrib dst)
    {
        dst = OpAttrib.Empty;
        var result = false;
        var p0 = src;
        var j = text.index(p0, Chars.LParen);
        if(j > 0)
            p0 = text.left(p0,j);

        result = parse(p0, out XedRegId regid);
        if(result)
        {
            dst = regid;
            return true;
        }

        result = IsNonterm(src);
        if(result)
        {
            if(parse(p0, out Nonterminal nonterm))
            {
                dst = nonterm;
                return true;
            }
        }
        return result;
    }

    public static bool parse(string src, out ElementKind dst)
        => ElementKinds.Parse(src, out dst);

    public static bool parse(string src, out OpVisibility dst)
        => OpVisKinds.Parse(src, out dst);

    public static bool parse(string src, out SMODE dst)
        => SModes.Parse(src, out dst);

    public bool Parse(string src, out AsmOpCodeKind dst)
        => OpCodeKinds.Parse(src, out dst);

    public static bool parse(string src, out BroadcastKind dst)
    {
        if(byte.TryParse(src, out var b))
        {
            dst = (BroadcastKind)b;
            return true;
        }
        dst = default;
        return false;
    }
}
