//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    using static CNum;

    /// <summary>
    /// This holds information about one operand of a machine instruction,
    /// indicating the register class for register operands, etc.
    /// </summary>
    /// <remarks>
    /// From https://github.com/llvm/llvm-project/blob/68b9b769b510b9f5d3fe20e1f850ab829510673e/llvm/include/llvm/MC/MCInstrDesc.h
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct MCOperandInfo
    {
        /// <summary>
        /// This specifies the register class enumeration of the operand
        /// if the operand is a register. If isLookupPtrRegClass is set, then this is
        /// an index that is passed to TargetRegisterInfo::getPointerRegClass(x) to
        /// get a dynamic register class.
        /// </summary>
        public int16_t RegClass;

        /// <summary>
        /// These are flags from the MCOI::OperandFlags enum.
        /// </summary>
        public uint8_t Flags;

        /// <summary>
        /// Information about the type of the operand.
        /// </summary>
        public uint8_t OperandType;

        /// <summary>
        /// Operand constraints (see OperandConstraint enum).
        /// </summary>
        public uint16_t Constraints;

        /// <summary>
        /// Set if this operand is a pointer value and it requires a callback
        /// to look up its register class.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isLookupPtrRegClass()
            => Flags & (1 << MCOI.LookupPtrRegClass);

        /// <summary>
        /// Set if this is one of the operands that made up of the predicate
        /// operand that controls an isPredicable() instruction.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isPredicate()
            => Flags & (1 << MCOI.Predicate);

        /// <summary>
        /// Set if this operand is a optional def.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isOptionalDef()
            => Flags & (1 << MCOI.OptionalDef);

        /// <summary>
        /// Set if this operand is a branch target.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isBranchTarget()
            => Flags & (1 << MCOI.BranchTarget);

        [MethodImpl(Inline)]
        public bool isGenericType()
            => OperandType >= MCOI.OPERAND_FIRST_GENERIC && OperandType <= MCOI.OPERAND_LAST_GENERIC;

        [MethodImpl(Inline)]
        public uint8_t GenericTypeIndex()
            => OperandType - MCOI.OPERAND_FIRST_GENERIC;

        [MethodImpl(Inline)]
        public bool IsGenericImm()
            => OperandType >= MCOI.OPERAND_FIRST_GENERIC_IMM && OperandType <= MCOI.OPERAND_LAST_GENERIC_IMM;

        [MethodImpl(Inline)]
        public uint8_t GenericImmIndex()
            => OperandType - MCOI.OPERAND_FIRST_GENERIC_IMM;
    }
}