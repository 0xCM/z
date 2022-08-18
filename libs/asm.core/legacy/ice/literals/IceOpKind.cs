//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
	/// <summary>
	/// Instruction operand kind
	/// </summary>
	[Ignore]
	public enum IceOpKind : byte
	{
		/// <summary>
		/// A register (<see cref="Intel.Register"/>).
		/// This operand kind uses <see cref="IceInstruction.Op0Register"/>, <see cref="IceInstruction.Op1Register"/>,
		/// <see cref="IceInstruction.Op2Register"/> or <see cref="IceInstruction.Op3Register"/> depending on operand number.
		/// See also <see cref="IceInstruction.GetOpRegister(int)"/>.
		/// </summary>
		Register = 0,// Code assumes this is 0

		/// <summary>
		/// Near 16-bit branch. This operand kind uses <see cref="IceInstruction.NearBranch16"/>
		/// </summary>
		NearBranch16,

		/// <summary>
		/// Near 32-bit branch. This operand kind uses <see cref="IceInstruction.NearBranch32"/>
		/// </summary>
		NearBranch32,

		/// <summary>
		/// Near 64-bit branch. This operand kind uses <see cref="IceInstruction.NearBranch64"/>
		/// </summary>
		NearBranch64,

		/// <summary>
		/// Far 16-bit branch. This operand kind uses <see cref="IceInstruction.FarBranch16"/> and <see cref="IceInstruction.FarBranchSelector"/>
		/// </summary>
		FarBranch16,

		/// <summary>
		/// Far 32-bit branch. This operand kind uses <see cref="IceInstruction.FarBranch32"/> and <see cref="IceInstruction.FarBranchSelector"/>
		/// </summary>
		FarBranch32,

		/// <summary>
		/// 8-bit constant. This operand kind uses <see cref="IceInstruction.Immediate8"/>
		/// </summary>
		Immediate8,

		/// <summary>
		/// 8-bit constant used by the enter, extrq, insertq instructions. This operand kind uses <see cref="IceInstruction.Immediate8_2nd"/>
		/// </summary>
		Immediate8_2nd,

		/// <summary>
		/// 16-bit constant. This operand kind uses <see cref="IceInstruction.Immediate16"/>
		/// </summary>
		Immediate16,

		/// <summary>
		/// 32-bit constant. This operand kind uses <see cref="IceInstruction.Immediate32"/>
		/// </summary>
		Immediate32,

		/// <summary>
		/// 64-bit constant. This operand kind uses <see cref="IceInstruction.Immediate64"/>
		/// </summary>
		Immediate64,

		/// <summary>
		/// An 8-bit value sign extended to 16 bits. This operand kind uses <see cref="IceInstruction.Immediate8to16"/>
		/// </summary>
		Immediate8to16,

		/// <summary>
		/// An 8-bit value sign extended to 32 bits. This operand kind uses <see cref="IceInstruction.Immediate8to32"/>
		/// </summary>
		Immediate8to32,

		/// <summary>
		/// An 8-bit value sign extended to 64 bits. This operand kind uses <see cref="IceInstruction.Immediate8to64"/>
		/// </summary>
		Immediate8to64,

		/// <summary>
		/// A 32-bit value sign extended to 64 bits. This operand kind uses <see cref="IceInstruction.Immediate32to64"/>
		/// </summary>
		Immediate32to64,

		/// <summary>
		/// seg:[si]. This operand kind uses <see cref="IceInstruction.MemorySize"/>, <see cref="IceInstruction.MemorySegment"/>, <see cref="IceInstruction.SegmentPrefix"/>
		/// </summary>
		MemorySegSI,

		/// <summary>
		/// seg:[esi]. This operand kind uses <see cref="IceInstruction.MemorySize"/>, <see cref="IceInstruction.MemorySegment"/>, <see cref="IceInstruction.SegmentPrefix"/>
		/// </summary>
		MemorySegESI,

		/// <summary>
		/// seg:[rsi]. This operand kind uses <see cref="IceInstruction.MemorySize"/>, <see cref="IceInstruction.MemorySegment"/>, <see cref="IceInstruction.SegmentPrefix"/>
		/// </summary>
		MemorySegRSI,

		/// <summary>
		/// seg:[di]. This operand kind uses <see cref="IceInstruction.MemorySize"/>, <see cref="IceInstruction.MemorySegment"/>, <see cref="IceInstruction.SegmentPrefix"/>
		/// </summary>
		MemorySegDI,

		/// <summary>
		/// seg:[edi]. This operand kind uses <see cref="IceInstruction.MemorySize"/>, <see cref="IceInstruction.MemorySegment"/>, <see cref="IceInstruction.SegmentPrefix"/>
		/// </summary>
		MemorySegEDI,

		/// <summary>
		/// seg:[rdi]. This operand kind uses <see cref="IceInstruction.MemorySize"/>, <see cref="IceInstruction.MemorySegment"/>, <see cref="IceInstruction.SegmentPrefix"/>
		/// </summary>
		MemorySegRDI,

		/// <summary>
		/// es:[di]. This operand kind uses <see cref="IceInstruction.MemorySize"/>
		/// </summary>
		MemoryESDI,

		/// <summary>
		/// es:[edi]. This operand kind uses <see cref="IceInstruction.MemorySize"/>
		/// </summary>
		MemoryESEDI,

		/// <summary>
		/// es:[rdi]. This operand kind uses <see cref="IceInstruction.MemorySize"/>
		/// </summary>
		MemoryESRDI,

		/// <summary>
		/// 64-bit offset [xxxxxxxxxxxxxxxx]. This operand kind uses <see cref="IceInstruction.MemoryAddress64"/>,
		/// <see cref="IceInstruction.MemorySegment"/>, <see cref="IceInstruction.SegmentPrefix"/>, <see cref="IceInstruction.MemorySize"/>
		/// </summary>
		Memory64,

		/// <summary>
		/// Memory operand.
		/// This operand kind uses <see cref="IceInstruction.MemoryDisplSize"/>, <see cref="IceInstruction.MemorySize"/>,
		/// <see cref="IceInstruction.MemoryIndexScale"/>, <see cref="IceInstruction.MemoryDisplacement"/>,
		/// <see cref="IceInstruction.MemoryBase"/>, <see cref="IceInstruction.MemoryIndex"/>, <see cref="IceInstruction.MemorySegment"/>,
		/// <see cref="IceInstruction.SegmentPrefix"/>
		/// </summary>
		Memory,
	}
}
