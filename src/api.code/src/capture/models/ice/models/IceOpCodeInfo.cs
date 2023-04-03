//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public struct IceOpCodeInfo
    {
        //
        // Summary:
        //     (EVEX) true if the instruction supports suppress all exceptions
        public bool CanSuppressAllExceptions {get; set;}

        //
        // Summary:
        //     (EVEX) true if a non-zero opmask register must be used
        public bool RequireNonZeroOpMaskRegister {get; set;}

        //
        // Summary:
        //     (EVEX) true if the instruction supports zeroing masking (if one of the opmask
        //     registers k1-k7 is used)
        public bool CanUseZeroingMasking {get; set;}
        //
        // Summary:
        //     true if the LOCK (F0) prefix can be used
        public bool CanUseLockPrefix {get; set;}
        //
        // Summary:
        //     true if the XACQUIRE (F2) prefix can be used
        public bool CanUseXacquirePrefix {get; set;}
        //
        // Summary:
        //     true if the XRELEASE (F3) prefix can be used
        public bool CanUseXreleasePrefix {get; set;}
        //
        // Summary:
        //     true if the REP / REPE (F3) prefixes can be used
        public bool CanUseRepPrefix {get; set;}
        //
        // Summary:
        //     true if the REPNE (F2) prefix can be used
        public bool CanUseRepnePrefix {get; set;}
        //
        // Summary:
        //     true if the BND (F2) prefix can be used
        public bool CanUseBndPrefix {get; set;}
        //
        // Summary:
        //     true if the HINT-TAKEN (3E) and HINT-NOT-TAKEN (2E) prefixes can be used
        public bool CanUseHintTakenPrefix {get; set;}
        //
        // Summary:
        //     true if the NOTRACK (3E) prefix can be used
        public bool CanUseNotrackPrefix {get; set;}
        //
        // Summary:
        //     Gets the opcode table
        public IceOpCodeTableKind Table {get; set;}
        //
        // Summary:
        //     Gets the mandatory prefix
        public IceMandatoryPrefix MandatoryPrefix {get; set;}
        //
        // Summary:
        //     Gets the opcode. 00000000xxh if it's 1-byte, 0000yyxxh if it's 2-byte (yy !=
        //     00, and yy is the first byte and xx the second byte). It doesn't include the
        //     table value, see Iced.Intel.OpCodeInfo.Table. Example values: 0xDFC0 (Iced.Intel.Code.Ffreep_sti),
        //     0x01D8 (Iced.Intel.Code.Vmrunw), 0x2A (Iced.Intel.Code.Sub_r8_rm8, Iced.Intel.Code.Cvtpi2ps_xmm_mmm64,
        //     etc).
        public uint OpCode {get; set;}
        //
        // Summary:
        //     true if it's part of a group
        public bool IsGroup {get; set;}
        //
        // Summary:
        //     Group index (0-7) or -1. If it's 0-7, it's stored in the 'reg' field of the modrm
        //     byte.
        public int GroupIndex {get; set;}
        //
        // Summary:
        //     Gets the number of operands
        public int OpCount {get; set;}
        //
        // Summary:
        //     Gets operand #0's opkind
        public IceOpCodeOperandKind Op0Kind {get; set;}
        //
        // Summary:
        //     Gets operand #1's opkind
        public IceOpCodeOperandKind Op1Kind {get; set;}
        //
        // Summary:
        //     Gets operand #2's opkind
        public IceOpCodeOperandKind Op2Kind {get; set;}
        //
        // Summary:
        //     (EVEX) true if an opmask register can be used
        public bool CanUseOpMaskRegister {get; set;}
        //
        // Summary:
        //     Gets operand #3's opkind
        public IceOpCodeOperandKind Op3Kind {get; set;}
        //
        // Summary:
        //     Gets operand #4's opkind
        public IceOpCodeOperandKind Op4Kind {get; set;}
        //
        // Summary:
        //     (EVEX) true if the instruction supports broadcasting (EVEX.b bit) (if it has
        //     a memory operand)
        public bool CanBroadcast {get; set;}
        //
        // Summary:
        //     Gets the code
        public IceOpCodeId Code {get; set;}
        //
        // Summary:
        //     Gets the encoding
        public IceEncodingKind Encoding {get; set;}
        //
        // Summary:
        //     true if it's an instruction, false if it's eg. Iced.Intel.Code.INVALID, db, dw,
        //     dd, dq
        public bool IsInstruction {get; set;}
        //
        // Summary:
        //     true if it's an instruction available in 16-bit mode
        public bool Mode16 {get; set;}
        //
        // Summary:
        //     true if it's an instruction available in 32-bit mode
        public bool Mode32 {get; set;}
        //
        // Summary:
        //     (EVEX) true if the instruction supports rounding control
        public bool CanUseRoundingControl {get; set;}
        //
        // Summary:
        //     true if an fwait (9B) instruction is added before the instruction
        public bool Fwait {get; set;}
        //
        // Summary:
        //     true if it's an instruction available in 64-bit mode
        public bool Mode64 {get; set;}
        //
        // Summary:
        //     (Legacy encoding) Gets the required address size (16,32,64) or 0 if no address
        //     size prefix (67) is needed
        public int AddressSize {get; set;}
        //
        // Summary:
        //     (VEX/XOP/EVEX) L / L'L value or default value if Iced.Intel.OpCodeInfo.IsLIG
        //     is true
        public uint L {get; set;}
        //
        // Summary:
        //     (VEX/XOP/EVEX) W value or default value if Iced.Intel.OpCodeInfo.IsWIG or Iced.Intel.OpCodeInfo.IsWIG32
        //     is true
        public uint W {get; set;}
        //
        // Summary:
        //     (VEX/XOP/EVEX) true if the L / L'L fields are ignored. EVEX: if reg-only ops
        //     and {er} (EVEX.b is set), L'L is the rounding control and not ignored.
        public bool IsLIG {get; set;}
        //
        // Summary:
        //     (VEX/XOP/EVEX) true if the W field is ignored in 16/32/64-bit modes
        public bool IsWIG {get; set;}
        //
        // Summary:
        //     (VEX/XOP/EVEX) true if the W field is ignored in 16/32-bit modes (but not 64-bit
        //     mode)
        public bool IsWIG32 {get; set;}
        //
        // Summary:
        //     (EVEX) Gets the tuple type
        public IceTupleType TupleType {get; set;}
        //
        // Summary:
        //     (Legacy encoding) Gets the required operand size (16,32,64) or 0 if no operand
        //     size prefix (66) or REX.W prefix is needed
        public int OperandSize {get; set;}

        public string OpCodeString {get; set;}

        public string InstructionString {get; set;}

        public override string ToString()
            => OpCodeString;
    }
}