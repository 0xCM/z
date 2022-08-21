# MC Terms

References:
<https://lists.llvm.org/pipermail/llvm-dev/2018-March/122203.html>
<https://github.com/llvm/llvm-project/blob/ce548aa236962f95ccaf59f8692ed0861f3769dd/llvm/lib/Target/X86/MCTargetDesc/X86BaseInfo.h>

## X86 instruction encoding

LLVM uses a complex system of fields within the X86Inst class in tablegen to control instruction encoding and disassembling. These fields attempt to classify various aspects of the complicated X86 encoding system.

Fields
------
 Opcode         - Single byte value indicating the opcode within the various X86 opcode maps. For most instructions this the value between prefixes and the ModRM byte.
 Form           - Classifies how operands are encoded into the various fields that encode operands, i.e. modrm.reg, modrm.rm, vex.vvvv, rex.r, rex.x, rex.b, etc. See format list below.
 ImmT           - Determines the size of the immediate, if any at the end of the instruction.
 OpSize         - Used to inciate instructions that need a 0x66 operand size prefix to encode 16-bit operands in 32 mode or 32-bit operands in 16-bit mode.
 AdSize         - Used to mark instructions that need to emit a 0x67 address size prefix in 32-bit mode or 16-bit mode. This is rarely used and is only needed by instructions that don't use an address encoded in modrm/sib.
 OpPrefix       - Encodes whether the instruction requires a 0x66, 0xf2, or 0xf3 prefix. For 0x66 this is primarily used by SSE instructions where 0x66 is different than the 0x66 operand size prefix above.
 OpMap          - Which one of the opcode maps this instruction belows to. Corresponds to the one byte, two byte, three byte 0x0f 0x38, three byte 0x0f 0x3a, etc. maps from the Intel SDM.
 hasREX_WPrefix - Indicates the instruction requires the REX.W it to be set.
 hasLockPrefix  - Indicates the instruction should be encoded with a 0xF0 lock prefix.
 hasREPPrefix   - Indicates the instruction should be encoded with a 0xF3 rep prefix.
 OpcEnc         - Which encoding scheme this instruction uses. Normal, VEX, EVEX, or XOP.
 VEX_WPrefix    - Controls the value of the VEX.W bit in the encoder also tells the disassembler which instructions ignore VEX.W.
 hasVEX_4V      - Does this instruction use VEX.vvvv
 hasVEX_L       - Should this instruction be encoded with VEX.L=1
 ignoresVEX_L   - Tells the disassembler that VEX.L should be ignored
 hasEVEX_K      - Does this instruction use a k-register for masking
 hasEVEX_Z      - Is the k-register used for zero masking or merge masking.
 hasEVEX_L2     - Should this instruction be encoded with EVEX.L'=1
 hasEVEX_B      - Should this instruction be encoded with EVEX.b=1
 CD8_Form       - Format for compressed disp8 for EVEX instructions
 CD8_EltSize    - Element size for compressed displacement
 hasEVEX_RC     - Indicates that EVEX.L'L should be used for embedded rounding control
 hasNoTrackPrefix - Instruction has notrack prefix. Should only occur on indirect calls and jumps.
 CD8_Scale -The scaling factor for AVX512's compressed displacement is either
    - the size of a power-of-two number of elements or
    - the size of a single element for broadcasts or
    - the total vector size divided by a power-of-two number.
    Possible values are: 0 (non-AVX512 inst), 1, 2, 4, 8, 16, 32 and 64.

The X86Inst class should not be used directly to define any instruction. Instructions should use PseudoI, I, Ii8, Ii8Reg, Ii8PCRecl, Ii16, Ii32, Ii32S, FPI, FPI_, Iseg16, or Iseg32 classes. Or a subclass of one of those. These classes take care of setting the ImmT field correctly. All of the I* classes take Opcode and Form as an argument. The remaining fields have defaults that can be overridden via modifiers added to the end of your instruction definition.

Forms
-----
 Pseudo         - No encoding/disassembling information is present. These should be removed/replaced with other instructions before we reach the encoding phase of codegen.RawFrm         - Instruction has no modrm byte. Operands are fixed registers. There may be an immediate present
 AddRegFrm      - Instruction encodes a register in bits 2:0 of the opcode. No modrm byte. Opcode should be a multiple of 8 for such an instruction.
 RawFrmMemOffs  - Instruction encodes a fixed constant address in the instruction without modrm byte. Basically opcodes 0xA0-0xA3
 RawFrmSrc      - Instruction uses SI/ESI/RSI as a source memory address. LODS and OUTS.
 RawFrmDst      - Instruction uses DI/EDI/RDI as a destinatino memory address. Input in AL/AX/EAX/RAX for SCAS/STOS. Or DX for INS.
 RawFrmDstSrc   - Instruction uses SI/ESI/RSI as a source memory address and DI/EDI/RDI as a destination memory address. MOVS and CMPS instructions.
 RawFrmImm8     - Rare instruction that has two immediates. The first is 8-bits the second one is controlled by ImmT field.
 RawFrmImm16    - Rare instruction that has two immediates. The first is 16-bits the second one is controlled by ImmT field.
 MRMDestMem     - modrm.mod!=0x3, modrm[2:0] and optional sib byte and displacement encode destination memory address. vex.vvvv is used encodes the next register, modrm[5:3] encodes destination register.
 MRMSrcMem      - modrm.mod!=0x3, modrm[5:3] encodes destination register. if vex.vvvv is used it encodes the next register, modrm[2:0] encodes second or third source register
 MRMSrcMem4VOp3 - like MRMSrcMem, but vex.vvvv and memory operand are swapped. Rarely used.
 MRMSrcMemOp4   - like MRMSrcMem, but a second source register is encoded in bits [7:4] of an immediate. Memory is the 4th operand. Rarely used.
 MRMXm          - modrm.mod==0x3, with a value of 0 in modrm[5:3]. modrm[2:0] and optional sib byte and displacement encode memory address. This is almost the same as MRM0m, but the disassembler ignores modrm[5:3]
 MRM0m-MRM7m    - modrm.mod!=0x3, with a fixed value(0-7) in modrm[5:3]. modrm[2:0] and optional sib byte and displacement encode memory address.
 MRMDestReg     - modrm.mod==0x3, modrm[2:0] encodes destination register. if vex.vvvv is used encodes the next register, mrm[5:3] encodes the second or third register.
 MRMSrcReg      - modrm.mod==0x3, modrm[5:3] encodes destination register. if vex.vvvv is used encodes the next register, mrm[2:0] encodes the second or third register.
 MRMSrcReg4VOp3 - like MRMSrcReg, but vex.vvvv and memory operand are swapped. Rarely used
 MRMSrcRegOp4   - like MRMSrcReg, but a second source register is encoded in bits [7:4] of an immediate. modrm[2:0] encodes the 4th operand. Rarely used
 MRMXr          - modrm.mod==0x3, with a value of 0 in modrm[5:3]. modrm[2:0] encodes a register. This is almost the same as MRM0r, but the disassembler ignores modrm[5:3]
 MRM0r-MRM7r    - modrm.mod==0x3, with a fixed value(0-7) in modrm[5:3]. modrm[2:0] encode a register
 MRMC0-MRM_FF   - Instruction encodes with a fixed value in the range 0xC0-0xFF in the modrm byte. e.g. VMCALL, MONITOR. No known instructions use a fixed value in 0x00-0xBF range.

ImmT
----
 NoImm
 Imm8
 Imm8PCRel
 Imm8Reg    - 8-bits with a register encoded in bits 7:4
 Imm16
 Imm16PCRel
 Imm32      - 32-bit immediate
 Imm32PCRel
 Imm32S     - 32-bit immediate that is sign extended to 64-bits.
 Imm64

Opsize
------
 OpSizeFixed          - Operand size isn't mode dependent
 OpSize16             - 0x66 prefix required in 32-bit mode
 OpSize32             - 0x66 prefix required in 16-bit mode
 OpSizeIgnored        - 0x66 prefix should be ignored if present.

Adsize
------
  AdSizeX          - Address size prefix determined from memory operand registers encoded in modrm byte
  AdSize16         - Need a 0x67 prefix in 32-bit mode
  AdSize32         - Need a 0x67 prefix in 16-bit mode or 64-bit mode
  AdSize64         - Marks the 64-bit version of AdSize16/32 instructions.

OpPrefix
--------
  NoPrfx(default)
  PS               - Doesn't encode with a prefix, but 0x66/0xf2/0xf3 prefix are different instructions to the disassembler. Sets VEX.PP=0 for VEX encoding.
  PD               - Always uses a 0x66 prefix. VEX.PP=1 for VEX encoding.
  XS               - Always uses a 0xF3 prefix. VEX.PP=2 for VEX encoding.
  XD               - Always uses a 0xF2 prefix. VEX.PP=3 for VEX encoding.

OpMap
-----
 OB(default) - One byte opcode. Not used by any VEX encoded instructions.
 TB          - Two byte opcode, first byte is 0x0F. VEX.mmmmm=0x1 for VEX encoding.
 T8          - Three byte opcode, first bytes are 0x0F 0x38. VEX.mmmmm=0x2 for VEX encoding.
 TA          - Three byte opcode, first bytes are 0x0F 0x3A. VEX.mmmmm=0x3 for VEX encoding.
 XOP8        - Used by AMD xop encoding. XOP.mmmmm=0x8
 XOP9        - Used by AMD xop encoding. XOP.mmmmm=0x9
 XOPA        - Used by AMD xop encoding. XOP.mmmmm=0xA
 ThreeDNow   - 3DNow opcode map. First two bytes are 0x0F 0x0F. Opcode placed at the end of the instruction after modrm.

OpEncoding
----------
 EncNormal(default) - Oldest encoding system using opcodes and various prefix bytes.
 EncVEX             - VEX encoding introduced with AVX. First byte is 0xC4 or 0xC5. Various values encoded in bit fields of next two or three bytes before opcode and modrm.
 EncXOP             - AMD XOP encoding. Similar to VEX. First byte is 0x8F.
 EncEVEX            - EVEX encoding instroduced with AVX512. First byte is 0x62. Various values encoded in bit fields of next 3 bytes before before opcode and modrm.


Modifiers to be used as part of instruction definitions
=======================================================

Most of these just force various fields listed above and should reasonably intuitive.

OpSize16     - Set OpSize to OpSize16
OpSize32     - Set OpSize to OpSize32
OpSizeIgnore - Set OpSize to OpSizeIgnore
AdSize16     - Set AdSize to AdSize16
AdSize32     - Set AdSize to AdSize32
AdSize64     - Set AdSize to AdSize64
REX_W        - Set hasREX_WPrefix
LOCK         - Set hasLOCKPrefix
REP          - Set hasREPPrefix
TB           - Set map to TB
T8           - Set map to T8
TA           - Set map to TA
XOP8         - Set map to XOP8
XOP9         - Set map to XOP9
XOPA         - Set map to XOPA
ThreeDNow    - Set map to ThreeDNow
OBXS         - Set map to OB and prefix to XS (used by PAUSE)
PS           - Set map to TB and prefix to PS (name is misleading)
PD           - Set map to TB and prefix to PD (name is misleading)
XD           - Set map to TB and prefix to XD (name is misleading)
XS           - Set map to TB and prefix to XS (name is misleading)
T8PS         - Set map to T8 and prefix to PS
T8PD         - Set map to T8 and prefix to PD
T8XD         - Set map to T8 and prefix to XD
T8XS         - Set map to T8 and prefix to XS
TAPS         - Set map to TA and prefix to PS
TAPD         - Set map to TA and prefix to PD
TAXD         - Set map to TA and prefix to XD
VEX          - Set encoding to VEX.
VEX_W        - Set VEX_WPrefix to VEX.W=1
VEX_WIG      - VEX_WPrefix to VEX.W ignore value.
VEX_4V       - Set hasVEX_4V=1. Implies VEX.
VEX_L        - set hasVEX_L=1
VEX_LIG      - Set ignoresVEX_L
EVEX         - Set encoding to EVEX.
EVEX_4V      - Set hasVEX_4V=1. Implies EVEX.
EVEX_K       - Set hasEVEX_K=1.
EVEX_KZ      - Set hasEVEX_Z=1. Implies EVEX_K.
EVEX_B       - Set hasEVEX_B=1
EVEX_RC      - Set hasEVEX_RC=1
EVEX_V512    - Sets has_EVEX_L2=1; hasVEX_L=0;
EVEX_V256    - Sets has_EVEX_L2=0; hasVEX_L=1;
EVEX_V128    - Sets has_EVEX_L2=0; hasVEX_L=0;
NOTRACK      - Set hasNoTrackPrefix

