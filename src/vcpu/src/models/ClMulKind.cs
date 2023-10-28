//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines a mask that specifies the left/right vector components from which a carry-less product will be formed
/// </summary>
public enum ClMulKind : byte
{
    /// <summary>
    /// For a product P = XY, multiply the lo(X) and lo(Y)
    /// </summary>
    Lo = 0x00,

    /// <summary>
    /// For a product P = XY, multiply the lo(X) and hi(Y)
    /// </summary>
    LoHi = 0x01,

    /// <summary>
    /// For a product P = XY, multiply the hi(X) and lo(Y)
    /// </summary>
    HiLo = 0x10,

    /// <summary>
    /// For a product P = XY, multiply the hi(X) and hi(Y)
    /// </summary>
    Hi = 0x11,
}
