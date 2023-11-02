//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Defines REX field identifiers
/// </summary>
public enum RexFieldIndex : byte
{
    [Symbol("b")]
    B = 0,

    [Symbol("x")]
    X = 1,

    [Symbol("r")]
    R = 2,

    [Symbol("w")]
    W = 3,
}
