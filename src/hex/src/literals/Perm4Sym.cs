//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public enum Perm4Sym : byte
{
    /// <summary>
    /// Identifies the first of four permutation symbols
    /// </summary>
    [Symbol("00")]
    A = 0b00,

    /// <summary>
    /// Identifies the second of four permutation symbols
    /// </summary>
    [Symbol("01")]
    B = 0b01,

    /// <summary>
    /// Identifies the third of four permutation symbols
    /// </summary>
    [Symbol("10")]
    C = 0b10,

    /// <summary>
    /// Identifies the fourth of four permutation symbols
    /// </summary>
    [Symbol("11")]
    D = 0b11,
}
