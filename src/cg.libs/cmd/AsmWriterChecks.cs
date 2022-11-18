//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static Asm.AsmHexEmitter;
    using static Asm.AsmRegOps;

    public class AsmWriterChecks : Checker<AsmWriterChecks>
    {
        /*
        AND16ri8 | 4        | 66 83 e0 73           | and ax, 0x73      | Reg:ax, Imm:115
        AND16ri8 | 4        | 66 83 e1 73           | and cx, 0x73      | Reg:cx, Imm:115
        AND16ri8 | 4        | 66 83 e2 73           | and dx, 0x73      | Reg:dx, Imm:115
        AND16ri8 | 4        | 66 83 e3 73           | and bx, 0x73      | Reg:bx, Imm:115
        AND16ri8 | 4        | 66 83 e4 73           | and sp, 0x73      | Reg:sp, Imm:115
        AND16ri8 | 4        | 66 83 e5 73           | and bp, 0x73      | Reg:bp, Imm:115
        AND16ri8 | 4        | 66 83 e6 73           | and si, 0x73      | Reg:si, Imm:115
        AND16ri8 | 4        | 66 83 e7 73           | and di, 0x73      | Reg:di, Imm:115
        AND16ri8 | 5        | 66 41 83 e0 73        | and r8w, 0x73     | Reg:r8w, Imm:115
        AND16ri8 | 5        | 66 41 83 e1 73        | and r9w, 0x73     | Reg:r9w, Imm:115
        AND16ri8 | 5        | 66 41 83 e2 73        | and r10w, 0x73    | Reg:r10w, Imm:115
        AND16ri8 | 5        | 66 41 83 e3 73        | and r11w, 0x73    | Reg:r11w, Imm:115
        AND16ri8 | 5        | 66 41 83 e4 73        | and r12w, 0x73    | Reg:r12w, Imm:115
        AND16ri8 | 5        | 66 41 83 e5 73        | and r13w, 0x73    | Reg:r13w, Imm:115
        AND16ri8 | 5        | 66 41 83 e6 73        | and r14w, 0x73    | Reg:r14w, Imm:115
        AND16ri8 | 5        | 66 41 83 e7 73        | and r15w, 0x73    | Reg:r15w, Imm:115
        */

        static void row(AsmExpr asm, AsmHexCode hex, ITextEmitter dst)
        {
            const string RowPattern = "{0,-16} | {1,-8} | {2,-16} | {3}";
            dst.AppendLineFormat(RowPattern, asm, hex.Size, hex.Format(), hex.BitString);
        }

        public void CheckAsmBytes(ITextEmitter log)
        {
            const string ExprPattern2 = "{0} {1}, {2}";
            const string RowPattern = "{0,-16} | {1,-8} | {2,-16} | {3}";

            log.AppendLineFormat("{0,-2} | {1,-2} | {2,-2} | {3,-2}", nameof(ah), nameof(ch), nameof(dh), nameof(bh));
            log.AppendLineFormat("{0,-2} | {1,-2} | {2,-2} | {3,-2}", ah.Index, ch.Index, dh.Index, bh.Index);
            log.AppendLine();
            log.AppendLine(RP.PageBreak80);

            log.AppendLineFormat(RowPattern, "Asm", "Size", "Encoded", "Bits");

            var inst = "and";
            var dst = AsmHexWriter.create();
            var asm = CharBlock64.Empty;
            var buffer = asm.Data;
            var length = z8;

            dst.Clear();
            and(al, bl, dst);
            length = AsmSrcEmitter.emit(inst, al, bl, ref asm);
            row(sys.@string(slice(buffer, 0, length)), dst.Target, log);

            dst.Clear();
            and(cl, bl, dst);
            length = AsmSrcEmitter.emit(inst, cl, bl, ref asm);
            row(sys.@string(slice(buffer, 0, length)), dst.Target, log);

            dst.Clear();
            and(dl, bl, dst);
            length = AsmSrcEmitter.emit(inst, dl, bl, ref asm);
            row(sys.@string(slice(buffer, 0, length)), dst.Target, log);

            dst.Clear();
            and(ah, bl, dst);
            length = AsmSrcEmitter.emit(inst, ah, bl, ref asm);
            row(sys.@string(slice(buffer, 0, length)), dst.Target, log);

            dst.Clear();
            and(ch, bl, dst);
            length = AsmSrcEmitter.emit(inst, ch, bl, ref asm);
            row(sys.@string(slice(buffer, 0, length)), dst.Target, log);

            dst.Clear();
            and(dh, bl, dst);
            length = AsmSrcEmitter.emit(inst, dh, bl, ref asm);
            row(sys.@string(slice(buffer, 0, length)), dst.Target, log);

            dst.Clear();
            and(bh, bl, dst);
            length = AsmSrcEmitter.emit(inst, bh, bl, ref asm);
            row(sys.@string(slice(buffer, 0, length)), dst.Target, log);

            // AND16ri8 | 8ah | 4 | 66 83 e0 73 | and ax, 0x73 | Reg:ax, Imm:115

            log.AppendLine();
            log.AppendLine(RP.PageBreak80);
            // var a0 = x86x.and_r16_imm8(AsmRegOps.ax, 0x73);
            // log.AppendLineFormat("{0,-18} | {1,-8} | {2}", a0.Id, a0.EncodingSize, a0.Format());
        }

        /*
        | IP           | Encoded     | OpCode   | PSZ   | Rex   | ModRm | SZOV  | EASZ  | EOSZ  | Asm                         | IForm                                                  | SourceName                                 | Offsets                                          | Op0  | Op0Name  | Op0Val                   | Op0Action  | Op0Vis       | Op0Width     | Op0WKind     | Op0Prop2    | Op1  | Op1Name  | Op1Val                   | Op1Action  | Op1Vis       | Op1Width     | Op1WKind     | Op1Prop2    | Op2  | Op2Name  | Op2Val                   | Op2Action  | Op2Vis       | Op2Width     | Op2WKind     | Op2Prop2    | Op3  | Op3Name  | Op3Val                   | Op3Action  | Op3Vis       | Op3Width     | Op3WKind     | Op3Prop2    | Op4  | Op4Name  | Op4Val                   | Op4Action  | Op4Vis       | Op4Width     | Op4WKind     | Op4Prop2    | Op5  | Op5Name  | Op5Val                   | Op5Action  | Op5Vis       | Op5Width     | Op5WKind     | Op5Prop2
        | 0h           | 0f b6 01    | b6       | 1     |       | 0x01  |       | 64    | 32    | movzx eax, byte ptr [rcx]   | MOVZX_GPRv_MEMb                                        | dec                                        | {opcode=1, modrm=2}                              | Op0  | REG0     | EAX                      | W          | EXPLICIT     | 64           | v            | GPRV_R       |Op1  | MEM0     | ptr [RCX]                | R          | EXPLICIT     | 8            | b            | 1           |
        | 3h           | ff c8       | ff       | 0     |       | 0xC8  |       | 64    | 32    | dec eax                     | DEC_GPRv_FFr1                                          | dec                                        | {opcode=0, modrm=1}                              | Op0  | REG0     | EAX                      | RW         | EXPLICIT     | 64           | v            | GPRV_B       |Op1  | REG1     | RFLAGS                   | W          | SUPPRESSED   | 64           | y            | RFLAGS      |
        | 5h           | 0f b6 c0    | b6       | 1     |       | 0xC0  |       | 64    | 32    | movzx eax, al               | MOVZX_GPRv_GPR8                                        | dec                                        | {opcode=1, modrm=2}                              | Op0  | REG0     | EAX                      | W          | EXPLICIT     | 64           | v            | GPRV_R       |Op1  | REG1     | AL                       | R          | EXPLICIT     | 8            | b            | GPR8_B      |
        | 8h           | 88 01       | 88       | 0     |       | 0x01  |       | 64    | 32    | mov byte ptr [rcx], al      | MOV_MEMb_GPR8                                          | dec                                        | {opcode=0, modrm=1}                              | Op0  | MEM0     | ptr [RCX]                | W          | EXPLICIT     | 8            | b            | 1            |Op1  | REG0     | AL                       | R          | EXPLICIT     | 8            | b            | GPR8_R      |
        | ah           | c3          | c3       | 0     |       |       |       | 64    | 64    | ret                         | RET_NEAR                                               | dec                                        | {opcode=0}                                       | Op0  | REG0     | STACKPOP                 | R          | SUPPRESSED   | 64           | spw          | STACKPOP     |Op1  | REG1     | RIP                      | W          | SUPPRESSED   | 64           | y            | RIP         | Op2  | MEM0     | ptr [RSP]                | R          | SUPPRESSED   | 64           | spw          | 1           | Op3  | BASE0    |                          | RW         | SUPPRESSED   | 64           | ssz          | SRSP        |
        | bh           | 0f b7 01    | b7       | 1     |       | 0x01  |       | 64    | 32    | movzx eax, word ptr [rcx]   | MOVZX_GPRv_MEMw                                        | dec                                        | {opcode=1, modrm=2}                              | Op0  | REG0     | EAX                      | W          | EXPLICIT     | 64           | v            | GPRV_R       |Op1  | MEM0     | ptr [RCX]                | R          | EXPLICIT     | 16           | w            | 1           |
        | eh           | ff c8       | ff       | 0     |       | 0xC8  |       | 64    | 32    | dec eax                     | DEC_GPRv_FFr1                                          | dec                                        | {opcode=0, modrm=1}                              | Op0  | REG0     | EAX                      | RW         | EXPLICIT     | 64           | v            | GPRV_B       |Op1  | REG1     | RFLAGS                   | W          | SUPPRESSED   | 64           | y            | RFLAGS      |
        | 10h          | 0f b7 c0    | b7       | 1     |       | 0xC0  |       | 64    | 32    | movzx eax, ax               | MOVZX_GPRv_GPR16                                       | dec                                        | {opcode=1, modrm=2}                              | Op0  | REG0     | EAX                      | W          | EXPLICIT     | 64           | v            | GPRV_R       |Op1  | REG1     | AX                       | R          | EXPLICIT     | 16           | w            | GPR16_B     |
        | 13h          | 66 89 01    | 89       | 1     |       | 0x01  | 0x66  | 64    | 16    | mov word ptr [rcx], ax      | MOV_MEMv_GPRv                                          | dec                                        | {opcode=1, modrm=2}                              | Op0  | MEM0     | ptr [RCX]                | W          | EXPLICIT     | 64           | v            | 1            |Op1  | REG0     | AX                       | R          | EXPLICIT     | 64           | v            | GPRV_R      |
        | 16h          | c3          | c3       | 0     |       |       |       | 64    | 64    | ret                         | RET_NEAR                                               | dec                                        | {opcode=0}                                       | Op0  | REG0     | STACKPOP                 | R          | SUPPRESSED   | 64           | spw          | STACKPOP     |Op1  | REG1     | RIP                      | W          | SUPPRESSED   | 64           | y            | RIP         | Op2  | MEM0     | ptr [RSP]                | R          | SUPPRESSED   | 64           | spw          | 1           | Op3  | BASE0    |                          | RW         | SUPPRESSED   | 64           | ssz          | SRSP        |
        | 17h          | 8b 01       | 8b       | 0     |       | 0x01  |       | 64    | 32    | mov eax, dword ptr [rcx]    | MOV_GPRv_MEMv                                          | dec                                        | {opcode=0, modrm=1}                              | Op0  | REG0     | EAX                      | W          | EXPLICIT     | 64           | v            | GPRV_R       |Op1  | MEM0     | ptr [RCX]                | R          | EXPLICIT     | 64           | v            | 1           |
        | 19h          | ff c8       | ff       | 0     |       | 0xC8  |       | 64    | 32    | dec eax                     | DEC_GPRv_FFr1                                          | dec                                        | {opcode=0, modrm=1}                              | Op0  | REG0     | EAX                      | RW         | EXPLICIT     | 64           | v            | GPRV_B       |Op1  | REG1     | RFLAGS                   | W          | SUPPRESSED   | 64           | y            | RFLAGS      |
        | 1bh          | 89 01       | 89       | 0     |       | 0x01  |       | 64    | 32    | mov dword ptr [rcx], eax    | MOV_MEMv_GPRv                                          | dec                                        | {opcode=0, modrm=1}                              | Op0  | MEM0     | ptr [RCX]                | W          | EXPLICIT     | 64           | v            | 1            |Op1  | REG0     | EAX                      | R          | EXPLICIT     | 64           | v            | GPRV_R      |
        | 1dh          | c3          | c3       | 0     |       |       |       | 64    | 64    | ret                         | RET_NEAR                                               | dec                                        | {opcode=0}                                       | Op0  | REG0     | STACKPOP                 | R          | SUPPRESSED   | 64           | spw          | STACKPOP     |Op1  | REG1     | RIP                      | W          | SUPPRESSED   | 64           | y            | RIP         | Op2  | MEM0     | ptr [RSP]                | R          | SUPPRESSED   | 64           | spw          | 1           | Op3  | BASE0    |                          | RW         | SUPPRESSED   | 64           | ssz          | SRSP        |
        | 1eh          | 48 8b 01    | 8b       | 1     | 0x48  | 0x01  |       | 64    | 64    | mov rax, qword ptr [rcx]    | MOV_GPRv_MEMv                                          | dec                                        | {opcode=1, modrm=2}                              | Op0  | REG0     | RAX                      | W          | EXPLICIT     | 64           | v            | GPRV_R       |Op1  | MEM0     | ptr [RCX]                | R          | EXPLICIT     | 64           | v            | 1           |
        | 21h          | 48 ff c8    | ff       | 1     | 0x48  | 0xC8  |       | 64    | 64    | dec rax                     | DEC_GPRv_FFr1                                          | dec                                        | {opcode=1, modrm=2}                              | Op0  | REG0     | RAX                      | RW         | EXPLICIT     | 64           | v            | GPRV_B       |Op1  | REG1     | RFLAGS                   | W          | SUPPRESSED   | 64           | y            | RFLAGS      |
        | 24h          | 48 89 01    | 89       | 1     | 0x48  | 0x01  |       | 64    | 64    | mov qword ptr [rcx], rax    | MOV_MEMv_GPRv                                          | dec                                        | {opcode=1, modrm=2}                              | Op0  | MEM0     | ptr [RCX]                | W          | EXPLICIT     | 64           | v            | 1            |Op1  | REG0     | RAX                      | R          | EXPLICIT     | 64           | v            | GPRV_R      |
        | 27h          | c3          | c3       | 0     |       |       |       | 64    | 64    | ret                         | RET_NEAR                                               | dec                                        | {opcode=0}                                       | Op0  | REG0     | STACKPOP                 | R          | SUPPRESSED   | 64           | spw          | STACKPOP     |Op1  | REG1     | RIP                      | W          | SUPPRESSED   | 64           | y            | RIP         | Op2  | MEM0     | ptr [RSP]                | R          | SUPPRESSED   | 64           | spw          | 1           | Op3  | BASE0    |                          | RW         | SUPPRESSED   | 64           | ssz          | SRSP        |

        */
    }
}