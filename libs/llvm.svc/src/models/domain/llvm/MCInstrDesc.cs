//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.X86
{
    using static CNum;
    using llvm.mc;

    /// <summary>
    /// Describe properties that are true of each instruction in the target
    /// description file. This captures information about side effects, register
    /// use and many other things. There is one instance of this struct for each
    /// target instruction class, and the MachineInstr class points to this struct
    /// directly to describe itself.
    /// </summary>
    /// <remarks>
    /// From https://github.com/llvm/llvm-project/blob/68b9b769b510b9f5d3fe20e1f850ab829510673e/llvm/include/llvm/MC/MCInstrDesc.h
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct MCInstrDesc
    {
        /// <summary>
        /// The opcode number
        /// </summary>
        public int16_t OpCode;

        /// <summary>
        /// Return the number of declared MachineOperands for this
        /// MachineInstruction. Note that variadic (isVariadic() returns true)
        /// instructions may have additional operands at the end of the list, and note
        /// that the machine instruction may include implicit register def/uses as
        /// well.
        /// </summary>
        public int16_t NumOperands;

        /// <summary>
        /// Specifies the number of MachineOperands that are register
        /// definitions. Register definitions always occur at the start of the
        /// machine operand list. This is the number of "outs" in the .td file,
        /// and does not include implicit defs.
        /// </summary>
        public uint8_t NumDefs;

        /// <summary>
        /// Number of bytes in encoding
        /// </summary>
        public uint8_t Size;

        /// <summary>
        /// enum identifying instr sched class
        /// </summary>
        public int16_t SchedClass;

        /// <summary>
        /// Flags identifying machine instr class
        /// </summary>
        public uint64_t Flags;

        /// <summary>
        /// Target Specific Flag values
        /// </summary>
        public uint64_t TSFlags;

        /// <summary>
        /// Registers implicitly read by this instr
        /// </summary>
        public Index<MCPhysReg> ImplicitUses;

        /// <summary>
        /// Registers implicitly defined by this instr
        /// </summary>
        public Index<MCPhysReg> ImplicitDefs;

        /// <summary>
        /// 'NumOperands' entries about operands
        /// </summary>
        public Index<MCOperandInfo> OpInfo;

        /// <summary>
        /// Returns true if this instruction is emitted before instruction selection
        /// and should be legalized/regbankselected/selected.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isPreISelOpcode()
            => Flags & (1ul << MCID.PreISelOpcode);

        /// <summary>
        /// Return true if this instruction can have a variable number of
        /// operands. In this case, the variable operands will be after the normal
        /// operands but before the implicit definitions and uses (if any are
        /// present).
        /// </summary>
        [MethodImpl(Inline)]
        public bool isVariadic()
            => Flags & (1ul << MCID.Variadic);

        /// <summary>
        /// Set if this instruction has an optional definition, e.g.
        /// ARM instructions which can set condition code if 's' bit is set.
        /// </summary>
        [MethodImpl(Inline)]
        public bool hasOptionalDef()
            => Flags & (1ul << MCID.HasOptionalDef);

        /// <summary>
        /// Return true if this is a pseudo instruction that doesn't
        /// correspond to a real machine instruction.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isPseudo()
         => Flags & (1ul << MCID.Pseudo);

        /// <summary>
        /// Return true if the instruction is a return.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isReturn()
          => Flags & (1ul << MCID.Return);

        /// <summary>
        /// Return true if the instruction is an add instruction.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isAdd()
          => Flags & (1ul << MCID.Add);

        /// <summary>
        /// Return true if this instruction is a trap.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isTrap()
          => Flags & (1ul << MCID.Trap);

        /// <summary>
        /// Return true if the instruction is a register to register move.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isMoveReg()
            => Flags & (1ul << MCID.MoveReg);

        /// <summary>
        ///  Return true if the instruction is a call.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isCall()
        { return Flags & (1ul << MCID.Call); }

        /// <summary>
        /// Returns true if the specified instruction stops control flow
        /// from executing the instruction immediately following it.  Examples include
        /// unconditional branches and return instructions.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isBarrier()
        { return Flags & (1ul << MCID.Barrier); }

        /// <summary>
        /// Returns true if this instruction part of the terminator for
        /// a basic block. Typically this is things like return and branch
        /// instructions.
        /// Various passes use this to insert code into the bottom of a basic block,
        /// but before control flow occurs.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isTerminator()
            => Flags & (1ul << MCID.Terminator);

        /// <summary>
        /// Returns true if this is a conditional, unconditional, or
        /// indirect branch.  Predicates below can be used to discriminate between
        /// these cases, and the TargetInstrInfo::analyzeBranch method can be used to
        /// get more information.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isBranch()
            => Flags & (1ul << MCID.Branch);

        /// <summary>
        /// Return true if this is an indirect branch, such as a
        /// branch through a register.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isIndirectBranch()
            => Flags & (1ul << MCID.IndirectBranch);

        /// <summary>
        /// Return true if this is a branch which may fall
        /// through to the next instruction or may transfer control flow to some other
        /// block. The TargetInstrInfo::analyzeBranch method can be used to get more
        /// information about this branch.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isConditionalBranch()
            => isBranch() && !isBarrier() && !isIndirectBranch();

        /// <summary>
        /// Return true if this is a branch which always
        /// transfers control flow to some other block.  The
        /// TargetInstrInfo::analyzeBranch method can be used to get more information
        /// about this branch.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isUnconditionalBranch()
            => isBranch() && isBarrier() && !isIndirectBranch();

        /// <summary>
        /// Return true if this instruction has a predicate operand
        /// that controls execution. It may be set to 'always', or may be set to other
        /// values. There are various methods in TargetInstrInfo that can be used to
        /// control and modify the predicate in this instruction.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isPredicable()
            => Flags & (1ul << MCID.Predicable);

        /// <summary>
        /// Return true if this instruction is a comparison.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isCompare()
            => Flags & (1ul << MCID.Compare);

        /// <summary>
        /// Return true if this instruction is a move immediate (including conditional moves) instruction.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isMoveImmediate()
            => Flags & (1ul << MCID.MoveImm);

        /// <summary>
        /// Return true if this instruction is a bitcast instruction.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isBitcast()
            => Flags & (1ul << MCID.Bitcast);

        /// <summary>
        /// Return true if this is a select instruction.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isSelect()
            => Flags & (1ul << MCID.Select);

        /// <summary>
        /// Return true if this instruction cannot be safely
        /// duplicated.  For example, if the instruction has a unique labels attached
        /// to it, duplicating it would cause multiple definition errors.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isNotDuplicable()
            => Flags & (1ul << MCID.NotDuplicable);

        /// <summary>
        /// Returns true if the specified instruction has a delay slot which
        /// must be filled by the code generator.
        /// </summary>
        [MethodImpl(Inline)]
        public bool hasDelaySlot()
            => Flags & (1ul << MCID.DelaySlot);

        /// <summary>
        /// Return true for instructions that can be folded as memory operands
        /// in other instructions. The most common use for this is instructions that
        /// are simple loads from memory that don't modify the loaded value in any
        /// way, but it can also be used for instructions that can be expressed as
        /// constant-pool loads, such as V_SETALLONES on x86, to allow them to be
        /// folded when it is beneficial. This should only be set on instructions
        /// that return a value in their only virtual register definition.
        /// </summary>
        [MethodImpl(Inline)]
        public bool canFoldAsLoad()
             => Flags & (1ul << MCID.FoldableAsLoad);

        /// <summary>
        /// Return true if this instruction behaves
        /// the same way as the generic REG_SEQUENCE instructions.
        /// E.g., on ARM,
        /// dX VMOVDRR rY, rZ
        /// is equivalent to
        /// dX = REG_SEQUENCE rY, ssub_0, rZ, ssub_1.
        /// Note that for the optimizers to be able to take advantage of
        /// this property, TargetInstrInfo::getRegSequenceLikeInputs has to be
        /// override accordingly.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isRegSequenceLike()
            => Flags & (1ul << MCID.RegSequence);

        /// <summary>
        /// Return true if this instruction behaves the same way as the generic EXTRACT_SUBREG instructions.
        /// E.g., on ARM,
        /// rX, rY VMOVRRD dZ
        /// is equivalent to two EXTRACT_SUBREG:
        /// rX = EXTRACT_SUBREG dZ, ssub_0
        /// rY = EXTRACT_SUBREG dZ, ssub_1
        /// Note that for the optimizers to be able to take advantage of
        /// this property, TargetInstrInfo::getExtractSubregLikeInputs has to be
        /// override accordingly.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isExtractSubregLike()
            => Flags & (1ul << MCID.ExtractSubreg);

        /// <summary>
        /// Return true if this instruction behaves
        /// the same way as the generic INSERT_SUBREG instructions.
        /// E.g., on ARM,
        /// dX = VSETLNi32 dY, rZ, Imm
        /// is equivalent to a INSERT_SUBREG:
        /// dX = INSERT_SUBREG dY, rZ, translateImmToSubIdx(Imm)
        /// Note that for the optimizers to be able to take advantage of
        /// this property, TargetInstrInfo::getInsertSubregLikeInputs has to be
        /// override accordingly.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isInsertSubregLike()
          => Flags & (1ul << MCID.InsertSubreg);

        /// <summary>
        /// Return true if this instruction is convergent.
        /// Convergent instructions may not be made control-dependent on any
        /// additional values.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isConvergent()
         => Flags & (1ul << MCID.Convergent);

        /// <summary>
        /// Return true if this instruction could possibly read memory.
        /// Instructions with this flag set are not necessarily simple load
        /// instructions, they may load a value and modify it, for example.
        /// </summary>
        [MethodImpl(Inline)]
        public bool mayLoad()
            => Flags & (1ul << MCID.MayLoad);

        /// <summary>
        /// Return true if this instruction could possibly modify memory.
        /// Instructions with this flag set are not necessarily simple store
        /// instructions, they may store a modified value based on their operands, or
        /// may not actually modify anything, for example.
        /// </summary>
        [MethodImpl(Inline)]
        public bool mayStore()
            => Flags & (1ul << MCID.MayStore);

        /// <summary>
        /// Return true if this instruction may raise a floating-point exception.
        /// </summary>
        [MethodImpl(Inline)]
        public bool mayRaiseFPException()
            => Flags & (1ul << MCID.MayRaiseFPException);

        /// <summary>
        /// Return true if this instruction has side effects that are not modeled by other flags.
        /// This does not return true for instructions whose effects are captured by:
        ///  1. Their operand list and implicit definition/use list. Register use/def info is explicit for instructions.
        ///  2. Memory accesses.  Use mayLoad/mayStore.
        ///  3. Calling, branching, returning: use isCall/isReturn/isBranch.
        /// Examples of side effects would be modifying 'invisible' machine state like
        /// a control register, flushing a cache, modifying a register invisible to
        /// LLVM, etc.
        /// </summary>
        [MethodImpl(Inline)]
        public bool hasUnmodeledSideEffects()
            => Flags & (1ul << MCID.UnmodeledSideEffects);

        /// <summary>
        /// Return true if this may be a 2- or 3-address instruction (of the
        /// form "X = op Y, Z, ..."), which produces the same result if Y and Z are
        /// exchanged.  If this flag is set, then the
        /// TargetInstrInfo::commuteInstruction method may be used to hack on the
        /// instruction.
        /// Note that this flag may be set on instructions that are only commutable
        /// sometimes. In these cases, the call to commuteInstruction will fail.
        /// Also note that some instructions require non-trivial modification to
        /// commute them.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isCommutable()
            => Flags & (1ul << MCID.Commutable);

        /// <summary>
        /// Return true if this is a 2-address instruction which can be changed
        /// into a 3-address instruction if needed.  Doing this transformation can be
        /// profitable in the register allocator, because it means that the
        /// instruction can use a 2-address form if possible, but degrade into a less
        /// efficient form if the source and dest register cannot be assigned to the
        /// same register.  For example, this allows the x86 backend to turn a "shl
        /// reg, 3" instruction into an LEA instruction, which is the same speed as
        /// the shift but has bigger code size.
        /// If this returns true, then the target must implement the
        /// TargetInstrInfo::convertToThreeAddress method for this instruction, which
        /// is allowed to fail if the transformation isn't valid for this specific
        /// instruction (e.g. shl reg, 4 on x86).
        /// </summary>
        [MethodImpl(Inline)]
        public bool isConvertibleTo3Addr()
            => Flags & (1ul << MCID.ConvertibleTo3Addr);

        /// Returns true if this instruction is a candidate for remat. This
        /// flag is only used in TargetInstrInfo method isTriviallyRematerializable.
        ///
        /// If this flag is set, the isReallyTriviallyReMaterializable()
        /// or isReallyTriviallyReMaterializableGeneric methods are called to verify
        /// the instruction is really rematable.
        [MethodImpl(Inline)]
        bool isRematerializable()
            => Flags & (1ul << MCID.Rematerializable);

        /// <summary>
        /// Returns true if this instruction has the same cost (or less) than a
        /// move instruction. This is useful during certain types of optimizations
        /// (e.g., remat during two-address conversion or machine licm) where we would
        /// like to remat or hoist the instruction, but not if it costs more than
        /// moving the instruction into the appropriate register. Note, we are not
        /// marking copies from and to the same register class with this flag.
        /// This method could be called by interface TargetInstrInfo::isAsCheapAsAMove
        /// for different subtargets.
        /// </summary>
        [MethodImpl(Inline)]
        public bool isAsCheapAsAMove()
            => Flags & (1ul << MCID.CheapAsAMove);

        /// Returns true if this instruction source operands have special
        /// register allocation requirements that are not captured by the operand
        /// register classes. e.g. ARM::STRD's two source registers must be an even /
        /// odd pair, ARM::STM registers have to be in ascending order.  Post-register
        /// allocation passes should not attempt to change allocations for sources of
        /// instructions with this flag.
        [MethodImpl(Inline)]
        public bool hasExtraSrcRegAllocReq()
            => Flags & (1ul << MCID.ExtraSrcRegAllocReq);

        /// <summary>
        /// Returns true if this instruction def operands have special register
        /// allocation requirements that are not captured by the operand register
        /// classes. e.g. ARM::LDRD's two def registers must be an even / odd pair,
        /// ARM::LDM registers have to be in ascending order.  Post-register
        /// allocation passes should not attempt to change allocations for definitions
        /// of instructions with this flag.
        /// </summary>
        [MethodImpl(Inline)]
        public bool hasExtraDefRegAllocReq()
            => Flags & (1ul << MCID.ExtraDefRegAllocReq);
    }
}