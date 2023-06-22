//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
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
}