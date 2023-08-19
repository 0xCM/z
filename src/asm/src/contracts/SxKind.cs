//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Classifies a sign-extension operation
/// </summary>
public enum SxKind : byte
{
    None = 0,

    /// <summary>
    /// 8 bits -> 16 bits
    /// </summary>
    w8x16 = 1 | (2 << 3),

    /// <summary>
    /// 8 bits -> 32 bits
    /// </summary>
    w8x32 = 1 | (3 << 3),

    /// <summary>
    /// 8 bits -> 64 bits
    /// </summary>
    w8x64 = 1 | (4 << 3),

    /// <summary>
    /// 16 bits -> 32 bits
    /// </summary>
    w16x32 = 2 | (3 << 3),

    /// <summary>
    /// 16 bits -> 64 bits
    /// </summary>
    w16x64 = 2 | (4 << 3),

    /// <summary>
    /// 32 bits -> 64 bits
    /// </summary>
    w32x64 = 3 | (4 << 3)
}
