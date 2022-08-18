//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    using System;

	/// <summary>
	/// RFLAGS bits supported by the instruction info code
	/// </summary>
	[Flags,Ignore]
	public enum IceRflagsBits
    {
		None	= 0,
		OF		= 0x00000001,
		SF		= 0x00000002,
		ZF		= 0x00000004,
		AF		= 0x00000008,
		CF		= 0x00000010,
		PF		= 0x00000020,
		DF		= 0x00000040,
		IF		= 0x00000080,
		AC		= 0x00000100,

	}

    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
