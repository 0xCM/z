//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed)]
    public enum CpuidBit : ushort
    {
        INVALID,

        ADOXADCX,

        AES,

        AMX_BF16,

        AMX_INT8,

        AMX_TILES,

        AVX,

        AVX2,

        AVX512BW,

        AVX512CD,

        AVX512DQ,

        AVX512ER,

        AVX512F,

        AVX512IFMA,

        AVX512PF,

        AVX512VBMI,

        AVX512VL,

        AVX512_4FMAPS,

        AVX512_4VNNIW,

        AVX512_BITALG,

        AVX512_VBMI2,

        AVX512_VNNI,

        AVX512_VP2INTERSECT,

        AVX512_VPOPCNTDQ,

        AVX_VNNI,

        BF16,

        BMI1,

        BMI2,

        CET,

        CLDEMOTE,

        CLFLUSH,

        CLFLUSHOPT,

        CLWB,

        CMPXCHG16B,

        ENQCMD,

        F16C,

        FMA,

        FXSAVE,

        GFNI,

        HRESET,

        INTEL64,

        INTELPT,

        INVPCID,

        KLENABLED,

        KLSUPPORTED,

        KLWIDE,

        LAHF,

        LZCNT,

        MCOMMIT,

        MONITOR,

        MONITORX,

        MOVDIR64B,

        MOVDIRI,

        MOVEBE,

        MPX,

        OSPKU,

        OSXSAVE,

        PCLMULQDQ,

        PCONFIG,

        PKU,

        POPCNT,

        PREFETCHW,

        PREFETCHWT1,

        PTWRITE,

        RDP,

        RDPRU,

        RDRAND,

        RDSEED,

        RDTSCP,

        RDWRFSGS,

        RTM,

        SERIALIZE,

        SGX,

        SHA,

        SMAP,

        SMX,

        SNP,

        SSE,

        SSE2,

        SSE3,

        SSE4,

        SSE42,

        SSE4A,

        SSSE3,

        TSX_LDTRK,

        UINTR,

        VAES,

        VIA_PADLOCK_AES,

        VIA_PADLOCK_AES_EN,

        VIA_PADLOCK_PMM,

        VIA_PADLOCK_PMM_EN,

        VIA_PADLOCK_RNG,

        VIA_PADLOCK_RNG_EN,

        VIA_PADLOCK_SHA,

        VIA_PADLOCK_SHA_EN,

        VMX,

        VPCLMULQDQ,

        WAITPKG,

        WBNOINVD,

        XSAVE,

        XSAVEC,

        XSAVEOPT,

        XSAVES,
    }
}
