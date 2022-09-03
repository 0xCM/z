//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    /// <summary>
    /// An unsigned integer type large enough to represent all physical registers,
    /// but not necessarily virtual registers.
    /// </summary>
    /// <remarks>
    /// From https://github.com/llvm/llvm-project/blob/b0ab79ee2dfab993d95f01aaa2d51bbe6af9ecbe/llvm/include/llvm/MC/MCRegister.h
    /// </remarks>
    public struct MCPhysReg
    {
        ushort Data;

        [MethodImpl(Inline)]
        public MCPhysReg(ushort src)
        {
            Data = src;
        }

        public string Format()
            => Data.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MCPhysReg(ushort src)
            => new MCPhysReg(src);

        [MethodImpl(Inline)]
        public static implicit operator ushort(MCPhysReg src)
            => src.Data;
    }
}