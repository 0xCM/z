//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static XedModels;
using static MachineModes;
using static XedZ.BlockFieldName;

using N=XedZ.BlockFieldName;

partial class XedZ
{
    public class BlockFieldParser
    {
        public static bool parse(string src, out Attribute dst)
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
                dst = Attribute.Empty;
            return dst.IsNonEmpty;
        }        

        public static bool parse(string src, out BlockField dst)
        {
            dst = BlockField.Empty;
            var name = default(N);
            var i = text.index(src,Chars.Colon);
            if(i>0)
            {
                if(parse(text.left(src,i), out name))
                {
                    parse(name,text.trim(text.right(src,i)), out dst);
                }    
            }
            return dst.IsNonEmpty;
        }        

        static readonly EnumParser<BlockFieldName> FieldNameParser = new();

        static readonly EnumParser<InstAttribKind> AttribKindParser = new();

        public static bool parse(string src, out InstAttribKind dst)
            => AttribKindParser.Parse(src, out dst);

        public static bool parse(string src, out BlockFieldName dst)
            => FieldNameParser.Parse(src, out dst);

        public static bool parse(string src, out InstAttribs dst)
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

        public static bool parse(ReadOnlySpan<char> src, out InstCells dst)
            => XedCells.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out MachineMode dst)
        {
            dst = src switch {
                "0" => dst = MachineModeClass.Mode16,
                "1" => dst = MachineModeClass.Mode32,
                "2" => dst = MachineModeClass.Mode64,
                "not64" => dst = MachineModeClass.Not64,
                "unspecified" => dst = MachineMode.Default,
                _ => dst = (MachineModeClass)byte.MaxValue
            };
            return dst.Class <= MachineModeClass.Default;
        }

        public static bool parse(ReadOnlySpan<char> src, out AsmOpCodeClass dst)
        {
            dst = src switch {
                "evex" => AsmOpCodeClass.Evex,
                "vex" => AsmOpCodeClass.Vex,
                "xop" => AsmOpCodeClass.Xop,
                _ => AsmOpCodeClass.Legacy
            };
            return true;
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

        static bool parse(N field, string src, out BlockField dst)
        {
            dst = BlockField.Empty;
            switch(field)
            {
                case opcode:
                case amd_3dnow_opcode:
                {
                    if(XedParsers.parse(src, out Hex8 value))
                        dst = new(field,value);
                }
                break;

                case attributes:
                {
                    if(parse(src, out InstAttribs value))
                        dst = new(field,value);
                }
                break;

                case avx512_tuple:
                break;

                case avx_vsib:
                case avx512_vsib:
                {
                    if(parse(src, out VsibKind value))
                        dst = new(field,value);
                }
                break;

                case broadcast_allowed:
                break;

                case category:
                {
                    if(XedParsers.parse(src, out CategoryKind value))
                        dst = new(field,value);
                }
                break;

                case cpl:
                break;

                case cpuid:
                break;


                case easz:
                {
                    if(parse(src, out EASZ value))
                        dst = new(field,value);
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
                        dst = new(field,value);
                }
                break;

                case explicit_operands:
                break;

                case extension:
                {
                    if(XedParsers.parse(src, out InstExtension value))   
                        dst = new(field,value);
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
                        dst = new(field,value);
                }
                break;

                case flags:
                break;

                case iclass:
                {
                    if(XedParsers.parse(src, out XedInstClass value))
                        dst = new(field,value);
                }
                break;

                case iform:
                {
                    if(XedParsers.parse(src, out XedInstForm value))
                        dst = new(field,value);
                }
                break;

                case imm_sz:
                break;

                case implicit_operands:
                break;

                case isa_set:
                {
                    if(XedParsers.parse(src, out InstIsaKind value))   
                        dst = new(field,value);

                }
                break;

                case lower_nibble:
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

                }
                break;

                case mode_restriction:
                {
                    if(parse(src, out MachineMode value))
                        dst = new(field,value);
                }
                break;


                case ntname:
                {
                    if(XedParsers.parse(src, out RuleName value))
                        dst = new(field,value);
                }
                break;

                case opcode_base10:
                break;

                case operand_list:
                break;

                case operands:
                {
                    var input = text.split(src, Chars.Space);
                    var count = input.Length;
                    PatternOps value =  sys.alloc<PatternOp>(count);
                    for(var i=0; i<count; i++)
                    {
                        XedPatterns.parse(skip(input,i), ref value[i]);
                    }
                    dst = new(field,value);
                }
                break;

                case pattern:
                {
                    if(parse(src, out InstCells value))
                        dst = new(field,value);
                }
                break;

                case reg_required:
                break;

                case rexw_prefix:
                {
                    if(src != "unspecified")
                    {
                        if(DataParser.parse(src, out bit value))
                            dst = new(field,value);
                    }
                }
                break;

                case rm_required:
                {
                    if(src != "unspecified")
                    {
                        if(byte.TryParse(src, out var value))
                            dst = new(field,value);
                    }

                }
                break;


                case space:
                {
                    if(parse(src, out AsmOpCodeClass value))                        
                        dst = new(field,value);
                }
                break;


                case vl:
                break;

                case exceptions:
                break;

                case memop_width_code:
                {
                    if(XedParsers.parse(src, out WidthCode value))
                    {
                        dst = new(field,value);
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
    }
}
