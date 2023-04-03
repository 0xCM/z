//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
	/// <summary>
	/// Mandatory prefix
	/// </summary>
	[Ignore]
	public enum IceMandatoryPrefix
    {
		/// <summary>
		/// No mandatory prefix (legacy and 3DNow! tables only)
		/// </summary>
		None,

		/// <summary>
		/// Empty mandatory prefix (no 66, F3 or F2 prefix)
		/// </summary>
		PNP,

		/// <summary>
		/// 66 prefix
		/// </summary>
		P66,

		/// <summary>
		/// F3 prefix
		/// </summary>
		PF3,

		/// <summary>
		/// F2 prefix
		/// </summary>
		PF2,
	}
}
