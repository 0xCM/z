//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum InstIsaKind : byte
        {
            INVALID = 0,

            [Symbol("3DNOW")]
            _3DNOW,

            [Symbol("3DNOW_PREFETCH")]
            _3DNOW_PREFETCH,

            ADOX_ADCX,

            AES,

            AMD,

            AMD_INVLPGB,

            AMX_BF16,

            AMX_INT8,

            AMX_TILE,

            AVX,

            AVX2,

            AVX2GATHER,

            AVX512BW_128,

            AVX512BW_128N,

            AVX512BW_256,

            AVX512BW_512,

            AVX512BW_KOP,

            AVX512CD_128,

            AVX512CD_256,

            AVX512CD_512,

            AVX512DQ_128,

            AVX512DQ_128N,

            AVX512DQ_256,

            AVX512DQ_512,

            AVX512DQ_KOP,

            AVX512DQ_SCALAR,

            AVX512ER_512,

            AVX512ER_SCALAR,

            AVX512F_128,

            AVX512F_128N,

            AVX512F_256,

            AVX512F_512,

            AVX512F_KOP,

            AVX512F_SCALAR,

            AVX512PF_512,

            AVX512_4FMAPS_512,

            AVX512_4FMAPS_SCALAR,

            AVX512_4VNNIW_512,

            AVX512_BF16_128,

            AVX512_BF16_256,

            AVX512_BF16_512,

            AVX512_BITALG_128,

            AVX512_BITALG_256,

            AVX512_BITALG_512,

            AVX512_GFNI_128,

            AVX512_GFNI_256,

            AVX512_GFNI_512,

            AVX512_IFMA_128,

            AVX512_IFMA_256,

            AVX512_IFMA_512,

            AVX512_VAES_128,

            AVX512_VAES_256,

            AVX512_VAES_512,

            AVX512_VBMI2_128,

            AVX512_VBMI2_256,

            AVX512_VBMI2_512,

            AVX512_VBMI_128,

            AVX512_VBMI_256,

            AVX512_VBMI_512,

            AVX512_VNNI_128,

            AVX512_VNNI_256,

            AVX512_VNNI_512,

            AVX512_VP2INTERSECT_128,

            AVX512_VP2INTERSECT_256,

            AVX512_VP2INTERSECT_512,

            AVX512_VPCLMULQDQ_128,

            AVX512_VPCLMULQDQ_256,

            AVX512_VPCLMULQDQ_512,

            AVX512_VPOPCNTDQ_128,

            AVX512_VPOPCNTDQ_256,

            AVX512_VPOPCNTDQ_512,

            AVXAES,

            AVX_GFNI,

            AVX_VNNI,

            BMI1,

            BMI2,
            CET,

            CLDEMOTE,

            CLFLUSHOPT,

            CLFSH,

            CLWB,

            CLZERO,

            CMOV,

            CMPXCHG16B,

            ENQCMD,

            F16C,

            FAT_NOP,

            FCMOV,

            FMA,

            FMA4,

            FXSAVE,

            FXSAVE64,

            GFNI,

            HRESET,

            I186,

            I286PROTECTED,

            I286REAL,

            I386,

            I486,

            I486REAL,

            I86,

            INVPCID,

            KEYLOCKER,

            KEYLOCKER_WIDE,

            LAHF,

            LONGMODE,

            LWP,

            LZCNT,

            MCOMMIT,

            MONITOR,

            MONITORX,

            MOVBE,

            MOVDIR,

            MPX,

            PAUSE,

            PCLMULQDQ,

            PCONFIG,

            PENTIUMMMX,

            PENTIUMREAL,

            PKU,

            POPCNT,

            PPRO,

            PPRO_UD0_LONG,

            PPRO_UD0_SHORT,

            PREFETCHW,

            PREFETCHWT1,

            PREFETCH_NOP,

            PTWRITE,

            RDPID,

            RDPMC,

            RDPRU,

            RDRAND,

            RDSEED,

            RDTSCP,

            RDWRFSGS,

            RTM,

            SERIALIZE,

            SGX,

            SGX_ENCLV,

            SHA,

            SMAP,

            SMX,

            SNP,

            SSE,

            SSE2,

            SSE2MMX,

            SSE3,

            SSE3X87,

            SSE4,

            SSE42,

            SSE4a,

            SSEMXCSR,

            SSE_PREFETCH,

            SSSE3,

            SSSE3MMX,

            SVM,
            TBM,

            TDX,

            TSX_LDTRK,

            UINTR,

            VAES,

            VIA_PADLOCK_AES,

            VIA_PADLOCK_MONTMUL,

            VIA_PADLOCK_RNG,

            VIA_PADLOCK_SHA,

            VMFUNC,

            VPCLMULQDQ,

            VTX,

            WAITPKG,

            WBNOINVD,

            X87,

            XOP,

            XSAVE,

            XSAVEC,

            XSAVEOPT,

            XSAVES,
        }
    }
}