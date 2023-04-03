//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
	/// <summary>
	/// Default code size when an instruction was decoded
	/// </summary>
	[Ignore]
    public enum IceCodeSize
    {
		/// <summary>
		/// Unknown size
		/// </summary>
		Unknown	= 0,

		/// <summary>
		/// 16-bit code
		/// </summary>
		Code16 = 1,

		/// <summary>
		/// 32-bit code
		/// </summary>
		Code32 = 2,

		/// <summary>
		/// 64-bit code
		/// </summary>
		Code64 = 3,
	}
}
