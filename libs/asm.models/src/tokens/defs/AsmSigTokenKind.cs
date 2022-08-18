//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifes <see cref='AsmSigTokens'/> members
    /// </summary>
    public enum AsmSigTokenKind : byte
    {
        None = 0,

        Rel,

        SysReg,

        GpReg,

        VReg,

        KReg,

        FpuReg,

        MmxRm,

        MmxReg,

        Imm,

        Mem,

        FpuInt,

        FpuMem,

        GpRm,

        GpRegTriple,

        GpRmTriple,

        VecRm,

        KRm,

        Moffs,

        Ptr,

        Rounding,

        MemPtr,

        MemPair,

        Vsib,

        BCastComposite,

        BCastMem,

        OpMask,

        RegLiteral,

        IntLiteral,

        Dependent,

        Modifier,
    }
}