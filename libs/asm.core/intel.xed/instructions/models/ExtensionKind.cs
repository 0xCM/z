//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(num7.Width)]
        public enum ExtensionKind : byte
        {
            INVALID = 0,

            [Symbol("3DNOW")]
            _3DNOW,

            [Symbol("3DNOW_PREFETCH")]
            _3DNOW_PREFETCH,

            ADOX_ADCX,

            AES,

            AMD_INVLPGB,

            AMX_BF16,

            AMX_INT8,

            AMX_TILE,

            AVX,

            AVX2,

            AVX2GATHER,

            AVX512EVEX,

            AVX512VEX,

            AVXAES,

            AVX_VNNI,

            BASE,

            BMI1,

            BMI2,

            CET,

            CLDEMOTE,

            CLFLUSHOPT,

            CLFSH,

            CLWB,

            CLZERO,

            ENQCMD,

            F16C,

            FMA,

            FMA4,

            GFNI,

            HRESET,

            INVPCID,

            KEYLOCKER,

            KEYLOCKER_WIDE,

            LONGMODE,

            LZCNT,

            MCOMMIT,

            MMX,

            MONITOR,

            MONITORX,

            MOVBE,

            MOVDIR,

            MPX,

            PAUSE,

            PCLMULQDQ,
            PCONFIG,
            PKU,
            PREFETCHWT1,
            PTWRITE,
            RDPID,
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

            SSE3,

            SSE4,

            SSE4a,

            SSSE3,

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