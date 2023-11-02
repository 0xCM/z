//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Identifies a vsib field segment
/// </summary>
public enum VsibField : byte
{
    /// <summary>
    /// VSIB.base, Bits [3:0]
    /// </summary>
    [Symbol("base")]
    Base = 0,

    /// <summary>
    /// VSIB.index, Bits [5:3]
    /// </summary>
    [Symbol("index")]
    Index = 3,

    /// <summary>
    /// VSIB.SS, Bits [7:6]
    /// </summary>
    [Symbol("SS")]
    SS = 6,
}
