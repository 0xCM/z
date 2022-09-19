//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRegId;

    partial struct XedModels
    {
        public readonly struct RegIdFacets
        {
            public const XedRegId BNDCFG_FIRST=BNDCFGU;

            public const XedRegId BNDCFG_LAST=BNDCFGU;

            public const XedRegId BNDSTAT_FIRST=BNDSTATUS;

            public const XedRegId BNDSTAT_LAST=BNDSTATUS;

            public const XedRegId BOUND_FIRST=BND0;

            public const XedRegId BOUND_LAST=BND3;

            public const XedRegId CR_FIRST=CR0;

            public const XedRegId CR_LAST=CR15;

            public const XedRegId DR_FIRST=DR0;

            public const XedRegId DR_LAST=DR7;

            public const XedRegId FLAGS_FIRST=FLAGS;

            public const XedRegId FLAGS_LAST=RFLAGS;

            public const XedRegId GPR16_FIRST=AX;

            public const XedRegId GPR16_LAST=R15W;

            public const XedRegId GPR32_FIRST=EAX;

            public const XedRegId GPR32_LAST=R15D;

            public const XedRegId GPR64_FIRST=RAX;

            public const XedRegId GPR64_LAST=R15;

            public const XedRegId GPR8_FIRST=AL;

            public const XedRegId GPR8_LAST=R15B;

            public const XedRegId GPR8h_FIRST=AH;

            public const XedRegId GPR8h_LAST=BH;

            public const XedRegId INVALID_FIRST=INVALID;

            public const XedRegId INVALID_LAST=ERROR;

            public const XedRegId IP_FIRST=RIP;

            public const XedRegId IP_LAST=IP;

            public const XedRegId MASK_FIRST=K0;

            public const XedRegId MASK_LAST=K7;

            public const XedRegId MMX_FIRST=MMX0;

            public const XedRegId MMX_LAST=MMX7;

            public const XedRegId MSR_FIRST=SSP;

            public const XedRegId MSR_LAST=IA32_U_CET;

            public const XedRegId MXCSR_FIRST=MXCSR;

            public const XedRegId MXCSR_LAST=MXCSR;

            public const XedRegId PSEUDO_FIRST=STACKPUSH;

            public const XedRegId PSEUDO_LAST=TILECONFIG;

            public const XedRegId PSEUDOX87_FIRST=X87CONTROL;

            public const XedRegId PSEUDOX87_LAST=X87LASTDP;

            public const XedRegId SR_FIRST=ES;

            public const XedRegId SR_LAST=GS;

            public const XedRegId TMP_FIRST=TMP0;

            public const XedRegId TMP_LAST=TMP15;

            public const XedRegId TREG_FIRST=TMM0;

            public const XedRegId TREG_LAST=TMM7;

            public const XedRegId UIF_FIRST=UIF;

            public const XedRegId UIF_LAST=UIF;

            public const XedRegId X87_FIRST=ST0;

            public const XedRegId X87_LAST=ST7;

            public const XedRegId XCR_FIRST=XCR0;

            public const XedRegId XCR_LAST=XCR0;

            public const XedRegId XMM_FIRST=XMM0;

            public const XedRegId XMM_LAST=XMM31;

            public const XedRegId YMM_FIRST=YMM0;

            public const XedRegId YMM_LAST = YMM31;

            public const XedRegId ZMM_FIRST = ZMM0;

            public const XedRegId ZMM_LAST = ZMM31;

            public const XedRegId LAST = ZMM_LAST;
        }
    }
}