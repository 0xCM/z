//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Classifes <see cref='AsmSigTokens'/> members
/// </summary>
[LiteralProvider(AsmSigTokens.GroupName)]
public enum AsmSigTokenKind : byte
{
    None = 0,

    Rel,

    SysReg,

    GpReg,

    VReg,

    KReg,

    FpuReg,

    Mmx,

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
