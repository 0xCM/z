//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Defines 3-bit emission codes for vex map specification as determined by the presence
/// of a <see cref='AsmVL'/> value and a <see cref='XedVexKind'/> value
/// </summary>
public enum VexRXB : byte
{
    /// <summary>
    /// VL128 VEX_PREFIX=0  ->	emit 0b000
    /// </summary>
    [Symbol("L0 + VNP", "VL128 VEX_PREFIX=0")]
    L0_VNP = 0b000,

    /// <summary>
    /// VL128 VEX_PREFIX=1  ->	emit 0b001
    /// </summary>
    [Symbol("L0 + V0F", "VL128 VEX_PREFIX=1")]
    L0_V0F = 0b001,

    /// <summary>
    /// VL128 VEX_PREFIX=2  ->	emit 0b011
    /// </summary>
    [Symbol("L0 + V0F38", "VL128 VEX_PREFIX=2")]
    L0_V0F38 = 0b011,

    /// <summary>
    /// VL128 VEX_PREFIX=3  ->	emit 0b010
    /// </summary>
    [Symbol("L0 + V0F3A", "VL128 VEX_PREFIX=3")]
    L0_V0F3A = 0b010,

    /// <summary>
    /// VL256 VEX_PREFIX=0  ->	emit 0b100
    /// </summary>
    [Symbol("L1 + VNP", "VL256 VEX_PREFIX=0")]
    L1_VNP = 0b100,

    /// <summary>
    /// VL256 VEX_PREFIX=1  ->	emit 0b101
    /// </summary>
    [Symbol("L1 + V0F", "VL256 VEX_PREFIX=1")]
    L1_V0F = 0b101,

    /// <summary>
    /// VL256 VEX_PREFIX=2  ->	emit 0b111
    /// </summary>
    [Symbol("L1 + V0F38", "VL256 VEX_PREFIX=2")]
    L1_V0F38 = 0b111,

    /// <summary>
    /// VL256 VEX_PREFIX=3  ->	emit 0b110
    /// </summary>
    [Symbol("L1 + V0F3A", "VL256 VEX_PREFIX=3")]
    L1_V0F3A = 0b110,
}
