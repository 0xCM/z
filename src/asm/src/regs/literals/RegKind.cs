//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static NumericBaseKind;

using SR = SegRegKind;
using F = FlagRegKind;
using X = XmmRegKind;
using Y = YmmRegKind;
using Z = ZmmRegKind;
using G8 = Gp8Kind;
using G16 = Gp16Kind;
using G32 = Gp32Kind;
using G64 = Gp64Kind;
using M = MaskRegKind;
using C = ControlRegKind;
using XCR = XControlRegKind;
using D = DebugRegKind;
using I = IpRegKind;
using B = BndRegKind;
using ST = FpuRegKind;
using MM = MmxRegKind;
using TR = TestRegKind;
using SPTR = SysPtrRegKind;
using TMM = TmmRegKind;

[SymSource("asm.regs.bits", Base16)]
public enum RegKind : ushort
{
    // ~ FLAGS registers
    // ~ ------------------------------------------------------------------

    [Symbol("flags")]
    FLAGS = F.Flags,

    [Symbol("eflags")]
    EFLAGS = F.EFlags,

    [Symbol("rflags")]
    RFLAGS = F.RFlags,

    // ~ 16-bit segment registers
    // ~ ------------------------------------------------------------------
    [Symbol("cs")]
    CS = SR.CS,

    [Symbol("ds")]
    DS = SR.DS,

    [Symbol("ss")]
    SS = SR.SS,

    [Symbol("es")]
    ES = SR.ES,

    [Symbol("fs")]
    FS = SR.FS,

    [Symbol("gs")]
    GS = SR.GS,

    // ~ 8-bit general-purpose registers
    // ~ ------------------------------------------------------------------

    [Symbol("al")]
    AL = G8.AL,

    [Symbol("ah")]
    AH = G8.AH,

    [Symbol("cl")]
    CL = G8.CL,

    [Symbol("ch")]
    CH = G8.CH,

    [Symbol("dl")]
    DL = G8.DL,

    [Symbol("dh")]
    DH = G8.DH,

    [Symbol("bl")]
    BL = G8.BL,

    [Symbol("bh")]
    BH = G8.BH,

    [Symbol("spl")]
    SPL = G8.SPL,

    [Symbol("bpl")]
    BPL = G8.BPL,

    [Symbol("sil")]
    SIL = G8.SIL,

    [Symbol("dil")]
    DIL = G8.DIL,

    [Symbol("r8b")]
    R8B = G8.R8B,

    [Symbol("r9b")]
    R9B = G8.R9B,

    [Symbol("r10b")]
    R10B = G8.R10B,

    [Symbol("r11b")]
    R11B = G8.R11B,

    [Symbol("r12b")]
    R12B = G8.R12B,

    [Symbol("r13b")]
    R13B = G8.R13B,

    [Symbol("r14b")]
    R14B = G8.R14B,

    [Symbol("r15b")]
    R15B = G8.R15B,

    // ~ 16-bit general-purpose registers
    // ~ ------------------------------------------------------------------

    [Symbol("ax")]
    AX = G16.AX,

    [Symbol("cx")]
    CX = G16.CX,

    [Symbol("dx")]
    DX = G16.DX,

    [Symbol("bx")]
    BX = G16.BX,

    [Symbol("sp")]
    SP = G16.SP,

    [Symbol("bp")]
    BP = G16.BP,

    [Symbol("si")]
    SI = G16.SI,

    [Symbol("di")]
    DI = G16.DI,

    [Symbol("r8w")]
    R8W = G16.R8W,

    [Symbol("r9w")]
    R9W = G16.R9W,

    [Symbol("r10w")]
    R10W = G16.R10W,

    [Symbol("r11w")]
    R11W = G16.R11W,

    [Symbol("r12w")]
    R12W = G16.R12W,

    [Symbol("r13w")]
    R13W = G16.R13W,

    [Symbol("r14w")]
    R14W = G16.R14W,

    [Symbol("r15w")]
    R15W = G16.R15W,

    // ~ 32-bit general-purpose registers
    // ~ ------------------------------------------------------------------

    [Symbol("eax")]
    EAX = G32.EAX,

    [Symbol("ecx")]
    ECX = G32.ECX,

    [Symbol("edx")]
    EDX = G32.EDX,

    [Symbol("ebx")]
    EBX = G32.EBX,

    [Symbol("esp")]
    ESP = G32.ESP,

    [Symbol("ebp")]
    EBP = G32.EBP,

    [Symbol("esi")]
    ESI = G32.ESI,

    [Symbol("edi")]
    EDI = G32.EDI,

    [Symbol("r8d")]
    R8D = G32.R8D,

    [Symbol("r9d")]
    R9D = G32.R9D,

    [Symbol("r10d")]
    R10D = G32.R10D,

    [Symbol("r11d")]
    R11D = G32.R11D,

    [Symbol("r12d")]
    R12D = G32.R12D,

    [Symbol("r13d")]
    R13D = G32.R13D,

    [Symbol("r14d")]
    R14D = G32.R14D,

    [Symbol("r15d")]
    R15D = G32.R15D,

    // ~ 64-bit general-purpose registers
    // ~ ------------------------------------------------------------------

    [Symbol("rax")]
    RAX = G64.RAX,

    [Symbol("rcx")]
    RCX = G64.RCX,

    [Symbol("rdx")]
    RDX = G64.RDX,

    [Symbol("rbx")]
    RBX = G64.RBX,

    [Symbol("rsp")]
    RSP = G64.RSP,

    [Symbol("rbp")]
    RBP = G64.RBP,

    [Symbol("rsi")]
    RSI = G64.RSI,

    [Symbol("rdi")]
    RDI = G64.RDI,

    [Symbol("r8")]
    R8Q = G64.R8Q,

    [Symbol("r9")]
    R9Q = G64.R9Q,

    [Symbol("r10")]
    R10Q = G64.R10Q,

    [Symbol("r11")]
    R11Q = G64.R11Q,

    [Symbol("r12")]
    R12Q = G64.R12Q,

    [Symbol("r13")]
    R13Q = G64.R13Q,

    [Symbol("r14")]
    R14Q = G64.R14Q,

    [Symbol("r15")]
    R15Q = G64.R15Q,

    // ~ 128-bit vectorized registers
    // ~ ------------------------------------------------------------------

    [Symbol("xmm0")]
    XMM0 = X.XMM0,

    [Symbol("xmm1")]
    XMM1 = X.XMM1,

    [Symbol("xmm2")]
    XMM2 = X.XMM2,

    [Symbol("xmm3")]
    XMM3 = X.XMM3,

    [Symbol("xmm4")]
    XMM4 = X.XMM4,

    [Symbol("xmm5")]
    XMM5 = X.XMM5,

    [Symbol("xmm6")]
    XMM6 = X.XMM6,

    [Symbol("xmm7")]
    XMM7 = X.XMM7,

    [Symbol("xmm8")]
    XMM8 = X.XMM8,

    [Symbol("xmm9")]
    XMM9 = X.XMM9,

    [Symbol("xmm10")]
    XMM10 = X.XMM10,

    [Symbol("xmm11")]
    XMM11 = X.XMM11,

    [Symbol("xmm12")]
    XMM12 = X.XMM12,

    [Symbol("xmm13")]
    XMM13 = X.XMM13,

    [Symbol("xmm14")]
    XMM14 = X.XMM14,

    [Symbol("xmm15")]
    XMM15 = X.XMM15,

    [Symbol("xmm16")]
    XMM16 = X.XMM16,

    [Symbol("xmm17")]
    XMM17 = X.XMM17,

    [Symbol("xmm18")]
    XMM18 = X.XMM18,

    [Symbol("xmm19")]
    XMM19 = X.XMM19,

    [Symbol("xmm20")]
    XMM20 = X.XMM20,

    [Symbol("xmm21")]
    XMM21 = X.XMM21,

    [Symbol("xmm22")]
    XMM22 = X.XMM22,

    [Symbol("xmm23")]
    XMM23 = X.XMM23,

    [Symbol("xmm24")]
    XMM24 = X.XMM24,

    [Symbol("xmm25")]
    XMM25 = X.XMM25,

    [Symbol("xmm26")]
    XMM26 = X.XMM26,

    [Symbol("xmm27")]
    XMM27 = X.XMM27,

    [Symbol("xmm28")]
    XMM28 = X.XMM28,

    [Symbol("xmm29")]
    XMM29 = X.XMM29,

    [Symbol("xmm30")]
    XMM30 = X.XMM30,

    [Symbol("xmm31")]
    XMM31 = X.XMM31,

    // ~ 256-bit vectorized registers
    // ~ ------------------------------------------------------------------

    [Symbol("ymm0")]
    YMM0 = Y.YMM0,

    [Symbol("ymm1")]
    YMM1 = Y.YMM1,

    [Symbol("ymm2")]
    YMM2 = Y.YMM2,

    [Symbol("ymm3")]
    YMM3 = Y.YMM3,

    [Symbol("ymm4")]
    YMM4 = Y.YMM4,

    [Symbol("ymm5")]
    YMM5 = Y.YMM5,

    [Symbol("ymm6")]
    YMM6 = Y.YMM6,

    [Symbol("ymm7")]
    YMM7 = Y.YMM7,

    [Symbol("ymm8")]
    YMM8 = Y.YMM8,

    [Symbol("ymm9")]
    YMM9 = Y.YMM9,

    [Symbol("ymm10")]
    YMM10 = Y.YMM10,

    [Symbol("ymm11")]
    YMM11 = Y.YMM11,

    [Symbol("ymm12")]
    YMM12 = Y.YMM12,

    [Symbol("ymm13")]
    YMM13 = Y.YMM13,

    [Symbol("ymm14")]
    YMM14 = Y.YMM14,

    [Symbol("ymm15")]
    YMM15 = Y.YMM15,

    [Symbol("ymm16")]
    YMM16 = Y.YMM16,

    [Symbol("ymm17")]
    YMM17 = Y.YMM16,

    [Symbol("ymm18")]
    YMM18 = Y.YMM18,

    [Symbol("ymm19")]
    YMM19 = Y.YMM19,

    [Symbol("ymm20")]
    YMM20 = Y.YMM20,

    [Symbol("ymm21")]
    YMM21 = Y.YMM21,

    [Symbol("ymm22")]
    YMM22 = Y.YMM22,

    [Symbol("ymm23")]
    YMM23 = Y.YMM23,

    [Symbol("ymm24")]
    YMM24 = Y.YMM24,

    [Symbol("ymm25")]
    YMM25 = Y.YMM25,

    [Symbol("ymm26")]
    YMM26 = Y.YMM26,

    [Symbol("ymm27")]
    YMM27 = Y.YMM27,

    [Symbol("ymm28")]
    YMM28 = Y.YMM28,

    [Symbol("ymm29")]
    YMM29 = Y.YMM29,

    [Symbol("ymm30")]
    YMM30 = Y.YMM30,

    [Symbol("ymm31")]
    YMM31 = Y.YMM31,

    // ~ 512-bit vectorized registers
    // ~ ------------------------------------------------------------------

    [Symbol("zmm0")]
    ZMM0 = Z.ZMM0,

    [Symbol("zmm1")]
    ZMM1 = Z.ZMM1,

    [Symbol("zmm2")]
    ZMM2 = Z.ZMM2,

    [Symbol("zmm3")]
    ZMM3 = Z.ZMM3,

    [Symbol("zmm4")]
    ZMM4 = Z.ZMM4,

    [Symbol("zmm5")]
    ZMM5 = Z.ZMM5,

    [Symbol("zmm6")]
    ZMM6 = Z.ZMM6,

    [Symbol("zmm7")]
    ZMM7 = Z.ZMM7,

    [Symbol("zmm8")]
    ZMM8 = Z.ZMM8,

    [Symbol("zmm9")]
    ZMM9 = Z.ZMM9,

    [Symbol("zmm10")]
    ZMM10 = Z.ZMM10,

    [Symbol("zmm11")]
    ZMM11 = Z.ZMM11,

    [Symbol("zmm12")]
    ZMM12 = Z.ZMM12,

    [Symbol("zmm13")]
    ZMM13 = Z.ZMM13,

    [Symbol("zmm14")]
    ZMM14 = Z.ZMM14,

    [Symbol("zmm15")]
    ZMM15 = Z.ZMM15,

    [Symbol("zmm16")]
    ZMM16 = Z.ZMM16,

    [Symbol("zmm17")]
    ZMM17 = Z.ZMM17,

    [Symbol("zmm18")]
    ZMM18 = Z.ZMM18,

    [Symbol("zmm19")]
    ZMM19 = Z.ZMM19,

    [Symbol("zmm20")]
    ZMM20 = Z.ZMM20,

    [Symbol("zmm21")]
    ZMM21 = Z.ZMM21,

    [Symbol("zmm22")]
    ZMM22 = Z.ZMM22,

    [Symbol("zmm23")]
    ZMM23 = Z.ZMM23,

    [Symbol("zmm24")]
    ZMM24 = Z.ZMM24,

    [Symbol("zmm25")]
    ZMM25 = Z.ZMM25,

    [Symbol("zmm26")]
    ZMM26 = Z.ZMM26,

    [Symbol("zmm27")]
    ZMM27 = Z.ZMM27,

    [Symbol("zmm28")]
    ZMM28 = Z.ZMM28,

    [Symbol("zmm29")]
    ZMM29 = Z.ZMM29,

    [Symbol("zmm30")]
    ZMM30 = Z.ZMM30,

    [Symbol("zmm31")]
    ZMM31 = Z.ZMM31,

    // ~ 64-bit mask registers
    // ~ ------------------------------------------------------------------

    [Symbol("k0")]
    K0 = M.K0,

    [Symbol("k1")]
    K1 = M.K1,

    [Symbol("k2")]
    K2 = M.K2,

    [Symbol("k3")]
    K3 = M.K3,

    [Symbol("k4")]
    K4 = M.K4,

    [Symbol("k5")]
    K5 = M.K5,

    [Symbol("k6")]
    K6 = M.K6,

    [Symbol("k7")]
    K7 = M.K7,

    // ~ Control registers
    // ~ ------------------------------------------------------------------

    [Symbol("cr0")]
    CR0 = C.CR0,

    [Symbol("cr1")]
    CR1 = C.CR1,

    [Symbol("cr2")]
    CR2 = C.CR2,

    [Symbol("cr3")]
    CR3 = C.CR3,

    [Symbol("cr4")]
    CR4 = C.CR4,

    [Symbol("cr5")]
    CR5 = C.CR5,

    [Symbol("cr6")]
    CR6 = C.CR6,

    [Symbol("cr7")]
    CR7 = C.CR7,

    // ~ Debug registers
    // ~ ------------------------------------------------------------------

    [Symbol("dr0")]
    DR0 = D.DR0,

    [Symbol("dr1")]
    DR1 = D.DR1,

    [Symbol("dr2")]
    DR2 = D.DR2,

    [Symbol("dr3")]
    DR3 = D.DR3,

    [Symbol("dr4")]
    DR4 = D.DR4,

    [Symbol("dr5")]
    DR5 = D.DR5,

    [Symbol("dr6")]
    DR6 = D.DR6,

    [Symbol("dr7")]
    DR7 = D.DR7,

    // ~ Test registers
    // ~ ------------------------------------------------------------------

    [Symbol("tr0")]
    TR0 = TR.TR0,

    [Symbol("tr1")]
    TR1 = TR.TR1,

    [Symbol("tr2")]
    TR2 = TR.TR2,

    [Symbol("tr3")]
    TR3 = TR.TR3,

    [Symbol("tr4")]
    TR4 = TR.TR4,

    [Symbol("tr5")]
    TR5 = TR.TR5,

    [Symbol("tr6")]
    TR6 = TR.TR6,

    [Symbol("tr7")]
    TR7 = TR.TR7,

    // ~ BND registers
    // ~ ------------------------------------------------------------------

    [Symbol("bnd0")]
    BND0 = B.BND0,

    [Symbol("bnd1")]
    BND1 = B.BND1,

    [Symbol("bnd2")]
    BND2 = B.BND2,

    [Symbol("bnd3")]
    BND3 = B.BND3,

    // ~ FP registers
    // ~ ------------------------------------------------------------------

    [Symbol("st0")]
    ST0 = ST.ST0,

    [Symbol("st1")]
    ST1 = ST.ST1,

    [Symbol("st2")]
    ST2 = ST.ST2,

    [Symbol("st3")]
    ST3 = ST.ST3,

    [Symbol("st4")]
    ST4 = ST.ST4,

    [Symbol("st5")]
    ST5 = ST.ST5,

    [Symbol("st6")]
    ST6 = ST.ST6,

    [Symbol("st7")]
    ST7 = ST.ST7,

    // ~ MMX registers
    // ~ ------------------------------------------------------------------

    [Symbol("mm0")]
    MM0 = MM.MM0,

    [Symbol("mm1")]
    MM1 = MM.MM1,

    [Symbol("mm2")]
    MM2 = MM.MM2,

    [Symbol("mm3")]
    MM3 = MM.MM3,

    [Symbol("mm4")]
    MM4 = MM.MM4,

    [Symbol("mm5")]
    MM5 = MM.MM5,

    [Symbol("mm6")]
    MM6 = MM.MM6,

    [Symbol("mm7")]
    MM7 = MM.MM7,

    // ~ Intruction pointer registers
    // ~ ------------------------------------------------------------------

    [Symbol("ip")]
    IP = I.IP,

    [Symbol("eip")]
    EIP = I.EIP,

    [Symbol("rip")]
    RIP = I.RIP,

    // ~ System pointer registers

    [Symbol("gdtr")]
    GDTR = SPTR.GDTR,

    [Symbol("ldtr")]
    LDTR = SPTR.LDTR,

    [Symbol("idtr")]
    IDTR = SPTR.IDTR,

    [Symbol("xcr0")]
    XCR0 = XCR.XCR0,

    // ~ TMM registers
    // ~ ------------------------------------------------------------------

    [Symbol("tmm0")]
    TMM0 = TMM.TMM0,

    [Symbol("tmm1")]
    TMM1 = TMM.TMM1,

    [Symbol("tmm2")]
    TMM2 = TMM.TMM2,

    [Symbol("tmm3")]
    TMM3 = TMM.TMM3,

    [Symbol("tmm4")]
    TMM4 = TMM.TMM4,

    [Symbol("tmm5")]
    TMM5 = TMM.TMM5,

    [Symbol("tmm6")]
    TMM6 = TMM.TMM6,

    [Symbol("tmm7")]
    TMM7 = TMM.TMM7,
}
