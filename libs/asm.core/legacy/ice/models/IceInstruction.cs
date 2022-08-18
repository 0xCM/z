//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class IceInstruction
    {
        /// <summary>
        /// The encoded bytes
        /// </summary>
        public BinaryCode Decoded {get;set;}

        /// <summary>
        /// Encapsulates the result of ToInstructionCodeString() and ToInstructionString()
        /// </summary>
        public AsmFormInfo Specifier {get;set;}

        /// <summary>
        /// Captures the formatted view of the instruction
        /// </summary>
        public string FormattedInstruction {get;set;}

        /// <summary>
        /// Retrieves the used memory array as specified by the InstructionInfo type
        /// </summary>
        public IceUsedMemory[] UsedMemory {get;set;}

        /// <summary>
        /// Captures the used register array as specified by the InstructionInfo type
        /// </summary>
        public IceUsedRegister[] UsedRegisters {get; set;}

        /// <summary>
        /// Captures the op access array as specified by the InstructionInfo type
        /// </summary>
        public Func<IceOpAccess[]> Access {get;set;}

        //
        // Summary:
        //     Gets the condition code if it's jcc, setcc, cmovcc else Iced.Intel.ConditionCode.None
        //     is returned
        public IceConditionCode ConditionCode {get; set;}
        //
        // Summary:
        //     true if the data is broadcasted (EVEX instructions only)
        public bool IsBroadcast {get; set;}
        //
        // Summary:
        //     Gets the size of the memory location that is referenced by the operand. See also
        //     Iced.Intel.Instruction.IsBroadcast. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Memory, Iced.Intel.OpKind.Memory64, Iced.Intel.OpKind.MemorySegSI,
        //     Iced.Intel.OpKind.MemorySegESI, Iced.Intel.OpKind.MemorySegRSI, Iced.Intel.OpKind.MemoryESDI,
        //     Iced.Intel.OpKind.MemoryESEDI, Iced.Intel.OpKind.MemoryESRDI
        public IceMemorySize MemorySize {get; set;}
        //
        // Summary:
        //     Gets the index register scale value, valid values are *1, *2, *4, *8. Use this
        //     property if the operand has kind Iced.Intel.OpKind.Memory
        public MemoryScale MemoryIndexScale {get; set;}
        //
        // Summary:
        //     Gets the memory operand's displacement. This should be sign extended to 64 bits
        //     if it's 64-bit addressing. Use this property if the operand has kind Iced.Intel.OpKind.Memory
        public uint MemoryDisplacement {get; set;}

        //
        // Summary:
        //     Gets the size of the memory displacement in bytes. Valid values are 0, 1 (16/32/64-bit),
        //     2 (16-bit), 4 (32-bit), 8 (64-bit). Note that the return value can be 1 and Iced.Intel.Instruction.MemoryDisplacement
        //     may still not fit in a signed byte if it's an EVEX encoded instruction. Use this
        //     property if the operand has kind Iced.Intel.OpKind.Memory
        public int MemoryDisplSize {get; set;}

        //
        // Summary:
        //     Gets the operand's immediate value. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Immediate8
        public byte Immediate8 {get; set;}
        //
        // Summary:
        //     Gets the operand's immediate value. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Immediate8_2nd
        public byte Immediate8_2nd {get; set;}
        //
        // Summary:
        //     Gets the operand's immediate value. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Immediate16
        public ushort Immediate16 {get; set;}
        //
        // Summary:
        //     Gets the operand's immediate value. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Immediate32
        public uint Immediate32 {get; set;}
        //
        // Summary:
        //     Gets the operand's immediate value. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Immediate64
        public ulong Immediate64 {get; set;}
        //
        // Summary:
        //     Gets the operand's immediate value. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Immediate8to16
        public short Immediate8to16 {get; set;}
        //
        // Summary:
        //     Gets the operand's immediate value. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Immediate8to32
        public int Immediate8to32 {get; set;}
        //
        // Summary:
        //     Gets the operand's immediate value. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Immediate8to64
        public long Immediate8to64 {get; set;}
        //
        // Summary:
        //     Gets the operand's immediate value. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Immediate32to64
        public long Immediate32to64 {get; set;}
        //
        // Summary:
        //     Gets the operand's 64-bit address value. Use this property if the operand has
        //     kind Iced.Intel.OpKind.Memory64
        public ulong MemoryAddress64 {get; set;}
        //
        // Summary:
        //     Gets the operand's branch target. Use this property if the operand has kind Iced.Intel.OpKind.NearBranch16
        public ushort NearBranch16 {get; set;}
        //
        // Summary:
        //     Gets the operand's branch target. Use this property if the operand has kind Iced.Intel.OpKind.NearBranch32
        public uint NearBranch32 {get; set;}
        //
        // Summary:
        //     Gets the operand's branch target. Use this property if the operand has kind Iced.Intel.OpKind.NearBranch64
        public ulong NearBranch64 {get; set;}
        //
        // Summary:
        //     Gets the near branch target if it's a call/jmp near branch instruction
        public ulong NearBranchTarget {get; set;}
        //
        // Summary:
        //     Gets the operand's branch target. Use this property if the operand has kind Iced.Intel.OpKind.FarBranch16
        public ushort FarBranch16 {get; set;}
        //
        // Summary:
        //     Gets the operand's branch target. Use this property if the operand has kind Iced.Intel.OpKind.FarBranch32
        public uint FarBranch32 {get; set;}
        //
        // Summary:
        //     Gets the operand's branch target selector. Use this property if the operand has
        //     kind Iced.Intel.OpKind.FarBranch16 or Iced.Intel.OpKind.FarBranch32
        public ushort FarBranchSelector {get; set;}

        //
        // Summary:
        //     Gets the effective segment register used to reference the memory location. Use
        //     this property if the operand has kind Iced.Intel.OpKind.Memory, Iced.Intel.OpKind.Memory64,
        //     Iced.Intel.OpKind.MemorySegSI, Iced.Intel.OpKind.MemorySegESI, Iced.Intel.OpKind.MemorySegRSI
        public IceRegister MemorySegment {get; set;}
        //
        // Summary:
        //     Gets the segment override prefix or Iced.Intel.Register.None if none. See also
        //     Iced.Intel.Instruction.MemorySegment. Use this property if the operand has kind
        //     Iced.Intel.OpKind.Memory, Iced.Intel.OpKind.Memory64, Iced.Intel.OpKind.MemorySegSI,
        //     Iced.Intel.OpKind.MemorySegESI, Iced.Intel.OpKind.MemorySegRSI
        public IceRegister SegmentPrefix {get; set;}
        //
        // Summary:
        //     Gets operand #4's kind if the operand exists (see Iced.Intel.Instruction.OpCount)
        public IceOpKind Op4Kind {get; set;}
        //
        // Summary:
        //     32-bit IP of the instruction
        public uint IP32 {get; set;}
        //
        // Summary:
        //     64-bit IP of the instruction
        public ulong IP {get; set;}
        //
        // Summary:
        //     16-bit IP of the next instruction
        public ushort NextIP16 {get; set;}
        //
        // Summary:
        //     32-bit IP of the next instruction
        public uint NextIP32 {get; set;}
        //
        // Summary:
        //     64-bit IP of the next instruction
        public ulong NextIP {get; set;}
        //
        // Summary:
        //     Gets the code size when the instruction was decoded. This value is informational
        //     and can be used by a formatter.
        public IceCodeSize CodeSize {get; set;}
        //
        // Summary:
        //     Instruction code
        public IceOpCodeId Code {get; set;}
        //
        // Summary:
        //     Gets the mnemonic
        public IceMnemonic Mnemonic {get; set;}

        public AsmMnemonic AsmMnemonic
            => Mnemonic.ToString().ToUpper();

        //
        // Summary:
        //     Gets the memory operand's base register or Iced.Intel.Register.None if none.
        //     Use this property if the operand has kind Iced.Intel.OpKind.Memory
        public IceRegister MemoryBase {get; set;}
        //
        // Summary:
        //     Gets the operand count. Up to 5 operands is allowed.
        public int OpCount {get; set;}
        //
        // Summary:
        //     Checks if the instruction has the XACQUIRE prefix (F2)
        public bool HasXacquirePrefix {get; set;}
        //
        // Summary:
        //     Checks if the instruction has the XACQUIRE prefix (F3)
        public bool HasXreleasePrefix {get; set;}
        //
        // Summary:
        //     Checks if the instruction has the REPE or REP prefix (F3)
        public bool HasRepPrefix {get; set;}
        //
        // Summary:
        //     Checks if the instruction has the REPE or REP prefix (F3)
        public bool HasRepePrefix {get; set;}
        //
        // Summary:
        //     Checks if the instruction has the REPNE prefix (F2)
        public bool HasRepnePrefix {get; set;}
        //
        // Summary:
        //     Checks if the instruction has the LOCK prefix (F0)
        public bool HasLockPrefix {get; set;}
        //
        // Summary:
        //     Gets operand #0's kind if the operand exists (see Iced.Intel.Instruction.OpCount)
        public IceOpKind Op0Kind {get; set;}
        //
        // Summary:
        //     Gets operand #1's kind if the operand exists (see Iced.Intel.Instruction.OpCount)
        public IceOpKind Op1Kind {get; set;}
        //
        // Summary:
        //     Gets operand #2's kind if the operand exists (see Iced.Intel.Instruction.OpCount)
        public IceOpKind Op2Kind {get; set;}
        //
        // Summary:
        //     Gets operand #3's kind if the operand exists (see Iced.Intel.Instruction.OpCount)
        public IceOpKind Op3Kind {get; set;}
        //
        // Summary:
        //     Gets the length of the instruction, 0-15 bytes. This is just informational. If
        //     you modify the instruction or create a new one, this property could return the
        //     wrong value.
        public int ByteLength {get; set;}

        public byte InstructionSize
        {
            [MethodImpl(Inline)]
            get => (byte)ByteLength;
        }

        //
        // Summary:
        //     Gets the memory operand's index register or Iced.Intel.Register.None if none.
        //     Use this property if the operand has kind Iced.Intel.OpKind.Memory
        public IceRegister MemoryIndex {get; set;}
        //
        // Summary:
        //     Gets operand #0's register value. Use this property if operand #0 (Iced.Intel.Instruction.Op0Kind)
        //     has kind Iced.Intel.OpKind.Register
        public IceRegister Op0Register {get; set;}
        //
        // Summary:
        //     Gets operand #1's register value. Use this property if operand #1 (Iced.Intel.Instruction.Op1Kind)
        //     has kind Iced.Intel.OpKind.Register
        public IceRegister Op1Register {get; set;}
        //
        // Summary:
        //     true if this is an instruction that implicitly uses the stack pointer (SP/ESP/RSP),
        //     eg. call, push, pop, ret, etc. See also Iced.Intel.Instruction.StackPointerIncrement
        public bool IsStackInstruction {get; set;}
        //
        // Summary:
        //     true if it's an instruction that saves or restores too many registers (eg. fxrstor,
        //     xsave, etc).
        public bool IsSaveRestoreInstruction {get; set;}
        //
        // Summary:
        //     All flags that are read by the CPU when executing the instruction
        public IceRflagsBits RflagsRead {get; set;}
        //
        // Summary:
        //     All flags that are written by the CPU, except those flags that are known to be
        //     undefined, always set or always cleared. See also Iced.Intel.Instruction.RflagsModified
        public IceRflagsBits RflagsWritten {get; set;}
        //
        // Summary:
        //     All flags that are always cleared by the CPU
        public IceRflagsBits RflagsCleared {get; set;}
        //
        // Summary:
        //     All flags that are always set by the CPU
        public IceRflagsBits RflagsSet {get; set;}
        //
        // Summary:
        //     All flags that are undefined after executing the instruction
        public IceRflagsBits RflagsUndefined {get; set;}
        //
        // Summary:
        //     All flags that are modified by the CPU. This is Iced.Intel.Instruction.RflagsWritten
        //     + Iced.Intel.Instruction.RflagsCleared + Iced.Intel.Instruction.RflagsSet + Iced.Intel.Instruction.RflagsUndefined
        public IceRflagsBits RflagsModified {get; set;}
        //
        // Summary:
        //     true if this is a privileged instruction
        public bool IsPrivileged {get; set;}
        //
        // Summary:
        //     Checks if it's a jcc short or jcc near instruction
        public bool IsJccShortOrNear {get; set;}
        //
        // Summary:
        //     Checks if it's a jcc short instruction
        public bool IsJccShort {get; set;}
        //
        // Summary:
        //     Checks if it's a jmp short instruction
        public bool IsJmpShort {get; set;}
        //
        // Summary:
        //     Checks if it's a jmp near instruction
        public bool IsJmpNear {get; set;}
        //
        // Summary:
        //     Checks if it's a jmp short or a jmp near instruction
        public bool IsJmpShortOrNear {get; set;}
        //
        // Summary:
        //     Checks if it's a jmp far instruction
        public bool IsJmpFar {get; set;}
        //
        // Summary:
        //     Checks if it's a call near instruction
        public bool IsCallNear {get; set;}
        //
        // Summary:
        //     Checks if it's a call far instruction
        public bool IsCallFar {get; set;}
        //
        // Summary:
        //     Checks if it's a jmp near reg/[mem] instruction
        public bool IsJmpNearIndirect {get; set;}
        //
        // Summary:
        //     Checks if it's a jmp far [mem] instruction
        public bool IsJmpFarIndirect {get; set;}
        //
        // Summary:
        //     Checks if it's a call near reg/[mem] instruction
        public bool IsCallNearIndirect {get; set;}
        //
        // Summary:
        //     Checks if it's a jcc near instruction
        public bool IsJccNear {get; set;}
        //
        // Summary:
        //     16-bit IP of the instruction
        public ushort IP16 {get; set;}
        //
        // Summary:
        //     Gets operand #2's register value. Use this property if operand #2 (Iced.Intel.Instruction.Op2Kind)
        //     has kind Iced.Intel.OpKind.Register
        public IceRegister Op2Register {get; set;}
        //
        // Summary:
        //     Gets operand #3's register value. Use this property if operand #3 (Iced.Intel.Instruction.Op3Kind)
        //     has kind Iced.Intel.OpKind.Register
        public IceRegister Op3Register {get; set;}
        //
        // Summary:
        //     Gets operand #4's register value. Use this property if operand #4 (Iced.Intel.Instruction.Op4Kind)
        //     has kind Iced.Intel.OpKind.Register
        public IceRegister Op4Register {get; set;}
        //
        // Summary:
        //     Gets the opmask register (Iced.Intel.Register.K1 - Iced.Intel.Register.K7) or
        //     Iced.Intel.Register.None if none
        public IceRegister OpMask {get; set;}
        //
        // Summary:
        //     true if there's an opmask register (Iced.Intel.Instruction.OpMask)
        public bool HasOpMask {get; set;}
        //
        // Summary:
        //     true if zeroing-masking, false if merging-masking. Only used by most EVEX encoded
        //     instructions that use opmask registers.
        public bool ZeroingMasking {get; set;}
        //
        // Summary:
        //     true if merging-masking, false if zeroing-masking. Only used by most EVEX encoded
        //     instructions that use opmask registers.
        public bool MergingMasking {get; set;}
        //
        // Summary:
        //     Rounding control (Iced.Intel.Instruction.SuppressAllExceptions is implied but
        //     still returns false) or Iced.Intel.RoundingControl.None if the instruction doesn't
        //     use it.
        public IceRoundingControl RoundingControl {get; set;}
        //
        // Summary:
        //     Number of elements in a db/dw/dd/dq directive. Can only be called if Iced.Intel.Instruction.Code
        //     is Iced.Intel.Code.DeclareByte, Iced.Intel.Code.DeclareWord, Iced.Intel.Code.DeclareDword,
        //     Iced.Intel.Code.DeclareQword
        public int DeclareDataCount {get; set;}
        //
        // Summary:
        //     Checks if this is a VSIB instruction, see also Iced.Intel.Instruction.IsVsib32,
        //     Iced.Intel.Instruction.IsVsib64
        public bool IsVsib {get; set;}
        //
        // Summary:
        //     true if the instruction isn't available in real mode or virtual 8086 mode
        public bool IsProtectedMode {get; set;}
        //
        // Summary:
        //     VSIB instructions only (Iced.Intel.Instruction.IsVsib): true if it's using 32-bit
        //     indexes, false if it's using 64-bit indexes
        public bool IsVsib32 {get; set;}
        //
        // Summary:
        //     Suppress all exceptions (EVEX encoded instructions). Note that if Iced.Intel.Instruction.RoundingControl
        //     is not Iced.Intel.RoundingControl.None, SAE is implied but this property will
        //     still return false.
        public bool SuppressAllExceptions {get; set;}
        //
        // Summary:
        //     Checks if the memory operand is RIP/EIP relative
        public bool IsIPRelativeMemoryOperand {get; set;}
        //
        // Summary:
        //     Gets the RIP/EIP releative address ((Iced.Intel.Instruction.NextIP or Iced.Intel.Instruction.NextIP32)
        //     + Iced.Intel.Instruction.MemoryDisplacement). This property is only valid if
        //     there's a memory operand with RIP/EIP relative addressing.
        public MemoryAddress IPRelativeMemoryAddress {get; set;}
        //
        // Summary:
        //     Gets the Iced.Intel.OpCodeInfo
        public IceOpCodeInfo OpCode {get; set;}
        //
        // Summary:
        //     Gets the number of bytes added to SP/ESP/RSP or 0 if it's not an instruction
        //     that pushes or pops data. This method assumes the instruction doesn't change
        //     privilege (eg. iret/d/q). If it's the leave instruction, this method returns
        //     0.
        public int StackPointerIncrement {get; set;}
        //
        // Summary:
        //     Instruction encoding, eg. legacy, VEX, EVEX, ...
        public IceEncodingKind Encoding {get; set;}
        //
        // Summary:
        //     Gets the CPU or CPUID feature flags
        public IceCpuidFeature[] CpuidFeatures {get; set;}
        //
        // Summary:
        //     Flow control info
        public IceFlowControl FlowControl {get; set;}
        //
        // Summary:
        //     VSIB instructions only (Iced.Intel.Instruction.IsVsib): true if it's using 64-bit
        //     indexes, false if it's using 32-bit indexes
        public bool IsVsib64 {get; set;}
        //
        // Summary:
        //     Checks if it's a call far [mem] instruction
        public bool IsCallFarIndirect {get; set;}

        public override string ToString()
            => FormattedInstruction;
    }
}