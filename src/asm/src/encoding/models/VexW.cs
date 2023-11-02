//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Specifies the VEX.W bit
/// </summary>
public enum VexW : byte
{
    /// <summary>
    /// Unspecified
    /// </summary>
    None,

    /// <summary>
    /// VEX.W = 0
    /// </summary>
    W0,

    /// <summary>
    /// VEX.W = 1
    /// </summary>
    W1,

    /// <summary>
    /// Indicates the encoding can use the C5H form of the vex prefix; the instruction may be encoded using either the two-byte form or the three-byte form of VEX. 
    /// When encoding the instruction using the three-byte form of VEX, the value of VEX.W is ignored
    /// </summary>
    WIG
}