//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
	/// <summary>
	/// Opcode table
	/// </summary>
	[Ignore]
	public enum IceOpCodeTableKind
    {
		/// <summary>
		/// Legacy encoding table
		/// </summary>
		Normal,

		/// <summary>
		/// 0Fxx table (legacy, VEX, EVEX)
		/// </summary>
		T0F,

		/// <summary>
		/// 0F38xx table (legacy, VEX, EVEX)
		/// </summary>
		T0F38,

		/// <summary>
		/// 0F3Axx table (legacy, VEX, EVEX)
		/// </summary>
		T0F3A,

		/// <summary>
		/// XOP8 table (XOP)
		/// </summary>
		XOP8,

		/// <summary>
		/// XOP9 table (XOP)
		/// </summary>
		XOP9,

		/// <summary>
		/// XOPA table (XOP)
		/// </summary>
		XOPA,
	}
}
