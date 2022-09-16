//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    /// <summary>
    /// Wrapper class representing physical registers. Should be passed by value.
    /// Register numbers can represent physical registers, virtual registers, and
    /// sometimes stack slots. The unsigned values are divided into these ranges:
    ///   0           Not a register, can be used as a sentinel.
    ///   [1;2^30)    Physical registers assigned by TableGen.
    ///   [2^30;2^31) Stack slots. (Rarely used.)
    ///   [2^31;2^32) Virtual registers assigned by MachineRegisterInfo.
    /// Further sentinels can be allocated from the small negative integers.
    /// DenseMapInfo{unsigned} uses -1u and -2u.
    /// </summary>
    /// <remarks>
    /// From https://github.com/llvm/llvm-project/blob/b0ab79ee2dfab993d95f01aaa2d51bbe6af9ecbe/llvm/include/llvm/MC/MCRegister.h
    /// </remarks>
    public record struct MCRegister
    {
        uint Data;

        [MethodImpl(Inline)]
        MCRegister(uint src)
        {
            Data  = src;
        }


        [MethodImpl(Inline)]
        public bool isValid()
            => Data != NoRegister;

        public const uint NoRegister = 0u;

        public const uint FirstPhysicalReg = 1u;

        public const uint FirstStackSlot = 1u << 30;

        public const uint VirtualRegFlag = 1u << 31;

        [MethodImpl(Inline)]
        public static MCRegister from(uint src)
            => new MCRegister(src);

        /// <summary>
        /// This is the portion of the positive number space that is not a physical
        /// register. StackSlot values do not exist in the MC layer, see
        /// Register::isStackSlot() for the more information on them.
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline)]
        public static bool isStackSlot(MCRegister src)
            => FirstStackSlot <= src && src < VirtualRegFlag;

        /// <summary>
        /// Return true if the specified register number is in
        /// the physical register namespace.
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline)]
        public static bool isPhysicalRegister(MCRegister src)
            => FirstPhysicalReg <= src && src < FirstStackSlot;

        [MethodImpl(Inline)]
        public static implicit operator MCRegister(uint src)
            => from(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(MCRegister src)
            => src.Data;
    }
}