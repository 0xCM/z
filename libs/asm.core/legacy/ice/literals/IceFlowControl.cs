//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
	/// <summary>
	/// Flow control
	/// </summary>
	[Ignore]
	public enum IceFlowControl : byte
	{
		/// <summary>
		/// The next instruction that will be executed is the next instruction in the instruction stream
		/// </summary>
		Next,

		/// <summary>
		/// It's an unconditional branch instruction: jmp near, jmp far
		/// </summary>
		UnconditionalBranch,

		/// <summary>
		/// It's an unconditional indirect branch: jmp near reg, jmp near [mem], jmp far [mem]
		/// </summary>
		IndirectBranch,

		/// <summary>
		/// It's a conditional branch instruction: jcc short, jcc near, loop, loopcc, jrcxz
		/// </summary>
		ConditionalBranch,

		/// <summary>
		/// It's a return instruction: ret near, ret far, iret, sysret, sysexit, rsm, vmlaunch, vmresume, vmrun, skinit
		/// </summary>
		Return,

		/// <summary>
		/// It's a call instruction: call near, call far, syscall, sysenter, vmcall, vmmcall
		/// </summary>
		Call,

		/// <summary>
		/// It's an indirect call instruction: call near reg, call near [mem], call far [mem]
		/// </summary>
		IndirectCall,

		/// <summary>
		/// It's an interrupt instruction: int n, int3, int1, into
		/// </summary>
		Interrupt,

		/// <summary>
		/// It's xbegin, xabort or xend
		/// </summary>
		XbeginXabortXend,

		/// <summary>
		/// It's an invalid instruction, eg. ud0, ud1, ud2
		/// </summary>
		Exception,
	}
}