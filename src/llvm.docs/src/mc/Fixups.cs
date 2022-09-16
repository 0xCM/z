//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.mc
{
    using static ApiAtomic;

    /// <summary>
    /// From https://github.com/llvm/llvm-project/blob/2946cd701067404b99c39fb29dc9c74bd7193eb3/llvm/lib/Target/X86/MCTargetDesc/X86FixupKinds.h
    /// </summary>
    [SymSource(llvm_mc)]
    public enum Fixups : ushort
    {
        [Symbol("reloc_riprel_4byte", "32-bit rip-relative")]
        reloc_riprel_4byte = MCFixupKind.FirstTargetFixupKind,

        [Symbol("reloc_riprel_4byte_movq_load","32-bit rip-relative in movq")]
        reloc_riprel_4byte_movq_load,

        [Symbol("reloc_riprel_4byte_relax","32-bit rip-relative in relaxable instruction")]
        reloc_riprel_4byte_relax,

        [Symbol("reloc_riprel_4byte_relax_rex","32-bit rip-relative in relaxable instruction with rex prefix")]
        reloc_riprel_4byte_relax_rex,

        [Symbol("reloc_signed_4byte","32-bit signed. Unlike FK_Data_4 this will be sign extended at runtime")]
        reloc_signed_4byte,

        [Symbol("reloc_signed_4byte_relax","like reloc_signed_4byte, but in a relaxable instruction")]
        reloc_signed_4byte_relax,

        [Symbol("reloc_global_offset_table","32-bit, relative to the start of the instruction. Used only for _GLOBAL_OFFSET_TABLE_")]
        reloc_global_offset_table,

        [Symbol("reloc_global_offset_table8","64-bit variant")]
        reloc_global_offset_table8,

        [Symbol("reloc_branch_4byte_pcrel","32-bit PC relative branch")]
        reloc_branch_4byte_pcrel,

        // Marker
        LastTargetFixupKind,

        NumTargetFixupKinds = LastTargetFixupKind - MCFixupKind.FirstTargetFixupKind
    };
}