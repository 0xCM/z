//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.disasm
{
    using static ApiAtomic;

    /// <summary>
    /// From https://github.com/llvm/llvm-project/blob/a8ad9170543906fc58336ab736a109fb42082fbf/llvm/include/llvm/Support/X86DisassemblerDecoderCommon.h
    /// Attributes of an instruction that must be known before the opcode can be
    /// processed correctly.  Most of these indicate the presence of particular
    /// prefixes, but ATTR_64BIT is simply an attribute of the decoding context.
    /// </summary>
    [SymSource(llvm_mc)]
    public enum AttributeBits : ushort
    {
        ATTR_NONE = 0x00,

        [Symbol("x64")]
        ATTR_64BIT = 0x1 << 0,

        [Symbol("XS")]
        ATTR_XS = 0x1 << 1,

        [Symbol("XD")]
        ATTR_XD = 0x1 << 2,

        [Symbol("REX.W")]
        ATTR_REXW = 0x1 << 3,

        [Symbol("OPSZ")]
        ATTR_OPSIZE = 0x1 << 4,

        [Symbol("ADSZ")]
        ATTR_ADSIZE = 0x1 << 5,

        [Symbol("VEX")]
        ATTR_VEX = 0x1 << 6,

        [Symbol("VEX.L")]
        ATTR_VEXL = 0x1 << 7,

        [Symbol("EVEX")]
        ATTR_EVEX = 0x1 << 8,

        [Symbol("EVEX.L2")]
        ATTR_EVEXL2 = 0x1 << 9,

        [Symbol("EVEX.K")]
        ATTR_EVEXK = 0x1 << 10,

        [Symbol("EVEX.KZ")]
        ATTR_EVEXKZ = 0x1 << 11,

        [Symbol("EVEX.B")]
        ATTR_EVEXB = 0x1 << 12,

        ATTR_max = 0x1 << 13,
    }
}