//-----------------------------------------------------------------------------
// Taken from Iced:https://github.com/0xd4d/iced
// License: See the accompanying license file
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
	/// <summary>
	/// Operand kind
	/// </summary>
	[Ignore]
	public enum IceOpCodeOperandKind
    {
		/// <summary>
		/// No operand
		/// </summary>
		None,
		/// <summary>
		/// Far branch 16-bit offset, 16-bit segment/selector
		/// </summary>
		farbr2_2,
		/// <summary>
		/// Far branch 32-bit offset, 16-bit segment/selector
		/// </summary>
		farbr4_2,
		/// <summary>
		/// Memory offset without a modrm byte (eg. mov al,[offset])
		/// </summary>
		mem_offs,
		/// <summary>
		/// Memory (modrm)
		/// </summary>
		mem,
		/// <summary>
		/// Memory (modrm), MPX: 16/32-bit mode: must be 32-bit addressing, 64-bit mode: 64-bit addressing is forced
		/// </summary>
		mem_mpx,
		/// <summary>
		/// Memory (modrm), MPX: 16/32-bit mode: must be 32-bit addressing, 64-bit mode: 64-bit addressing is forced and must not be RIP relative
		/// </summary>
		mem_mib,
		/// <summary>
		/// Memory (modrm), vsib32, xmm registers
		/// </summary>
		mem_vsib32x,
		/// <summary>
		/// Memory (modrm), vsib64, xmm registers
		/// </summary>
		mem_vsib64x,
		/// <summary>
		/// Memory (modrm), vsib32, ymm registers
		/// </summary>
		mem_vsib32y,
		/// <summary>
		/// Memory (modrm), vsib64, ymm registers
		/// </summary>
		mem_vsib64y,
		/// <summary>
		/// Memory (modrm), vsib32, zmm registers
		/// </summary>
		mem_vsib32z,
		/// <summary>
		/// Memory (modrm), vsib64, zmm registers
		/// </summary>
		mem_vsib64z,
		/// <summary>
		/// 8-bit GPR or memory
		/// </summary>
		r8_or_mem,
		/// <summary>
		/// 16-bit GPR or memory
		/// </summary>
		r16_or_mem,
		/// <summary>
		/// 32-bit GPR or memory
		/// </summary>
		r32_or_mem,
		/// <summary>
		/// 32-bit GPR or memory, MPX: 16/32-bit mode: must be 32-bit addressing, 64-bit mode: 64-bit addressing is forced
		/// </summary>
		r32_or_mem_mpx,
		/// <summary>
		/// 64-bit GPR or memory
		/// </summary>
		r64_or_mem,
		/// <summary>
		/// 64-bit GPR or memory, MPX: 16/32-bit mode: must be 32-bit addressing, 64-bit mode: 64-bit addressing is forced
		/// </summary>
		r64_or_mem_mpx,
		/// <summary>
		/// MM register or memory
		/// </summary>
		mm_or_mem,
		/// <summary>
		/// XMM register or memory
		/// </summary>
		xmm_or_mem,
		/// <summary>
		/// YMM register or memory
		/// </summary>
		ymm_or_mem,
		/// <summary>
		/// ZMM register or memory
		/// </summary>
		zmm_or_mem,
		/// <summary>
		/// BND register or memory, MPX: 16/32-bit mode: must be 32-bit addressing, 64-bit mode: 64-bit addressing is forced
		/// </summary>
		bnd_or_mem_mpx,
		/// <summary>
		/// K register or memory
		/// </summary>
		k_or_mem,
		/// <summary>
		/// 8-bit GPR encoded in the 'reg' field of the modrm byte
		/// </summary>
		r8_reg,
		/// <summary>
		/// 8-bit GPR encoded in the low 3 bits of the opcode
		/// </summary>
		r8_opcode,
		/// <summary>
		/// 16-bit GPR encoded in the 'reg' field of the modrm byte
		/// </summary>
		r16_reg,
		/// <summary>
		/// 16-bit GPR encoded in the 'mod + r/m' fields of the modrm byte
		/// </summary>
		r16_rm,
		/// <summary>
		/// 16-bit GPR encoded in the low 3 bits of the opcode
		/// </summary>
		r16_opcode,
		/// <summary>
		/// 32-bit GPR encoded in the 'reg' field of the modrm byte
		/// </summary>
		r32_reg,
		/// <summary>
		/// 32-bit GPR encoded in the 'mod + r/m' fields of the modrm byte
		/// </summary>
		r32_rm,
		/// <summary>
		/// 32-bit GPR encoded in the low 3 bits of the opcode
		/// </summary>
		r32_opcode,
		/// <summary>
		/// 32-bit GPR encoded in the the V'vvvv field (VEX/EVEX/XOP)
		/// </summary>
		r32_vvvv,
		/// <summary>
		/// 64-bit GPR encoded in the 'reg' field of the modrm byte
		/// </summary>
		r64_reg,
		/// <summary>
		/// 64-bit GPR encoded in the 'mod + r/m' fields of the modrm byte
		/// </summary>
		r64_rm,
		/// <summary>
		/// 64-bit GPR encoded in the low 3 bits of the opcode
		/// </summary>
		r64_opcode,
		/// <summary>
		/// 64-bit GPR encoded in the the V'vvvv field (VEX/EVEX/XOP)
		/// </summary>
		r64_vvvv,
		/// <summary>
		/// Segment register encoded in the 'reg' field of the modrm byte
		/// </summary>
		seg_reg,
		/// <summary>
		/// K register encoded in the 'reg' field of the modrm byte
		/// </summary>
		k_reg,
		/// <summary>
		/// K register (+1) encoded in the 'reg' field of the modrm byte
		/// </summary>
		kp1_reg,
		/// <summary>
		/// K register encoded in the 'mod + r/m' fields of the modrm byte
		/// </summary>
		k_rm,
		/// <summary>
		/// K register encoded in the the V'vvvv field (VEX/EVEX/XOP)
		/// </summary>
		k_vvvv,
		/// <summary>
		/// MM register encoded in the 'reg' field of the modrm byte
		/// </summary>
		mm_reg,
		/// <summary>
		/// MM register encoded in the 'mod + r/m' fields of the modrm byte
		/// </summary>
		mm_rm,
		/// <summary>
		/// XMM register encoded in the 'reg' field of the modrm byte
		/// </summary>
		xmm_reg,
		/// <summary>
		/// XMM register encoded in the 'mod + r/m' fields of the modrm byte
		/// </summary>
		xmm_rm,
		/// <summary>
		/// XMM register encoded in the the V'vvvv field (VEX/EVEX/XOP)
		/// </summary>
		xmm_vvvv,
		/// <summary>
		/// XMM register (+3) encoded in the the V'vvvv field (VEX/EVEX/XOP)
		/// </summary>
		xmmp3_vvvv,
		/// <summary>
		/// XMM register encoded in the the high 4 bits of the last 8-bit immediate (VEX/XOP only so only XMM0-XMM15)
		/// </summary>
		xmm_is4,
		/// <summary>
		/// XMM register encoded in the the high 4 bits of the last 8-bit immediate (VEX/XOP only so only XMM0-XMM15)
		/// </summary>
		xmm_is5,
		/// <summary>
		/// YMM register encoded in the 'reg' field of the modrm byte
		/// </summary>
		ymm_reg,
		/// <summary>
		/// YMM register encoded in the 'mod + r/m' fields of the modrm byte
		/// </summary>
		ymm_rm,
		/// <summary>
		/// YMM register encoded in the the V'vvvv field (VEX/EVEX/XOP)
		/// </summary>
		ymm_vvvv,
		/// <summary>
		/// YMM register encoded in the the high 4 bits of the last 8-bit immediate (VEX/XOP only so only YMM0-YMM15)
		/// </summary>
		ymm_is4,
		/// <summary>
		/// YMM register encoded in the the high 4 bits of the last 8-bit immediate (VEX/XOP only so only YMM0-YMM15)
		/// </summary>
		ymm_is5,
		/// <summary>
		/// ZMM register encoded in the 'reg' field of the modrm byte
		/// </summary>
		zmm_reg,
		/// <summary>
		/// ZMM register encoded in the 'mod + r/m' fields of the modrm byte
		/// </summary>
		zmm_rm,
		/// <summary>
		/// ZMM register encoded in the the V'vvvv field (VEX/EVEX/XOP)
		/// </summary>
		zmm_vvvv,
		/// <summary>
		/// ZMM register (+3) encoded in the the V'vvvv field (VEX/EVEX/XOP)
		/// </summary>
		zmmp3_vvvv,
		/// <summary>
		/// CR register encoded in the 'reg' field of the modrm byte
		/// </summary>
		cr_reg,
		/// <summary>
		/// DR register encoded in the 'reg' field of the modrm byte
		/// </summary>
		dr_reg,
		/// <summary>
		/// TR register encoded in the 'reg' field of the modrm byte
		/// </summary>
		tr_reg,
		/// <summary>
		/// BND register encoded in the 'reg' field of the modrm byte
		/// </summary>
		bnd_reg,
		/// <summary>
		/// ES register
		/// </summary>
		es,
		/// <summary>
		/// CS register
		/// </summary>
		cs,
		/// <summary>
		/// SS register
		/// </summary>
		ss,
		/// <summary>
		/// DS register
		/// </summary>
		ds,
		/// <summary>
		/// FS register
		/// </summary>
		fs,
		/// <summary>
		/// GS register
		/// </summary>
		gs,
		/// <summary>
		/// AL register
		/// </summary>
		al,
		/// <summary>
		/// CL register
		/// </summary>
		cl,
		/// <summary>
		/// AX register
		/// </summary>
		ax,
		/// <summary>
		/// DX register
		/// </summary>
		dx,
		/// <summary>
		/// EAX register
		/// </summary>
		eax,
		/// <summary>
		/// RAX register
		/// </summary>
		rax,
		/// <summary>
		/// ST0 register
		/// </summary>
		st0,
		/// <summary>
		/// ST(i) register encoded in the low 3 bits of the opcode
		/// </summary>
		sti_opcode,
		/// <summary>
		/// 2-bit immediate (m2z field, low 2 bits of the /is5 immediate, eg. vpermil2ps)
		/// </summary>
		imm2_m2z,
		/// <summary>
		/// 8-bit immediate
		/// </summary>
		imm8,
		/// <summary>
		/// Constant 1 (8-bit immediate)
		/// </summary>
		imm8_const_1,
		/// <summary>
		/// 8-bit immediate sign extended to 16 bits
		/// </summary>
		imm8sex16,
		/// <summary>
		/// 8-bit immediate sign extended to 32 bits
		/// </summary>
		imm8sex32,
		/// <summary>
		/// 8-bit immediate sign extended to 64 bits
		/// </summary>
		imm8sex64,
		/// <summary>
		/// 16-bit immediate
		/// </summary>
		imm16,
		/// <summary>
		/// 32-bit immediate
		/// </summary>
		imm32,
		/// <summary>
		/// 32-bit immediate sign extended to 64 bits
		/// </summary>
		imm32sex64,
		/// <summary>
		/// 64-bit immediate
		/// </summary>
		imm64,
		/// <summary>
		/// seg:[rSI] memory operand (string instructions)
		/// </summary>
		seg_rSI,
		/// <summary>
		/// es:[rDI] memory operand (string instructions)
		/// </summary>
		es_rDI,
		/// <summary>
		/// seg:[rDI] memory operand ((v)maskmovq instructions)
		/// </summary>
		seg_rDI,
		/// <summary>
		/// seg:[rBX+al] memory operand (xlatb instruction)
		/// </summary>
		seg_rBX_al,
		/// <summary>
		/// 16-bit branch, 1-byte signed relative offset
		/// </summary>
		br16_1,
		/// <summary>
		/// 32-bit branch, 1-byte signed relative offset
		/// </summary>
		br32_1,
		/// <summary>
		/// 64-bit branch, 1-byte signed relative offset
		/// </summary>
		br64_1,
		/// <summary>
		/// 16-bit branch, 2-byte signed relative offset
		/// </summary>
		br16_2,
		/// <summary>
		/// 32-bit branch, 4-byte signed relative offset
		/// </summary>
		br32_4,
		/// <summary>
		/// 64-bit branch, 4-byte signed relative offset
		/// </summary>
		br64_4,
		/// <summary>
		/// xbegin, 2-byte signed relative offset
		/// </summary>
		xbegin_2,
		/// <summary>
		/// xbegin, 4-byte signed relative offset
		/// </summary>
		xbegin_4,
		/// <summary>
		/// 2-byte branch offset (jmpe instruction)
		/// </summary>
		brdisp_2,
		/// <summary>
		/// 4-byte branch offset (jmpe instruction)
		/// </summary>
		brdisp_4,
	}
}
