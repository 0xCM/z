//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using Asm;

using static XedModels;
using static XedRules;
using static MachineModes;
using static XedModels.BlockFieldName;
using static sys;

using N = XedModels.BlockFieldName;

public class XedInstBlocks
{
    public static PatternKey key(InstBlockPattern pattern)
        => new(pattern.Form, pattern.Mode, pattern.Lock, pattern.Index);

    public static ReadOnlySeq<InstBlockPattern> filter(InstBlockPatterns src, ChipCode chip)
    {
        var selected = Xed.forms(chip).Map(x => x.InstForm).ToHashSet();
        return src.View.ToHashSet().Where(p => selected.Contains(p.Form)).Array().Sort();
    }

    public static int cmp(InstBlockPattern a, InstBlockPattern b)
    {
        var result = a.Form.CompareTo(b.Form);
        if(result == 0)
        {
            result = a.OpCode.CompareTo(b.OpCode);
            if(result == 0)
            {
                result = a.Mode.CompareTo(b.Mode);
                if(result == 0)
                {
                    result = a.Lock.CompareTo(b.Lock);
                    if(result == 0)
                        result = a.Operands.Format().CompareTo(b.Operands.Format());
                }
            }
        }
        return result;
    }

    public static InstructionRules instructions()
    {
        var lines = XedInstBlocks.lines();
        var defs = XedInstBlocks.defs(lines).Array().Sort().ToSeq();
        var lookup = cdict<PatternKey,InstBlockPattern>();
        var patterns = sys.alloc<InstBlockPattern>(defs.Count);
        var j = z8;
        var form = XedInstForm.Empty;
        for(var i=0u; i<defs.Count; i++)
        {
            ref var def = ref defs[i];
            ref var pattern = ref def.Pattern;
            if(form != def.Form)
            {
                form = def.Form;
                j = 0;
            }
            pattern.Seq = i;
            pattern.Index = j++;
            def.FormIndex = pattern.Index;
            var key = XedInstBlocks.key(pattern);
            Require.invariant(lookup.TryAdd(key,pattern));
            seek(patterns,i) = pattern;
        }
        return new InstructionRules(defs, patterns, new(patterns, lookup), operands(defs));
    }

    static ReadOnlySeq<InstBlockOperand> operands(ReadOnlySeq<InstRuleDef> src)
    {
        var operands = list<InstBlockOperand>();
        foreach(var pattern in src)
        {   
            var count = pattern.Operands.Count;
            for(var i=0; i<count; i++)
                operands.Add(pattern.Operands[i]);
        }
        return operands.Array();
    }

    static ParallelQuery<InstRuleDef> defs(ParallelQuery<InstBlockLineSpec> lines)
        => from line in lines select instruction(line, fields(line).Array());    

    static InstRuleDef instruction(InstBlockLineSpec line, ReadOnlySeq<InstBlockField> fields)
    {
        var mode = MachineMode.Default;
        var form = line.Form;
        var rule = new InstRuleDef{
            Form = form,
            Pattern = pattern(line),
            Fields = fields
        };

        foreach(var field in fields)
        {
            switch(field.Name)                
            {
                case N.mode_restriction:
                    mode = (MachineMode)field;
                break;
                case N.pattern:
                {
                    var cells = (InstCells)field;
                    var segs = list<CellValue>();
                    var segexpr = EmptyString;
                    for(var i=0; i<cells.Count; i++)
                    {
                        ref readonly var cell = ref cells[i];
                        switch(cell.CellKind)
                        {
                            case RuleCellKind.BitLit:
                            case RuleCellKind.HexLit:
                            case RuleCellKind.InstSeg:
                                segs.Add(cell);
                            break;
                        }
                    }
                    rule.Cells = segs.Array();
                }
                break;
                case N.operands:
                {
                    var ops = (PatternOps)field;
                    rule.Operands = new(sys.alloc<InstBlockOperand>(ops.Count));
                    for(var i=z8; i<ops.Count;i++)
                    {
                        ref var target = ref rule.Operands[i];
                        ref readonly var op = ref ops[i];
                        target.Index = i;
                        target.Form = form;
                        target.Name = op.Name;
                        target.Kind = op.Kind;
                        target.SourceExpr = op.SourceExpr;
                        op.WidthCode(out var wc);
                        op.RegLiteral(out target.Register);
                        if(wc != 0)
                        {
                            target.Width = new(wc, XedWidths.bitwidth(mode,wc));
                            var wi = XedWidths.describe(target.Width);
                            if(wi.ElementCount > 1 && wi.ElementWidth != 0)
                                target.SegType = wi.SegType;
                        }

                        if(target.Register.IsNonEmpty && !target.Register.IsNonterminal && target.Width.Bits == 0)
                            target.Width = new(target.Width.Code, XedWidths.width(target.Register));

                        if(target.Register.IsEmpty && op.Nonterminal(out var nt))
                            target.Register = nt;
                    }
                }
                break;
            }                             
        }
        return rule;
    }

    static InstBlockPattern pattern(in InstBlockLineSpec spec)
    {
        var pattern = new InstBlockPattern();
        pattern.Seq = spec.Seq;
        var fields = list<InstBlockField>();
        foreach(var field in XedInstBlocks.fields(spec))
        {                
            fields.Add(field);
            switch(field.Name)
            {
                case N.iclass:
                    pattern.Instruction = (XedInstClass)field;
                    break;
                case N.iform:
                    pattern.Form = (XedInstForm)field;
                    break;
                case N.mode_restriction:
                    pattern.Mode = (MachineMode)field;
                break;
                case N.opcode:
                case N.amd_3dnow_opcode:
                    pattern.OpCode = (Hex8)field;
                break;
                case N.attributes:
                    pattern.InstAttribs = (InstAttribs)field;
                break;
                case N.operands:
                {
                    var ops = (PatternOps)field;
                    pattern.Operands = new(sys.alloc<InstBlockOperand>(ops.Count));
                    for(var i=z8; i<ops.Count;i++)
                    {
                        ref var target = ref pattern.Operands[i];
                        ref readonly var op = ref ops[i];
                        target.Index = i;
                        target.Form = spec.Form;
                        target.Name = op.Name;
                        target.Kind = op.Kind;
                        target.SourceExpr = op.SourceExpr;
                        op.WidthCode(out var wc);
                        op.RegLiteral(out target.Register);
                        if(wc != 0)
                        {
                            target.Width = new(wc, XedWidths.bitwidth(pattern.Mode,wc));
                            var wi = XedWidths.describe(target.Width);
                            if(wi.ElementCount > 1 && wi.ElementWidth != 0)
                                target.SegType = wi.SegType;
                        }

                        if(target.Register.IsNonEmpty && !target.Register.IsNonterminal && target.Width.Bits == 0)
                            target.Width = new(target.Width.Code, XedWidths.width(target.Register));

                        if(target.Register.IsEmpty && op.Nonterminal(out var nt))
                            target.Register = nt;
                    }
                }
                break;
                case N.pattern:
                {
                    pattern.Body = (InstCells)field;
                    var cells = pattern.Body;
                    var segexpr = EmptyString;
                    for(var i=0; i<cells.Count; i++)
                    {
                        ref readonly var cell = ref cells[i];
                        if(cell.Field == FieldKind.LOCK)
                            pattern.Lock = cell.AsByte();
                            
                        switch(cell.CellKind)
                        {
                            case RuleCellKind.InstSeg:
                            {
                                if(nonempty(segexpr))
                                    segexpr += " ";
                                segexpr += cell.AsInstSeg();
                            }
                            break;
                            case RuleCellKind.HexLit:
                            {
                                if(nonempty(segexpr))
                                    segexpr += " ";
                                    
                                segexpr += "0x";
                                segexpr += cell.AsHexLit();
                            }                                    
                            break;
                            case RuleCellKind.BitLit:
                                if(nonempty(segexpr))
                                    segexpr += " ";
                                segexpr += cell.AsBitLit();
                            break;
                        }
                    }
                }
                break;
            }
        }
        return pattern;
    }

    static bool parse(string src, out InstBlockField dst)
    {
        dst = InstBlockField.Empty;
        var name = default(N);
        var i = text.index(src,Chars.Colon);
        if(i>0)
        {
            if(parse(text.left(src,i), out name))
                parse(name,text.trim(text.right(src,i)), out dst);
        }
        return dst.IsNonEmpty;
    }        

    static bool parse(string src, out BlockAttribute dst)
    {
        var i = text.index(src,Chars.Colon);
        if(i > 0)
        {
            var name = text.trim(text.left(src,i));
            var value = text.trim(text.right(src,i));
            parse(name, out N field);
            dst = new(field, value);
        }
        else
            dst = BlockAttribute.Empty;
        return dst.IsNonEmpty;
    }        
    
    public static bool parse(string src, out InstAttribKind dst)
        => AttribKindParser.Parse(src, out dst);

    public static bool parse(string src, out BlockFieldName dst)
        => FieldNameParser.Parse(src, out dst);

    static IEnumerable<InstBlockField> fields(InstBlockLineSpec src)
    {
        var field = InstBlockField.Empty;
        foreach(var line in src.Lines.Storage)
        {
            if(parse(line, out field))
                yield return field;
        }
    }

    static ParallelQuery<InstBlockLineSpec> lines()
        => lines(XedPaths.RuleBlockSource());

    static ParallelQuery<InstBlockLineSpec> lines(FilePath path)
    {
        using var src = MemoryFiles.map(path);
        var _dst = list<InstBlockLineSpec>();
        lines(Lines.lines(src), _dst);   
        return _dst.AsParallel();     
    }

    static bool split(string src, out string name, out string value)
    {
        var result = false;
        var i = text.index(src,Chars.Colon);
        if(i > 0)
        {
            name = text.trim(text.left(src,i));
            value = text.trim(text.right(src,i));
            result = true;
        }
        else
        {
            name = EmptyString;
            value = EmptyString;
        }
        return result;
    }
    
    static void lines(ReadOnlySpan<string> src, List<InstBlockLineSpec> dst)
    {
        const string FirstItemMarker = "amd_3dnow_opcode:";
        const string LastItemMarker = "EOSZ_LIST:";
        const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
        const string IFormMarker = "iform:";
        var fields = InstBlockLineSpec.Empty;
        var buffer = list<LineInterval<InstBlockLineSpec>>();
        var form = XedInstForm.Empty;
        var name = EmptyString;
        var value = EmptyString;
        var field = N.amd_3dnow_opcode;
        var counter = 0u;
        var min = 0u;
        var seq = 0u;

        for(var i=0u; i<src.Length; i++)
        {
            var line = text.trim(skip(src,i));
            counter += (uint)line.Length;
            if(split(line, out name, out value))
            {
                if(parse(name, out field))
                    fields.Fields[field] = bit.On;
            }
            
            if(text.begins(line,FirstItemMarker))
                fields.MinLine = i;
            else if(text.begins(line, LastItemMarker))
            {
                fields.MaxLine = i;
                fields.MinChar = min;
                fields.MaxChar = counter;
                fields.Seq = seq++;
                fields.LineCount = fields.MaxLine - fields.MinLine + 1;
                fields.Lines = slice(src,fields.MinLine, fields.LineCount).ToArray();
                dst.Add(fields);
                fields = InstBlockLineSpec.Empty;
                min = counter+1;
            }
            else
            {
                var j = text.index(line,IFormMarker);
                if(j >= 0)
                    XedParsers.parse(value, out fields.Form);
            }
        }
    }    

    static bool parse(ReadOnlySpan<char> src, out AsmOpCodeClass dst)
    {
        dst = src switch {
            "evex" => AsmOpCodeClass.Evex,
            "vex" => AsmOpCodeClass.Vex,
            "xop" => AsmOpCodeClass.Xop,
            _ => AsmOpCodeClass.Legacy
        };
        return true;
    }

    static bool parse(ReadOnlySpan<char> src, out MachineMode dst)
    {
        dst = src switch {
            "0" => dst = MachineModeClass.Mode16,
            "1" => dst = MachineModeClass.Mode32,
            "2" => dst = MachineModeClass.Mode64,
            "not64" => dst = MachineModeClass.Not64,
            "unspecified" => dst = MachineMode.Default,
            _ => dst = (MachineModeClass)byte.MaxValue
        };
        return dst.Class <= MachineModeClass.Mode32x64;
    }

    static bool parse(ReadOnlySpan<char> src, out InstCells dst)
        => XedCells.parse(src, out dst);

    static bool parse(string src, out InstAttribs dst)
    {
        var parts = text.trim(text.split(src, Chars.Space));
        dst = sys.alloc<InstAttrib>(parts.Length);
        var i=0u;
        foreach(var part in parts)
        {
            if(parse(part, out InstAttribKind kind))
                dst[i++] = kind;
        }
        return true;
    }

    static bool parse(string src, out OperandClasses dst)
    {
        var i = text.index(src,Chars.LBracket);
        var j = text.index(src,Chars.RBracket);
        dst = OperandClasses.Empty;
        if(i >= 0 && j>i)
        {
            var terms = text.split(text.inside(src,i,j), Chars.Comma);
            var count = (byte)min(terms.Length, OperandClasses.MaxCount);
            dst.Count = count;
            for(var k=0; k<count; k++)
            {
                dst[k] = new(text.unfence(skip(terms,k), (Chars.SQuote, Chars.SQuote)));
            }
        }   
        return dst.IsNonEmpty;
    }

    static bool parse(ReadOnlySpan<char> src, out bool dst)
    {
        switch(src)
        {
            case "True":
                dst = true;
            return true;
            case "False":
                dst = false;
            return true;
            default:
                dst = default;
                return false;
        }
    }

    static bool parse(ReadOnlySpan<char> src, out EASZ dst)
    {
        dst = (EASZ)byte.MaxValue;
        switch(src)
        {
            case "a16": dst = EASZ.EASZ16; break;
            case "a32": dst = EASZ.EASZ32; break;
            case "a64": dst = EASZ.EASZ64; break;
            case "easzall": dst = EASZ.EASZAll; break;
            case "easznot16": dst = EASZ.EASZNot16; break;
        }

        return dst <= EASZ.EASZNot16;
    }

    static bool parse(ReadOnlySpan<char> src, out EOSZ dst)
    {
        dst = (EOSZ)byte.MaxValue;
        switch(src)
        {
            case "o16": dst = EOSZ.EOSZ16; break;
            case "o32": dst = EOSZ.EOSZ32; break;
            case "o64": dst = EOSZ.EOSZ64; break;
            case "oszall": dst = EOSZ.EOSZ8; break;
        }

        return dst <= EOSZ.EOSZ64;
    }

    static bool parse(ReadOnlySpan<char> src, out VsibKind dst)
    {
        dst = (VsibKind)byte.MaxValue;
        switch(src)
        {
            case "": dst = VsibKind.None; break;
            case "xmm": dst = VsibKind.Xmm; break;
            case "ymm": dst = VsibKind.Ymm; break;
            case "zmm": dst = VsibKind.Zmm; break;
        }

        return dst <= VsibKind.Zmm;
    }

    static bool parse(string src, out VL dst)
    {
        dst = VL.None;
        if(src != "n/a")
            switch(src)
            {
                case "LIG":
                case "LLIG":
                break;
                default:
                {
                    if(ushort.TryParse(src, out ushort width))
                    {
                        switch(width)
                        {
                            case 128:
                                dst = AsmVL.VL128;
                            break;
                            case 256:
                                dst = AsmVL.VL256;
                            break;
                            case 512:
                                dst = AsmVL.VL512;
                            break;                        
                        }
                    }
                }
                break;
            }
        return dst <= AsmVL.VL512;
    }

    static bool parse(N field, string src, out InstBlockField dst)
    {
        dst = InstBlockField.Empty;
        switch(field)
        {
            case opcode:
            case amd_3dnow_opcode:
            {
                if(XedParsers.parse(src, out Hex8 value))
                    dst = new(field, value);
            }
            break;

            case N.attributes:
            {
                if(parse(src, out InstAttribs value))
                    dst = new(field, value);
            }
            break;

            case avx512_tuple:
            break;

            case avx_vsib:
            case avx512_vsib:
            {
                if(parse(src, out VsibKind value))
                    dst = new(field, value);
            }
            break;

            case broadcast_allowed:
            break;

            case category:
            {
                if(XedParsers.parse(src, out CategoryKind value))
                    dst = new(field, value);
            }
            break;

            case cpuid:
            break;


            case easz:
            {
                if(parse(src, out EASZ value))
                    dst = new(field, value);
            }
            break;

            case memop_width:
            case element_size:
            {
                if(src != "None")
                {
                    if(byte.TryParse(src, out byte value))
                        dst = new(field, (NativeSizeCode)value);
                }
            }
            break;

            case eosz:
            {
                if(parse(src, out EOSZ value))
                    dst = new(field, value);
            }
            break;

            case implicit_operands:
            case explicit_operands:
            {
                if(src != "['none']")
                {
                    if(parse(src, out OperandClasses value))
                        dst = new(field, value);
                }
            }
            break;

            case extension:
            {
                if(XedParsers.parse(src, out InstExtension value))   
                    dst = new(field, value);
            }
            break;

            case default_64b:
            case f2_required:
            case f3_required:
            case has_imm8:
            case has_imm8_2:
            case has_immz:
            case has_modrm:
            case no_prefixes_allowed:
            case osz_required:
            case N.scalar:
            case sibmem:
            {
                if(parse(src, out bool value))
                    dst = new(field, value);
            }
            break;

            case flags:
            break;

            case iclass:
            {
                if(XedParsers.parse(src, out XedInstClass value))
                    dst = new(field, value);
            }
            break;

            case iform:
            {
                if(XedParsers.parse(src, out XedInstForm value))
                    dst = new(field, value);
            }
            break;

            case imm_sz:
            break;

            case isa_set:
            {
                if(XedParsers.parse(src, out InstIsaKind value))   
                    dst = new(field, value);
            }
            break;

            case N.map:
            {                    
                if(byte.TryParse(src, out byte value))
                    dst = new(field, value);
            }
            break;

            case memop_rw:
            break;

            case mod_required:
            {
                if(text.contains(src,Chars.FSlash))
                {
                    var values = text.trim(text.split(src,Chars.FSlash));
                    for(var i=0; i<values.Length; i++)
                    {
                        if(byte.TryParse(skip(values,i), out var value))
                        {

                        }
                    }
                }
                else
                {
                    if(byte.TryParse(src, out var value))
                    {

                    }
                }                
            }
            break;

            case mode_restriction:
            {
                if(parse(src, out MachineMode value))
                    dst = new(field, value);
            }
            break;


            case ntname:
            {
                if(XedParsers.parse(src, out RuleName value))
                    dst = new(field, value);
            }
            break;

            case N.operands:
            {
                var input = text.split(src, Chars.Space);
                var count = input.Length;
                    PatternOps value = sys.alloc<PatternOp>(count);
                for(var i= z8; i< count; i++)
                {
                        XedPatterns.parse(skip(input, i), ref value[i]);
                    value[i].Index = i;
                }
                dst = new(field, value);
            }
            break;

            case N.pattern:
            {
                if(parse(src, out InstCells value))
                    dst = new(field, value);
            }
            break;

            case reg_required:
            {
                if(src != "unspecified" && byte.TryParse(src, out byte value))
                    dst = new(field, value);
            }
            break;

            case rexw_prefix:
            {
                if(src != "unspecified" && DataParser.parse(src, out bit value).Ok)
                    dst = new(field, value);
            }
            break;

            case rm_required:
            {
                if(src != "unspecified" && byte.TryParse(src, out var value))
                    dst = new(field, value);
            }
            break;

            case space:
            {
                if(parse(src, out AsmOpCodeClass value))                        
                    dst = new(field, value);
            }
            break;

            case vl:
            {
                if(parse(src, out VL value))
                    dst = new(field, value);
            }
            break;

            case exceptions:
            break;

            case memop_width_code:
            {
                if(XedParsers.parse(src, out WidthCode value))
                {
                    dst = new(field, value);
                }
            }
            break;

            case disasm:
            break;

            case uname:
            break;

            case version:
            break;

            case comment:
            break;

            case EOSZ_LIST:
            break;

            case cpl:
            case lower_nibble:
            case opcode_base10:
            case operand_list:
            case partial_opcode:
            case real_opcode:
            case parsed_operands:
            case disasm_intel:
            case disasm_attsv:
            case upper_nibble:
            case undocumented:
            break;
        }

        return dst.IsNonEmpty;
    }
 
    static readonly EnumParser<BlockFieldName> FieldNameParser = new();

    static readonly EnumParser<InstAttribKind> AttribKindParser = new();
}