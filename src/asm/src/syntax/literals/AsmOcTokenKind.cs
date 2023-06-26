//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static Asm.AsmOcTokens;

/// <summary>
/// Classifes <see cref='AsmOcTokenTokenGroup'/> members
/// </summary>
public enum AsmOcTokenKind : byte
{
    None = 0,

    /// <summary>
    /// Classifies the 256 literal hex bytes [0x00, 0x01, ..., 0xFF] defined by <see cref='Hex8Kind'/>
    /// </summary>
    Hex8,

    /// <summary>
    /// Classifies <see cref='RexToken'/> tokens
    /// </summary>
    Rex,

    /// <summary>
    /// Classifies <see cref='RexBToken'/> tokens
    /// </summary>
    RexB,

    /// <summary>
    /// Classifies <see cref='VexToken'/> tokens
    /// </summary>
    Vex,

    /// <summary>
    /// Classifies <see cref='EvexToken'/> tokens
    /// </summary>
    Evex,

    /// <summary>
    /// Classifies <see cref='RegDigitToken'/> tokens
    /// </summary>
    RegDigit,

    /// <summary>
    /// Classifies <see cref='SegOverrideToken'/> tokens
    /// </summary>
    SegOverride,

    /// <summary>
    /// Classifies <see cref='DispToken'/> tokens
    /// </summary>
    Disp,

    /// <summary>
    /// Classifies <see cref='ImmSizeToken'/> tokens
    /// </summary>
    ImmSize,

    /// <summary>
    /// Classifies <see cref='ExclusionToken'/> tokens
    /// </summary>
    Exclusion,

    /// <summary>
    /// Classifies <see cref='FpuDigitToken'/> tokens
    /// </summary>
    FpuDigit,

    /// <summary>
    /// Classifies <see cref='MaskToken'/> tokens
    /// </summary>
    Mask,

    /// <summary>
    /// Classifies <see cref='ModRmToken'/> tokens
    /// </summary>
    ModRm,

    /// <summary>
    /// Classifies a literal numeric value
    /// </summary>
    Integer,

    /// <summary>
    /// Classifies <see cref='OperatorToken'/> tokens
    /// </summary>
    Operator,

    /// <summary>
    /// Classifies <see cref='Hex16Token'/> tokens
    /// </summary>
    Hex16,

    /// <summary>
    /// Classifies <see cref='SeparatorToken'/> tokens
    /// </summary>
    Sep,
}
