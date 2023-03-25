//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
	/// <summary>
	/// Operand, register and memory access
	/// </summary>
	[Ignore]
	public enum IceOpAccess
    {
		/// <summary>
		/// Nothing is read and nothing is written
		/// </summary>
		None,

		/// <summary>
		/// The value is read
		/// </summary>
		Read,

		/// <summary>
		/// The value is sometimes read and sometimes not
		/// </summary>
		CondRead,

		/// <summary>
		/// The value is completely overwritten
		/// </summary>
		Write,

		/// <summary>
		/// Conditional write, sometimes it's written and sometimes it's not modified
		/// </summary>
		CondWrite,

		/// <summary>
		/// The value is read and written
		/// </summary>
		ReadWrite,

		/// <summary>
		/// The value is read and sometimes written
		/// </summary>
		ReadCondWrite,

		/// <summary>
		/// The memory operand doesn't refer to memory (eg. lea instruction) or it's an instruction that doesn't
		/// read the data to a register or doesn't write to the memory location, it just prefetches/invalidates it,
		/// eg. invlpg, prefetchnta, vgatherpf0dps, etc.
		/// </summary>
		NoMemAccess,
	}
}