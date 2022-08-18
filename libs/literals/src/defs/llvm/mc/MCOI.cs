//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    using OC = MCOI.OperandConstraint;
    using OF = MCOI.OperandFlags;
    using OT = MCOI.OperandType;

    using static ApiAtomic;

    [LiteralProvider(llvm)]
    public readonly struct MCOI
    {
        /// <summary>
        /// These are flags set on operands, but should be considered
        /// private, all access should go through the MCOperandInfo accessors.
        /// See the accessors for a description of what these are.
        /// </summary>
        /// <remarks>
        /// From https://github.com/llvm/llvm-project/blob/68b9b769b510b9f5d3fe20e1f850ab829510673e/llvm/include/llvm/MC/MCInstrDesc.h
        /// </remarks>
        [SymSource(llvm_mc)]
        public enum OperandFlags : byte
        {
            LookupPtrRegClass = 0,

            Predicate,

            OptionalDef,

            BranchTarget
        }

        /// <summary>
        /// Operand constraints. These are encoded in 16 bits with one of the
        /// low-order 3 bits specifying that a constraint is present and the
        /// corresponding high-order hex digit specifying the constraint value.
        /// This allows for a maximum of 3 constraints.
        /// </summary>
        /// <remarks>
        /// From https://github.com/llvm/llvm-project/blob/68b9b769b510b9f5d3fe20e1f850ab829510673e/llvm/include/llvm/MC/MCInstrDesc.h
        /// </remarks>
        [SymSource(llvm_mc)]
        public enum OperandConstraint : byte
        {
            [Symbol("","Must be allocated the same register as specified value")]
            TIED_TO = 0,

            [Symbol("","If present, operand is an early clobber register.")]
            EARLY_CLOBBER
        };

        /// <summary>
        /// Classifies an MC operand
        /// </summary>
        /// <remarks>
        /// From https://github.com/llvm/llvm-project/blob/68b9b769b510b9f5d3fe20e1f850ab829510673e/llvm/include/llvm/MC/MCInstrDesc.h
        /// </remarks>
        [SymSource(llvm_mc)]
        public enum OperandType : byte
        {
            OPERAND_UNKNOWN = 0,

            OPERAND_IMMEDIATE = 1,

            OPERAND_REGISTER = 2,

            OPERAND_MEMORY = 3,

            OPERAND_PCREL = 4,

            OPERAND_FIRST_GENERIC = 6,

            OPERAND_GENERIC_0 = 6,

            OPERAND_GENERIC_1 = 7,

            OPERAND_GENERIC_2 = 8,

            OPERAND_GENERIC_3 = 9,

            OPERAND_GENERIC_4 = 10,

            OPERAND_GENERIC_5 = 11,

            OPERAND_LAST_GENERIC = 11,

            OPERAND_FIRST_GENERIC_IMM = 12,

            OPERAND_GENERIC_IMM_0 = 12,

            OPERAND_LAST_GENERIC_IMM = 12,

            OPERAND_FIRST_TARGET = 13,
        }

        public const byte OPERAND_UNKNOWN = (byte)OT.OPERAND_UNKNOWN;

        public const byte OPERAND_IMMEDIATE = (byte)OT.OPERAND_IMMEDIATE;

        public const byte OPERAND_REGISTER = (byte)OT.OPERAND_REGISTER;

        public const byte OPERAND_MEMORY = (byte)OT.OPERAND_MEMORY;

        public const byte OPERAND_PCREL = (byte)OT.OPERAND_PCREL;

        public const byte OPERAND_FIRST_GENERIC = (byte)OT.OPERAND_FIRST_GENERIC;

        public const byte OPERAND_GENERIC_0 = (byte)OT.OPERAND_GENERIC_0;

        public const byte OPERAND_GENERIC_1  = (byte)OT.OPERAND_GENERIC_1 ;

        public const byte OPERAND_GENERIC_2 = (byte)OT.OPERAND_GENERIC_2;

        public const byte OPERAND_GENERIC_3 = (byte)OT.OPERAND_GENERIC_3;

        public const byte OPERAND_GENERIC_4 = (byte)OT.OPERAND_GENERIC_4;

        public const byte OPERAND_GENERIC_5 = (byte)OT.OPERAND_GENERIC_5;

        public const byte OPERAND_LAST_GENERIC = (byte)OT.OPERAND_LAST_GENERIC;

        public const byte OPERAND_FIRST_GENERIC_IMM = (byte)OT.OPERAND_FIRST_GENERIC_IMM;

        public const byte OPERAND_GENERIC_IMM_0 = (byte)OT.OPERAND_GENERIC_IMM_0;

        public const byte OPERAND_LAST_GENERIC_IMM = (byte)OT.OPERAND_LAST_GENERIC_IMM;

        public const byte OPERAND_FIRST_TARGET = (byte)OT.OPERAND_FIRST_TARGET;

        public const byte TIED_TO = (byte)OC.TIED_TO;

        public const byte EARLY_CLOBBER = (byte)OC.EARLY_CLOBBER;

        public const byte LookupPtrRegClass = (byte)OF.LookupPtrRegClass;

        public const byte Predicate = (byte)OF.Predicate;

        public const byte OptionalDef = (byte)OF.OptionalDef;

        public const byte BranchTarget = (byte)OF.BranchTarget;
    }
}