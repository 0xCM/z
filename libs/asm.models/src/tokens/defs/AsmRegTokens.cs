//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Asm.RegIndexCode;
    using TK = AsmRegTokens.RegTokenKind;
    using I = Asm.RegIndexCode;
    using G = AsmRegTokens;

    public class AsmRegTokens : TokenGroup<G,TK>
    {
        const string Group = "asm.regs.tokens";

        public override string GroupName
            => Group;

        [SymSource(Group)]
        public enum RegTokenKind
        {
            None,

            [Symbol("gp8lo")]
            Gp8Lo,

            [Symbol("gp8hi")]
            Gp8Hi,

            [Symbol("gp16")]
            Gp16,

            [Symbol("gp32")]
            Gp32,

            [Symbol("gp64")]
            Gp64,

            [Symbol("xmm")]
            Xmm,

            [Symbol("ymm")]
            Ymm,

            [Symbol("zmm")]
            Zmm,

            [Symbol("mask")]
            Mask,

            [Symbol("bnd")]
            Bnd,

            [Symbol("ip")]
            Ip,

            [Symbol("flags")]
            Flags,

            [Symbol("sysptr")]
            SysPtr,

            [Symbol("mmx")]
            Mmx,

            [Symbol("fp")]
            Fp,

            [Symbol("seg")]
            Seg,

            [Symbol("test")]
            Test,

            [Symbol("cr")]
            Cr,

            [Symbol("xcr")]
            XCr,

            [Symbol("db")]
            Db
        }

        /// <summary>
        /// Clasifies the gp reg codes
        /// </summary>
        [SymSource(Group)]
        public enum GpRegKind : byte
        {
            [Symbol("r8")]
            Gp8 = 0,

            [Symbol("r16")]
            Gp16 = 1,

            [Symbol("r32")]
            Gp32 = 2,

            [Symbol("r64")]
            Gp64 = 3,

            [Symbol("r8hi")]
            Gp8Hi = 4,
        }

        /// <summary>
        /// Specifies the GP 8-bit (lo) registers
        /// </summary>
        /// <remarks>
        /// al, cl, dl, bl, spl, bpl, sil, dil, r8b, r9b, r10b, r11b, r12b, r13b, r14b, r15b
        /// </remarks/>
        [SymSource(Group), RegCode(TK.Gp8Lo)]
        public enum Gp8LoReg : byte
        {
            [Symbol("al")]
            al = r0,

            [Symbol("cl")]
            cl = r1,

            [Symbol("dl")]
            dl = r2,

            [Symbol("bl")]
            bl = r3,

            [Symbol("spl")]
            spl = r4,

            [Symbol("bpl")]
            bpl = r5,

            [Symbol("sil")]
            sil = r6,

            [Symbol("dil")]
            dil = r7,

            [Symbol("r8b")]
            r8b = r8,

            [Symbol("r9b")]
            r9b = r9,

            [Symbol("r10b")]
            r10b = r10,

            [Symbol("r11b")]
            r11b = r11,

            [Symbol("r12b")]
            r12b = r12,

            [Symbol("r13b")]
            r13b = r13,

            [Symbol("r14b")]
            r14b = r14,

            [Symbol("r15b")]
            r15b = r15,
        }

        /// <summary>
        /// Specifies the GP 8-bit hi regsisters
        /// </summary>
        /// <remarks>
        /// ah, ch, dh, bh
        /// </remarks/>
        [SymSource(Group), RegCode(TK.Gp8Hi)]
        public enum Gp8HiReg : byte
        {
            [Symbol("ah")]
            ah = r4,

            [Symbol("ch")]
            ch = r5,

            [Symbol("dh")]
            dh = r6,

            [Symbol("bh")]
            bh = r7,
        }

        /// <summary>
        /// Specifies the GP 16-bit registers
        /// </summary>
        /// <remarks>
        /// ax, cx, dx, bx, sp, bp, si, di, r8w, r9w, r10w, r11w, r12w, r13w, r14w, r15w
        /// </remarks/>
        [SymSource(Group), RegCode(TK.Gp16)]
        public enum Gp16Reg : byte
        {
            [Symbol("ax")]
            ax = r0,

            [Symbol("cx")]
            cx = r1,

            [Symbol("dx")]
            dx = r2,

            [Symbol("bx")]
            bx = r3,

            [Symbol("sp")]
            sp = r4,

            [Symbol("bp")]
            bp = r5,

            [Symbol("si")]
            si = r6,

            [Symbol("di")]
            di = r7,

            [Symbol("r8w")]
            r8w = r8,

            [Symbol("r9w")]
            r9w = r9,

            [Symbol("r10w")]
            r10w = r10,

            [Symbol("r11w")]
            r11w = r11,

            [Symbol("r12w")]
            r12w = r12,

            [Symbol("r13w")]
            r13w = r13,

            [Symbol("r14w")]
            r14w = r14,

            [Symbol("r15w")]
            r15w = r15,
        }

        /// <summary>
        /// Specifies the GP 32-bit registers
        /// </summary>
        /// <remarks>
        /// eax, ecx, edx, ebx, esp, ebp, esi, edi, r8d, r9d, r10d, r11d, r12d, r13d, r14d, r15d
        /// </remarks/>
        [SymSource(Group), RegCode(TK.Gp32)]
        public enum Gp32Reg : byte
        {
            [Symbol("eax")]
            eax = r0,

            [Symbol("ecx")]
            ecx = r1,

            [Symbol("edx")]
            edx = r2,

            [Symbol("ebx")]
            ebx = r3,

            [Symbol("esp")]
            esp = r4,

            [Symbol("ebp")]
            ebp = r5,

            [Symbol("esi")]
            esi = r6,

            [Symbol("edi")]
            edi = r7,

            [Symbol("r8d")]
            r8d = r8,

            [Symbol("r9d")]
            r9d = r9,

            [Symbol("r10d")]
            r10d = r10,

            [Symbol("r11d")]
            r11d = r11,

            [Symbol("r12d")]
            r12d = r12,

            [Symbol("r13d")]
            r13d = r13,

            [Symbol("r14d")]
            r14d = r14,

            [Symbol("r15d")]
            r15d = r15,
        }

        /// <summary>
        /// Specifies the GP 64-bit registers
        /// </summary>
        /// <remarks>
        /// rax, rcx, rdx, rbx, rsp, rbp, rsi, rdi, r8, r9, r10, r11, r12, r13, r14, r15
        /// </remarks/>
        [SymSource(Group), RegCode(TK.Gp64)]
        public enum Gp64Reg : byte
        {
            [Symbol("rax")]
            rax = r0,

            [Symbol("rcx")]
            rcx = r1,

            [Symbol("rdx")]
            rdx = r2,

            [Symbol("rbx")]
            rbx = r3,

            [Symbol("rsp")]
            rsp = r4,

            [Symbol("rbp")]
            rbp = r5,

            [Symbol("rsi")]
            rsi = r6,

            [Symbol("rdi")]
            rdi = r7,

            [Symbol("r8")]
            r8 = I.r8,

            [Symbol("r9")]
            r9 = I.r9,

            [Symbol("r10")]
            r10 = I.r10,

            [Symbol("r11")]
            r11 = I.r11,

            [Symbol("r12")]
            r12 = I.r12,

            [Symbol("r13")]
            r13 = I.r13,

            [Symbol("r14")]
            r14 = I.r14,

            [Symbol("r15")]
            r15 = I.r15,
        }

        /// <summary>
        /// Specifies the XMM registers
        /// </summary>
        /// <remarks>
        /// xmm0, xmm1, xmm2, xmm3, xmm4, xmm5, xmm6, xmm7, xmm8, xmm9, xmm10, xmm11, xmm12, xmm13, xmm14, xmm15, xmm16, xmm17, xmm18, xmm19, xmm20, xmm21, xmm22, xmm23, xmm24, xmm25, xmm26, xmm27, xmm28, xmm29, xmm30, xmm31
        /// </remarks/>
        [SymSource(Group), RegCode(TK.Xmm)]
        public enum XmmReg : byte
        {
            [Symbol("xmm0")]
            xmm0 = r0,

            [Symbol("xmm1")]
            xmm1 = r1,

            [Symbol("xmm2")]
            xmm2 = r2,

            [Symbol("xmm3")]
            xmm3 = r3,

            [Symbol("xmm4")]
            xmm4 = r4,

            [Symbol("xmm5")]
            xmm5 = r5,

            [Symbol("xmm6")]
            xmm6 = r6,

            [Symbol("xmm7")]
            xmm7 = r7,

            [Symbol("xmm8")]
            xmm8 = r8,

            [Symbol("xmm9")]
            xmm9 = r9,

            [Symbol("xmm10")]
            xmm10 = r10,

            [Symbol("xmm11")]
            xmm11 = r11,

            [Symbol("xmm12")]
            xmm12 = r12,

            [Symbol("xmm13")]
            xmm13 = r13,

            [Symbol("xmm14")]
            xmm14 = r14,

            [Symbol("xmm15")]
            xmm15 = r15,

            [Symbol("xmm16")]
            xmm16 = r16,

            [Symbol("xmm17")]
            xmm17 = r17,

            [Symbol("xmm18")]
            xmm18 = r18,

            [Symbol("xmm19")]
            xmm19 = r19,

            [Symbol("xmm20")]
            xmm20 = r20,

            [Symbol("xmm21")]
            xmm21 = r21,

            [Symbol("xmm22")]
            xmm22 = r22,

            [Symbol("xmm23")]
            xmm23 = r23,

            [Symbol("xmm24")]
            xmm24 = r24,

            [Symbol("xmm25")]
            xmm25 = r25,

            [Symbol("xmm26")]
            xmm26 = r26,

            [Symbol("xmm27")]
            xmm27 = r27,

            [Symbol("xmm28")]
            xmm28 = r28,

            [Symbol("xmm29")]
            xmm29 = r29,

            [Symbol("xmm30")]
            xmm30 = r30,

            [Symbol("xmm31")]
            xmm31 = r31,
        }

        /// <summary>
        /// ymm0, ymm1, ymm2, ymm3, ymm4, ymm5, ymm6, ymm7, ymm8, ymm9, ymm10, ymm11, ymm12, ymm13, ymm14, ymm15, ymm16, ymm17, ymm18, ymm19, ymm20, ymm21, ymm22, ymm23, ymm24, ymm25, ymm26, ymm27, ymm28, ymm29, ymm30, ymm31
        /// </summary>
        [SymSource(Group), RegCode(TK.Xmm)]
        public enum YmmReg : byte
        {
            [Symbol("ymm0")]
            ymm0 = r0,

            [Symbol("ymm1")]
            ymm1 = r1,

            [Symbol("ymm2")]
            ymm2 = r2,

            [Symbol("ymm3")]
            ymm3 = r3,

            [Symbol("ymm4")]
            ymm4 = r4,

            [Symbol("ymm5")]
            ymm5 = r5,

            [Symbol("ymm6")]
            ymm6 = r6,

            [Symbol("ymm7")]
            ymm7 = r7,

            [Symbol("ymm8")]
            ymm8 = r8,

            [Symbol("ymm9")]
            ymm9 = r9,

            [Symbol("ymm10")]
            ymm10 = r10,

            [Symbol("ymm11")]
            ymm11 = r11,

            [Symbol("ymm12")]
            ymm12 = r12,

            [Symbol("ymm13")]
            ymm13 = r13,

            [Symbol("ymm14")]
            ymm14 = r14,

            [Symbol("ymm15")]
            ymm15 = r15,

            [Symbol("ymm16")]
            ymm16 = r16,

            [Symbol("ymm17")]
            ymm17 = r17,

            [Symbol("ymm18")]
            ymm18 = r18,

            [Symbol("ymm19")]
            ymm19 = r19,

            [Symbol("ymm20")]
            ymm20 = r20,

            [Symbol("ymm21")]
            ymm21 = r21,

            [Symbol("ymm22")]
            ymm22 = r22,

            [Symbol("ymm23")]
            ymm23 = r23,

            [Symbol("ymm24")]
            ymm24 = r24,

            [Symbol("ymm25")]
            ymm25 = r25,

            [Symbol("ymm26")]
            ymm26 = r26,

            [Symbol("ymm27")]
            ymm27 = r27,

            [Symbol("ymm28")]
            ymm28 = r28,

            [Symbol("ymm29")]
            ymm29 = r29,

            [Symbol("ymm30")]
            ymm30 = r30,

            [Symbol("ymm31")]
            ymm31 = r31,
        }

        /// <summary>
        /// zmm0, zmm1, zmm2, zmm3, zmm4, zmm5, zmm6, zmm7, zmm8, zmm9, zmm10, zmm11, zmm12, zmm13, zmm14, zmm15, zmm16, zmm17, zmm18, zmm19, zmm20, zmm21, zmm22, zmm23, zmm24, zmm25, zmm26, zmm27, zmm28, zmm29, zmm30, zmm31
        /// </summary>
        [SymSource(Group), RegCode(TK.Zmm)]
        public enum ZmmReg : byte
        {
            [Symbol("zmm0")]
            zmm0 = r0,

            [Symbol("zmm1")]
            zmm1 = r1,

            [Symbol("zmm2")]
            zmm2 = r2,

            [Symbol("zmm3")]
            zmm3 = r3,

            [Symbol("zmm4")]
            zmm4 = r4,

            [Symbol("zmm5")]
            zmm5 = r5,

            [Symbol("zmm6")]
            zmm6 = r6,

            [Symbol("zmm7")]
            zmm7 = r7,

            [Symbol("zmm8")]
            zmm8 = r8,

            [Symbol("zmm9")]
            zmm9 = r9,

            [Symbol("zmm10")]
            zmm10 = r10,

            [Symbol("zmm11")]
            zmm11 = r11,

            [Symbol("zmm12")]
            zmm12 = r12,

            [Symbol("zmm13")]
            zmm13 = r13,

            [Symbol("zmm14")]
            zmm14 = r14,

            [Symbol("zmm15")]
            zmm15 = r15,

            [Symbol("zmm16")]
            zmm16 = r16,

            [Symbol("zmm17")]
            zmm17 = r17,

            [Symbol("zmm18")]
            zmm18 = r18,

            [Symbol("zmm19")]
            zmm19 = r19,

            [Symbol("zmm20")]
            zmm20 = r20,

            [Symbol("zmm21")]
            zmm21 = r21,

            [Symbol("zmm22")]
            zmm22 = r22,

            [Symbol("zmm23")]
            zmm23 = r23,

            [Symbol("zmm24")]
            zmm24 = r24,

            [Symbol("zmm25")]
            zmm25 = r25,

            [Symbol("zmm26")]
            zmm26 = r26,

            [Symbol("zmm27")]
            zmm27 = r27,

            [Symbol("zmm28")]
            zmm28 = r28,

            [Symbol("zmm29")]
            zmm29 = r29,

            [Symbol("zmm30")]
            zmm30 = r30,

            [Symbol("zmm31")]
            zmm31 = r31,
        }

        /// <summary>
        /// bnd0, bnd1, bnd2, bnd3
        /// </summary>
        [SymSource(Group), RegCode(TK.Bnd)]
        public enum BndReg : byte
        {
            [Symbol("bnd0")]
            bnd0 = r0,

            [Symbol("bnd1")]
            bnd1 = r1,

            [Symbol("bnd2")]
            bnd2 = r2,

            [Symbol("bnd3")]
            bnd3 = r3,
        }

        /// <summary>
        /// Defines control register indices
        /// cr0, cr1, cr2, cr3, cr4, cr5, cr6, cr7
        /// </summary>
        [SymSource(Group), RegCode(TK.Cr)]
        public enum ControlReg : byte
        {
            [Symbol("cr0")]
            cr0 = r0,

            [Symbol("cr1")]
            cr1 = r1,

            [Symbol("cr2")]
            cr2 = r2,

            [Symbol("cr3")]
            cr3 = r3,

            [Symbol("cr4")]
            cr4 = r4,

            [Symbol("cr5")]
            cr5 = r5,

            [Symbol("cr6")]
            cr6 = r6,

            [Symbol("CR7")]
            cr7 = r7,
        }

        /// <summary>
        /// xcr0
        /// </summary>
        [SymSource(Group), RegCode(TK.XCr)]
        public enum XControlReg : byte
        {
            [Symbol("xcr0")]
            xcr0 = r0,
        }

        /// <summary>
        /// Defines debug register indices
        /// dr0, dr1, dr2, dr3, dr4, dr5, dr6, dr7
        /// </summary>
        [SymSource(Group), RegCode(TK.Db)]
        public enum DebugReg : uint
        {
            [Symbol("dr0")]
            dr0 = r0,

            [Symbol("dr1")]
            dr1 = r1,

            [Symbol("dr2")]
            dr2 = r2,

            [Symbol("dr3")]
            dr3 = r3,

            [Symbol("dr4")]
            dr4 = r4,

            [Symbol("dr5")]
            dr5 = r5,

            [Symbol("dr6")]
            dr6 = r6,

            [Symbol("dr7")]
            dr7 = r7,
        }

        /// <summary>
        /// Defines mask register indices
        /// k0, k1, k2, k3, k4, k5, k6, k7
        /// </summary>
        [SymSource(Group), RegCode(TK.Mask)]
        public enum KReg : byte
        {
            [Symbol("k0")]
            k0 = r0,

            [Symbol("k1")]
            k1 = r1,

            [Symbol("k2")]
            k2 = r2,

            [Symbol("k3")]
            k3 = r3,

            [Symbol("k4")]
            k4 = r4,

            [Symbol("k5")]
            k5 = r5,

            [Symbol("k6")]
            k6 = r6,

            [Symbol("k7")]
            k7 = r7
        }

        [SymSource(Group), RegCode(TK.Test)]
        public enum TestReg : byte
        {
            [Symbol("tr0")]
            tr0 = r0,

            [Symbol("tr1")]
            tr1 = r1,

            [Symbol("tr2")]
            tr2 = r2,

            [Symbol("tr3")]
            tr3 = r3,

            [Symbol("tr4")]
            tr4 = r4,

            [Symbol("tr5")]
            tr5 = r5,

            [Symbol("tr6")]
            tr6 = r6,

            [Symbol("tr7")]
            tr7 = r7
        }

        [SymSource(Group), RegCode(TK.Fp)]
        public enum FpuReg : byte
        {
            [Symbol("ST(0)")]
            st0 = r0,

            [Symbol("ST(1)")]
            st1 = r1,

            [Symbol("ST(2)")]
            st2 = r2,

            [Symbol("ST(3)")]
            st3 = r3,

            [Symbol("ST(4)")]
            st4 = r4,

            [Symbol("ST(5)")]
            st5 = r5,

            [Symbol("ST(6)")]
            st6 = r6,

            [Symbol("ST(7)")]
            st7 = r7,
        }

        /// <summary>
        /// cs, ds, ss, es, fs, gs
        /// </summary>
        [SymSource(Group), RegCode(TK.Seg)]
        public enum SegReg : byte
        {
            /// <summary>
            /// Code segment register
            /// </summary>
            [Symbol("cs")]
            cs = r0,

            /// <summary>
            /// Data segment register
            /// </summary>
            [Symbol("ds")]
            ds = r1,

            /// <summary>
            /// Stack segment register
            /// </summary>
            [Symbol("ss")]
            ss = r2,

            /// <summary>
            /// Extra segment (1)
            /// </summary>
            [Symbol("es")]
            es = r3,

            /// <summary>
            /// Extra segment (2)
            /// </summary>
            [Symbol("fs")]
            fs = r4,

            /// <summary>
            /// Extra segment (3)
            /// </summary>
            [Symbol("gs")]
            gs = r5,
        }

        /// <summary>
        /// gdtr, ldtr, idtr
        /// </summary>
        [SymSource(Group), RegCode(TK.SysPtr)]
        public enum SPtrReg : byte
        {
            /// <summary>
            /// The global descriptor table register
            /// </summary>
            [Symbol("GDTR")]
            gdtr = r0,

            /// <summary>
            /// The local descriptor table register
            /// </summary>
            [Symbol("LDTR")]
            ldtr = r1,


            /// <summary>
            /// The interrupt descriptor table register
            /// </summary>
            [Symbol("IDTR")]
            idtr = r2,
        }

        /// <summary>
        /// Specifies the MMX registers
        /// mmx0, mmx1, mmx2, mmx3, mmx4, mmx5, mmx6, mmx7
        /// "The interrupt descriptor table register"
        /// </summary>
        [SymSource(Group), RegCode(TK.Mmx)]
        public enum MmxReg : byte
        {
            [Symbol("mmx0")]
            mm0 = r0,

            [Symbol("mmx1")]
            mm1 = r1,

            [Symbol("mmx2")]
            mm2 = r2,

            [Symbol("mmx3")]
            mm3 = r3,

            [Symbol("mmx4")]
            mm4 = r4,

            [Symbol("mmx5")]
            mm5 = r5,

            [Symbol("mmx6")]
            mm6 = r6,

            [Symbol("mmx7")]
            mm7 = r7,
        }

        /// <summary>
        /// Specifies instruction pointer registers
        /// ip, eip, rip
        /// </summary>
        [SymSource(Group), RegCode(TK.Ip)]
        public enum IpReg : byte
        {
            [Symbol("ip")]
            IP,

            [Symbol("eip")]
            EIP,

            [Symbol("rip")]
            RIP,
        }
    }
}