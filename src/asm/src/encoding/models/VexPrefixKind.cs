//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Classfies vex prefix codes
/// </summary>
public enum VexPrefixKind : byte
{
    [Symbol("C4", "The leading byte of a 3-byte vex prefix sequence")]
    xC4 = 0xC4,

    [Symbol("C5", "The leading byte of a 2-byte vex prefix sequence")]
    xC5 = 0xC5,
}
