//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AsmOcTableTokens
    {
        public const string Group = "asm.oct";

        /// <summary>
        /// Defines opcode operand types
        /// </summary>
        /// <remarks>From ## Vol. 2 Section A.2.2: Codes for Operand Type</remarks>
        [SymSource(Group)]
        public enum OperandType : byte
        {
            [Symbol("a", "Two one-word operands in memory or two double-word operands in memory, depending on operand-size attribute (used only by the BOUND instruction)")]
            a,

            [Symbol("b", "Byte, regardless of operand-size attribute")]
            b,

            [Symbol("c", "Byte or word, depending on operand-size attribute")]
            c,

            [Symbol("d", "Doubleword, regardless of operand-size attribute")]
            d,

            [Symbol("dq", "Double-quadword, regardless of operand-size attribute")]
            dq,

            [Symbol("p", "32-bit, 48-bit, or 80-bit pointer, depending on operand-size attribute")]
            p,

            [Symbol("pd", "128-bit or 256-bit packed double-precision floating-point data")]
            pd,

            [Symbol("pi", "Quadword MMX technology register (for example: mm0)")]
            pi,

            [Symbol("ps", "128-bit or 256-bit packed single-precision floating-point data")]
            ps,

            [Symbol("q", "Quadword, regardless of operand-size attribute")]
            q,

            [Symbol("qq", "Quad-Quadword (256-bits), regardless of operand-size attribute")]
            qq,

            [Symbol("s", "6-byte or 10-byte pseudo-descriptor")]
            s,

            [Symbol("sd", "Scalar element of a 128-bit double-precision floating data")]
            sd,

            [Symbol("ss", "Scalar element of a 128-bit single-precision floating data")]
            ss,

            [Symbol("si",  "Doubleword integer register (for example: eax)")]
            si,

            [Symbol("v", "Word, doubleword or quadword (in 64-bit mode), depending on operand-size attribute")]
            v,

            [Symbol("w", "Word, regardless of operand-size attribute")]
            w,

            [Symbol("x", "dq or qq based on the operand-size attribute")]
            x,

            [Symbol("y", "Doubleword or quadword (in 64-bit mode), depending on operand-size attribute")]
            y,

            [Symbol("z", "Word for 16-bit operand-size or doubleword for 32 or 64-bit operand-size")]
            z,

            [Symbol("Ev", "The ModR/M byte follows the opcode to specify a word or doubleword operand")]
            Ev,

            [Symbol("Gv", "The reg field of the ModR/M byte selects a general-purpose register")]
            Gv,

            [Symbol("Ib", "Immediate data is encoded in the subsequent byte of the instruction")]
            Ib,
        }

        [SymSource(Group)]
        public enum AddressingType : byte
        {
            [Symbol("A","Direct address: the instruction has no ModR/M byte; the address of the operand is encoded in the instruction. No base register, index register, or scaling factor can be applied (for example, far JMP (EA))")]
            A,

            [Symbol("B","The VEX.vvvv field of the VEX prefix selects a general purpose register")]
            B,

            [Symbol("C","The reg field of the ModR/M byte selects a control register (for example, MOV (0F20, 0F22))")]
            C,

            [Symbol("D","The reg field of the ModR/M byte selects a debug register (for example, MOV (0F21,0F23))")]
            D,

            [Symbol("E","A ModR/M byte follows the opcode and specifies the operand. The operand is either a general-purpose register or a memory address. If it is a memory address, the address is computed from a segment register and any of the following values: a base register, an index register, a scaling factor, a displacement")]
            E,

            [Symbol("F","EFLAGS/RFLAGS Register")]
            F,

            [Symbol("G","The reg field of the ModR/M byte selects a general register (for example, AX (000))")]
            G,

            [Symbol("H","The VEX.vvvv field of the VEX prefix selects a 128-bit XMM register or a 256-bit YMM register, determined by operand type. For legacy SSE encodings this operand does not exist, changing the instruction to destructive form.")]
            H,

            [Symbol("I","Immediate data: the operand value is encoded in subsequent bytes of the instruction.")]
            I,

            [Symbol("J","The instruction contains a relative offset to be added to the instruction pointer register (for example, JMP (0E9), LOOP)")]
            J,

            [Symbol("rB","modr/m.reg is used to access bound registers (added as a part of the Intel MPX Programming Environment)")]
            rB,

            [Symbol("mB","modr/m.r/m is used to access bound registers (added as a part of the Intel MPX Programming Environment)")]
            mB,

            [Symbol("L","The upper 4 bits of the 8-bit immediate selects a 128-bit XMM register or a 256-bit YMM register, determined by operand type. (the MSB is ignored in 32-bit mode)")]
            L,

            [Symbol("M","The ModR/M byte may refer only to memory (for example, BOUND, LES, LDS, LSS, LFS, LGS, CMPXCHG8B)")]
            M,

            [Symbol("N","The R/M field of the ModR/M byte selects a packed-quadword, MMX technology register")]
            N,

            [Symbol("O","The instruction has no ModR/M byte. The offset of the operand is coded as a word or double word (depending on address size attribute) in the instruction. No base register, index register, or scaling factor can be applied (for example, MOV (A0–A3))")]
            O,

            [Symbol("P","The reg field of the ModR/M byte selects a packed quadword MMX technology register")]
            P,

            [Symbol("Q","A ModR/M byte follows the opcode and specifies the operand. The operand is either an MMX technology register or a memory address. If it is a memory address, the address is computed from a segment register and any of the following values: a base register, an index register, a scaling factor, and a displacement")]
            Q,

            [Symbol("R","The R/M field of the ModR/M byte may refer only to a general register (for example, MOV (0F20-0F23))")]
            R,

            [Symbol("S","The reg field of the ModR/M byte selects a segment register (for example, MOV (8C,8E))")]
            S,

            [Symbol("U","The R/M field of the ModR/M byte selects a 128-bit XMM register or a 256-bit YMM register, determined by operand type")]
            U,

            [Symbol("V","The reg field of the ModR/M byte selects a 128-bit XMM register or a 256-bit YMM register, determined by operand type")]
            V,

            [Symbol("W","A ModR/M byte follows the opcode and specifies the operand. The operand is either a 128-bit XMM register, a 256-bit YMM register (determined by operand type), or a memory address. If it is a memory address, the address is computed from a segment register and any of the following values: a base register, an index register, a scaling factor, and a displacement")]
            W,

            [Symbol("Z","Memory addressed by the DS:rSI register pair (for example, MOVS, CMPS, OUTS, or LODS)")]
            X,

            [Symbol("Y","Memory addressed by the ES:rDI register pair (for example, MOVS, CMPS, INS, STOS, or SCAS)")]
            Y,
        }

        [SymSource(Group)]
        public enum Refinements : byte
        {
            [Symbol("1A", "Bits 5, 4, and 3 of ModR/M byte used as an opcode extension")]
            A1,

            [Symbol("1B", "Use the 0F0B opcode (UD2 instruction), the 0FB9H opcode (UD1 instruction), or the 0FFFH opcode (UD0 instruction) when deliberately trying to generate an invalid opcode exception (#UD).")]
            B1,

            [Symbol("1C", "Some instructions use the same two-byte opcode. If the instruction has variations, or the opcode represents different instructions, the ModR/M byte will be used to differentiate the instruction. For the value of the ModR/M byte needed to decode the instruction, see Table A-6")]
            C1,

            [Symbol("i64", "The instruction is invalid or not encodable in 64-bit mode. 40 through 4F (single-byte INC and DEC) are REX prefix combinations when in 64-bit mode (use FE/FF Grp 4 and 5 for INC and DEC)")]
            i64,

            [Symbol("o64", "Instruction is only available when in 64-bit mode.")]
            o64,

            [Symbol("d64", "When in 64-bit mode, instruction defaults to 64-bit operand size and cannot encode 32-bit operand size.")]
            d64,

            [Symbol("f64", "The operand size is forced to a 64-bit operand size when in 64-bit mode (prefixes that change operand size are ignored for this instruction in 64-bit mode).  ")]
            f64,

            [Symbol("v", "VEX form only exists. There is no legacy SSE form of the instruction. For Integer GPR instructions it means VEX prefix required.")]
            v,

            [Symbol("v1", "VEX128 & SSE forms only exist (no VEX256), when can’t be inferred from the data size")]
            v1,
        }

        public enum RegIndicator : byte
        {
            [Symbol("eXX", "Form of register identifier that indicates 16 or 32-bit widths are applicable")]
            eXX,

            [Symbol("rXX", "Form of register identifier that indicates 16, 32 or 64-bit widths are applicable")]
            rXX,

            [Symbol("/x", "Indicates that the Rex.B bit is used to modify the register specified in the reg field of the opcode")]
            RegDigit
        }
   }
}