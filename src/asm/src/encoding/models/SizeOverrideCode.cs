//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Specifies a size override prefix
/// </summary>
public enum SizeOverrideCode : byte
{
    None = 0,

    /// <summary>
    /// Operand size override
    /// </summary>
    /// <remarks>
    /// The operand-size override prefix allows a program to switch between 16- and 32-bit operand sizes.
    /// Either size can be the default; use of the prefix selects the non-default size
    /// </remarks>
    [Symbol("66","Operand size override")]
    OSZ = 0x66,

    /// <summary>
    /// Address size override
    /// </summary>
    /// <remarks>
    /// The address-size override prefix allows programs to switch between 16- and 32-bit addressing.
    /// Either size can be the default; the prefix selects the non-default size
    /// </remarks>
    [Symbol("67", "Address size override")]
    ASZ = 0x67,
}

