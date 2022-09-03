namespace Windows
{
    [StructLayout(LayoutKind.Sequential, Size=2, Pack=0)]
    public struct WORD
    {

    }

    [StructLayout(LayoutKind.Sequential, Size=1, Pack=0)]
    public struct BYTE
    {

    }

    [StructLayout(LayoutKind.Sequential, Size=4, Pack=0)]
    public struct DWORD
    {

    }

    [StructLayout(LayoutKind.Sequential, Size=8, Pack=0)]
    public struct DWORD64
    {

    }

    [StructLayout(LayoutKind.Sequential, Size=16, Pack=16)]
    public struct M128A
    {

    }

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct Fp128x8Regs
    {
        public M128A Xmm0;

        public M128A Xmm1;

        public M128A Xmm2;

        public M128A Xmm3;

        public M128A Xmm4;

        public M128A Xmm5;

        public M128A Xmm6;

        public M128A Xmm7;
    }

    [StructLayout(LayoutKind.Sequential, Pack=16)]
    public struct Xmm16x16Regs
    {
        public M128A Xmm0;

        public M128A Xmm1;

        public M128A Xmm2;

        public M128A Xmm3;

        public M128A Xmm4;

        public M128A Xmm5;

        public M128A Xmm6;

        public M128A Xmm7;

        public M128A Xmm8;

        public M128A Xmm9;

        public M128A Xmm10;

        public M128A Xmm11;

        public M128A Xmm12;

        public M128A Xmm13;

        public M128A Xmm14;

        public M128A Xmm15;
    }


    [StructLayout(LayoutKind.Sequential, Pack=16)]
    public struct Xmm16x26Regs
    {
        public M128A Xmm0;

        public M128A Xmm1;

        public M128A Xmm2;

        public M128A Xmm3;

        public M128A Xmm4;

        public M128A Xmm5;

        public M128A Xmm6;

        public M128A Xmm7;

        public M128A Xmm8;

        public M128A Xmm9;

        public M128A Xmm10;

        public M128A Xmm11;

        public M128A Xmm12;

        public M128A Xmm13;

        public M128A Xmm14;

        public M128A Xmm15;

        public M128A Xmm16;

        public M128A Xmm17;

        public M128A Xmm18;

        public M128A Xmm19;

        public M128A Xmm20;

        public M128A Xmm21;

        public M128A Xmm22;

        public M128A Xmm23;

        public M128A Xmm24;

        public M128A Xmm25;

        public M128A Xmm26;
    }

    [StructLayout(LayoutKind.Sequential, Pack=16)]
    public struct XMM_SAVE_AREA32
    {
        public WORD ControlWord;

        public WORD StatusWord;

        public BYTE TagWord;

        public BYTE Reserved1;

        public WORD ErrorOpcode;

        public DWORD ErrorOffset;

        public WORD ErrorSelector;

        public WORD Reserved2;

        public DWORD DataOffset;

        public WORD DataSelector;

        public WORD Reserved3;

        public DWORD MxCsr;

        public DWORD MxCsr_Mask;

        public Fp128x8Regs Fp;

        public Xmm16x16Regs Xmm;

        public RESERVE_96 Reserved4;

        [StructLayout(LayoutKind.Sequential, Size=96)]
        public struct RESERVE_96
        {

        }
    }

    public enum ContextFlags : uint
    {
        CONTEXT_AMD64 = 0x00100000,

        CONTEXT_CONTROL = CONTEXT_AMD64 | 0x00000001,

        CONTEXT_INTEGER = CONTEXT_AMD64 | 0x00000002,

        CONTEXT_SEGMENTS = CONTEXT_AMD64 | 0x00000004,

        CONTEXT_FLOATING_POINT = CONTEXT_AMD64 | 0x00000008,

        CONTEXT_DEBUG_REGISTERS = CONTEXT_AMD64 | 0x00000010,

        CONTEXT_FULL = CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_FLOATING_POINT,

        CONTEXT_ALL = CONTEXT_CONTROL | CONTEXT_INTEGER |CONTEXT_SEGMENTS | CONTEXT_FLOATING_POINT | CONTEXT_DEBUG_REGISTERS,

        CONTEXT_XSTATE = CONTEXT_AMD64 | 0x00000040,
    }
}