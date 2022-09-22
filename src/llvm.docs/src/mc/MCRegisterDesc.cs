//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    /// <summary>
    /// Defined by a tabegen-produced array when invoked with the --gen-register-info action. Each instance describes a specific register
    /// </summary>
    /// <summary>
    /// From https://github.com/llvm/llvm-project/llvm/include/llvm/MC/MCRegisterInfo.h
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct MCRegisterDesc
    {
        /// <summary>
        /// Printable name for the reg (for debugging)
        /// </summary>
        public uint Name;

        /// <summary>
        /// A zero terminated array of registers that are sub-registers of the specific register, e.g. AL, AH are sub-registers of AX.
        /// </summary>
        public uint SubRegs;

        /// <summary>
        /// A zero terminated array of registers that are super-registers of the specific register, e.g. RAX, EAX, are super-registers of AX.
        /// </summary>
        public uint SuperRegs;

        /// <summary>
        /// Offset into MCRI::SubRegIndices of a list of sub-register indices for each sub-register in SubRegs.
        /// </summary>
        public uint SubRegIndices;

        /// <summary>
        /// Points to the list of register units. The low 4 bits holds the Scale, the high bits hold an offset into DiffLists. See MCRegUnitIterator.
        /// </summary>
        public uint RegUnits;

        /// <summary>
        /// Index into list with lane mask sequences. The sequence contains a lanemask for every register unit
        /// </summary>
        public ushort RegUnitLaneMasks;

        [MethodImpl(Inline)]
        public MCRegisterDesc(uint name, uint subs, uint supers, uint subi, uint units, ushort masks)
        {
            Name = name;
            SubRegs = subs;
            SuperRegs = supers;
            SubRegIndices = subi;
            RegUnits = units;
            RegUnitLaneMasks = masks;
        }
    }
}