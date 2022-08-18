//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
	/// <summary>
	/// Instruction encoding
	/// </summary>
	[Ignore]
	public enum IceEncodingKind
    {
		/// <summary>
		/// Legacy encoding
		/// </summary>
		Legacy,

		/// <summary>
		/// VEX encoding
		/// </summary>
		VEX,

		/// <summary>
		/// EVEX encoding
		/// </summary>
		EVEX,

		/// <summary>
		/// XOP encoding
		/// </summary>
		XOP,

		/// <summary>
		/// 3DNow! encoding
		/// </summary>
		D3NOW,
	}
}