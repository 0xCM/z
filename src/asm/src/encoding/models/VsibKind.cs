//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public enum VsibKind : byte
{
    [Symbol("")]
    None,

    [Symbol("xmm")]
    Xmm,

    [Symbol("ymm")]
    Ymm,

    [Symbol("zmm")]
    Zmm    
}
