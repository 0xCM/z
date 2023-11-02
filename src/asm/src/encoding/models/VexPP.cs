//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Specifies the VEX.pp or EVEX.pp bitfield
/// </summary>
public enum VexPP : byte
{
    None = 0,

    /// <summary>
    /// Indicates the 0x66 prefix immediately precedes the VEX prefix
    /// </summary>
    [Symbol("66")]
    X66 = 0b1,

    /// <summary>
    /// Indicates the 0xF3 prefix immediately precedes the VEX prefix
    /// </summary>
    [Symbol("F3")]
    F3 = 0b10,

    /// <summary>
    /// Indicates the 0xF2 prefix immediately precedes the VEX prefix
    /// </summary>
    [Symbol("F2")]
    F2 = 0b11,
}

