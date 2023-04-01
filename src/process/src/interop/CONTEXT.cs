//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=16)]
    public unsafe struct CONTEXT
    {
        public Hex64 P1Home;

        public Hex64 P2Home;

        public Hex64 P3Home;

        public Hex64 P4Home;

        public Hex64 P5Home;

        public Hex64 P6Home;

        public CONTEXT_FLAGS ContextFlags;

        public Hex32 MxCsr;

        public Hex16 SegCs;
        
        public Hex16 SegDs;
        
        public Hex16 SegEs;
        
        public Hex16 SegFs;
        
        public Hex16 SegGs;
        
        public Hex16 SegSs;
        
        public uint EFlags;

        public Hex64 Dr0;
        
        public Hex64 Dr1;
        
        public Hex64 Dr2;
        
        public Hex64 Dr3;
        
        public Hex64 Dr6;
        
        public Hex64 Dr7;

        public Hex64 Rax;

        public Hex64 Rcx;

        public Hex64 Rdx;

        public Hex64 Rbx;

        public Hex64 Rsp;

        public Hex64 Rbp;

        public Hex64 Rsi;

        public Hex64 Rdi;

        public Hex64 R8;

        public Hex64 R9;

        public Hex64 R10;

        public Hex64 R11;

        public Hex64 R12;

        public Hex64 R13;

        public Hex64 R14;

        public Hex64 R15;

        public Hex64 Rip;

        ByteBlock32 Header;

        ByteBlock16 Legacy0;

        ByteBlock16 Legacy1;

        ByteBlock16 Legacy2;

        ByteBlock16 Legacy3;

        ByteBlock16 Legacy4;

        ByteBlock16 Legacy5;

        ByteBlock16 Legacy6;

        ByteBlock16 Legacy7;

        public XMM_REGISTERS Xmm;
        
        public VECTOR_REGISTERS VectorRegisters;

        public Hex64 VectorControl;

        public Hex64 DebugControl;
        
        public Hex64 LastBranchToRip;
        
        public Hex64 LastBranchFromRip;
        
        public Hex64 LastExceptionToRip;
        
        public Hex64 LastExceptionFromRip;
    }
}