//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    /// <summary>
    /// Target independent information on a fixup kind.
    /// </summary>
    /// <remarks>
    /// Taken from https://github.com/llvm/llvm-project/blob/2e24219d3cbfcb8c824c58872f97de0a2e94a7c8/llvm/include/llvm/MC/MCFixupKindInfo.h
    /// </remarks>
    public struct MCFixupKindInfo
    {
        public enum FixupKindFlags : byte
        {
            /// Is this fixup kind PCrelative? This is used by the assembler backend to
            /// evaluate fixup values in a target independent manner when possible.
            FKF_IsPCRel = (1 << 0),

            /// Should this fixup kind force a 4-byte aligned effective PC value?
            FKF_IsAlignedDownTo32Bits = (1 << 1),

            /// Should this fixup be evaluated in a target dependent manner?
            FKF_IsTarget = (1 << 2),

            /// This fixup kind should be resolved if defined.
            FKF_Constant = 1 << 3,
        }

        /// A target specific name for the fixup kind. The names will be unique for
        /// distinct kinds on any given target.
        public Label Name;

        /// The bit offset to write the relocation into.
        public uint TargetOffset;

        /// The number of bits written by this fixup. The bits are assumed to be
        /// contiguous.
        public uint TargetSize;

        /// Flags describing additional information on this fixup kind.
        public uint Flags;
    }
}