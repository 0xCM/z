//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
	/// <summary>
	/// Tuple type (EVEX) which can be used to get the disp8 scale factor N
	/// </summary>
	[Ignore]
	public enum IceTupleType
    {
		/// <summary>
		/// N = 1
		/// </summary>
		None,
		/// <summary>
		/// N = b ? (W ? 8 : 4) : 16
		/// </summary>
		Full_128,
		/// <summary>
		/// N = b ? (W ? 8 : 4) : 32
		/// </summary>
		Full_256,
		/// <summary>
		/// N = b ? (W ? 8 : 4) : 64
		/// </summary>
		Full_512,
		/// <summary>
		/// N = b ? 4 : 8
		/// </summary>
		Half_128,
		/// <summary>
		/// N = b ? 4 : 16
		/// </summary>
		Half_256,
		/// <summary>
		/// N = b ? 4 : 32
		/// </summary>
		Half_512,
		/// <summary>
		/// N = 16
		/// </summary>
		Full_Mem_128,
		/// <summary>
		/// N = 32
		/// </summary>
		Full_Mem_256,
		/// <summary>
		/// N = 64
		/// </summary>
		Full_Mem_512,
		/// <summary>
		/// N = W ? 8 : 4
		/// </summary>
		Tuple1_Scalar,
		/// <summary>
		/// N = 1
		/// </summary>
		Tuple1_Scalar_1,
		/// <summary>
		/// N = 2
		/// </summary>
		Tuple1_Scalar_2,
		/// <summary>
		/// N = 4
		/// </summary>
		Tuple1_Scalar_4,
		/// <summary>
		/// N = 8
		/// </summary>
		Tuple1_Scalar_8,
		/// <summary>
		/// N = 4
		/// </summary>
		Tuple1_Fixed_4,
		/// <summary>
		/// N = 8
		/// </summary>
		Tuple1_Fixed_8,
		/// <summary>
		/// N = W ? 16 : 8
		/// </summary>
		Tuple2,
		/// <summary>
		/// N = W ? 32 : 16
		/// </summary>
		Tuple4,
		/// <summary>
		/// N = W ? error : 32
		/// </summary>
		Tuple8,
		/// <summary>
		/// N = 16
		/// </summary>
		Tuple1_4X,
		/// <summary>
		/// N = 8
		/// </summary>
		Half_Mem_128,
		/// <summary>
		/// N = 16
		/// </summary>
		Half_Mem_256,
		/// <summary>
		/// N = 32
		/// </summary>
		Half_Mem_512,
		/// <summary>
		/// N = 4
		/// </summary>
		Quarter_Mem_128,
		/// <summary>
		/// N = 8
		/// </summary>
		Quarter_Mem_256,
		/// <summary>
		/// N = 16
		/// </summary>
		Quarter_Mem_512,
		/// <summary>
		/// N = 2
		/// </summary>
		Eighth_Mem_128,
		/// <summary>
		/// N = 4
		/// </summary>
		Eighth_Mem_256,
		/// <summary>
		/// N = 8
		/// </summary>
		Eighth_Mem_512,
		/// <summary>
		/// N = 16
		/// </summary>
		Mem128,
		/// <summary>
		/// N = 8
		/// </summary>
		MOVDDUP_128,
		/// <summary>
		/// N = 32
		/// </summary>
		MOVDDUP_256,
		/// <summary>
		/// N = 64
		/// </summary>
		MOVDDUP_512,
	}
}
