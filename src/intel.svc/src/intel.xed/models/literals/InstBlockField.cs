//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public class BlockFieldNames
    {
        public const string amd_3dnow_opcode = nameof(amd_3dnow_opcode);

        public const string attributes = nameof(attributes);

        public const string avx512_tuple = nameof(avx512_tuple);

        public const string avx512_vsib = nameof(avx512_vsib);

        public const string avx_vsib = nameof(avx_vsib);

        public const string broadcast_allowed = nameof(broadcast_allowed);

        public const string category = nameof(category);

        public const string comment = nameof(comment);

        public const string cpl = nameof(cpl);

        public const string cpuid = nameof(cpuid);

        public const string default_64b = nameof(default_64b);

        public const string disasm = nameof(disasm);

        public const string disasm_attsv = nameof(disasm_attsv);

        public const string disasm_intel = nameof(disasm_intel);

        public const string easz = nameof(easz);

        public const string element_size =nameof(element_size);

        public const string eosz = nameof(eosz);

        public const string explicit_operands = nameof(explicit_operands);

        public const string extension = nameof(extension);

        public const string f2_required = nameof(f2_required);

        public const string f3_required = nameof(f3_required);

        public const string flags = nameof(flags);

        public const string has_imm8 = nameof(has_imm8);

        public const string has_imm8_2 = nameof(has_imm8_2);

        public const string has_immz = nameof(has_immz);

        public const string has_modrm = nameof(has_modrm);

        public const string iclass = nameof(iclass);

        public const string iform = nameof(iform);

        public const string imm_sz = nameof(imm_sz);

        public const string implicit_operands = nameof(implicit_operands);

        public const string isa_set = nameof(isa_set);

        public const string lower_nibble = nameof(lower_nibble);

        public const string map = nameof(map);

        public const string memop_rw = nameof(memop_rw);

        public const string mod_required = nameof(mod_required);
        
        public const string mode_restriction = nameof(mode_restriction);

        public const string no_prefixes_allows = nameof(no_prefixes_allows);

        public const string ntname = nameof(ntname);

        public const string opcode = nameof(opcode);

        public const string opcode_base10 = nameof(opcode_base10);

        public const string operands = nameof(operands);

        public const string osz_required = nameof(osz_required);

        public const string parsed_operands = nameof(parsed_operands);

        public const string partial_opcode = nameof(partial_opcode);

        public const string pattern = nameof(pattern);

        public const string real_opcode = nameof(real_opcode);

        public const string reg_required = nameof(reg_required);

        public const string rexw_required = nameof(rexw_required);

        public const string undocumented = nameof(undocumented);

        public const string upper_nibble = nameof(upper_nibble);

        public const string vl = nameof(vl);

        public const string EOSZ_LIST = nameof(EOSZ_LIST);
    }    

    [SymSource("xed")]
    public enum InstBlockField : byte
    {
        amd_3dnow_opcode,

        attributes,

        avx512_tuple,

        avx512_vsib,

        avx_vsib,

        broadcast_allowed,

        category,

        cpl,

        cpuid,

        default_64b,

        easz,

        element_size,

        eosz,

        explicit_operands,

        extension,

        f2_required,

        f3_required,

        flags,

        has_imm8,

        has_imm8_2,

        has_immz,

        has_modrm,

        iclass,

        iform,

        imm_sz,

        implicit_operands,

        isa_set,

        lower_nibble,

        map,

        memop_rw,

        mod_required,

        mode_restriction,

        no_prefixes_allowed,

        ntname,

        opcode,

        opcode_base10,

        operand_list,

        operands,

        osz_required,

        parsed_operands,

        partial_opcode,

        pattern,

        real_opcode,

        reg_required,

        rexw_prefix,

        rm_required,

        scalar,

        sibmem,

        space,

        undocumented,

        upper_nibble,

        vl,

        exceptions,

        memop_width,

        memop_width_code,

        disasm,

        disasm_intel,

        disasm_attsv,

        uname,

        version,

        comment,

        EOSZ_LIST,
    }
}
