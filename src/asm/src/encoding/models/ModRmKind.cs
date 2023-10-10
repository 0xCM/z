//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Identifies refinement classes of the ModRm byte
/// </summary>
public enum ModRmKind
{
    None = 0,

    /// <summary>
    /// Restricts the ModRm domain to values where mod[7:6] != 0b11
    /// </summary>
    RD = 1,

    /// <summary>
    /// Restricts the ModRm domain to values where mod[7:6] = 0b11
    /// </summary>
    RR = 2,
}
