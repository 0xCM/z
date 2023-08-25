//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[LiteralProvider(AsmRegTokens.GroupName)]
public enum AsmRegTokenKind
{
    None,

    [Symbol("gp")]
    Gp,

    [Symbol("gp8lo")]
    Gp8Lo,

    [Symbol("gp8hi")]
    Gp8Hi,

    [Symbol("gp16")]
    Gp16,

    [Symbol("gp32")]
    Gp32,

    [Symbol("gp64")]
    Gp64,

    [Symbol("xmm")]
    Xmm,

    [Symbol("ymm")]
    Ymm,

    [Symbol("zmm")]
    Zmm,

    [Symbol("mask")]
    Mask,

    [Symbol("bnd")]
    Bnd,

    [Symbol("ip")]
    Ip,

    [Symbol("flags")]
    Flags,

    [Symbol("sysptr")]
    SysPtr,

    [Symbol("mmx")]
    Mmx,

    [Symbol("fp")]
    Fp,

    [Symbol("seg")]
    Seg,

    [Symbol("test")]
    Test,

    [Symbol("cr")]
    Cr,

    [Symbol("xcr")]
    XCr,

    [Symbol("db")]
    Db
}
